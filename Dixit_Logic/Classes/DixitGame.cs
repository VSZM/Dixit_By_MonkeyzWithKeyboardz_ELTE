using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represent a dixit game. It contains the actual game state and 
    /// the operations which are modify the game state.
    /// </summary>
    public class DixitGame : IDixitGame
    {
        /// <summary>
        /// Minimum number of player who can playe in a dixt game.
        /// </summary>
        private const int _minPlayerNumber = 3;

        /// <summary>
        /// Maximum number of player who can playe in a dixt game.
        /// </summary>
        private const int _maxPlayerNumber = 8;

        /// <summary>
        ///  Store the actual game state what is changed by actions during the game.
        /// </summary>
        private GameState _actGameState;

        /// <summary>
        /// Construct a new dixt game with a game state at default position.
        /// </summary>
        public DixitGame()
        {
            _actGameState = new GameState();
        }

        /// <summary>
        /// Give back the actual game state.
        /// </summary>
        public IGameState ActualGameState
        {
            get
            {
                return _actGameState;
            }
        }

        /// <summary>     
        /// This event is triggered when all cards are consumed from the MainDeck and players have no more cards too .
        /// </summary>
        public event EventHandler GameEnd;

        /// <summary>
        /// This event is triggered when the DixtGame prepared for a new round.
        /// </summary>
        public event EventHandler NewRound;

        /// <summary>        
        /// This event is triggered when all players make a guess in a turn.
        /// </summary>
        public event EventHandler GuessPhaseEnd;

        /// <summary>
        /// This event is triggered when all players put a card in a turn.
        /// </summary>
        public event EventHandler PuttingPhaseEnd;

        /// <summary>
        /// If game is not started than this add a new player (by name) to the _actGameState.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <returns>The new player or if game is started than return null</returns>
        public IPlayer AddPlayer(string name)
        {
            if(!_actGameState.GameIsRuning)
            {
                Player newPlayer = new Player(name);
                _actGameState.Players.Add(newPlayer);

                return newPlayer;
            }
            else
            {
                return null;
            }
                
        }

        /// <summary>
        /// If game is not started than this method remove a player from the gameState player list
        /// </summary>
        /// <param name="player">The player what we want to remove</param>
        /// <returns>
        /// If game is started: return false. 
        /// 
        /// If game is not started: rerturn true if player is successfully removed;
        /// otherwise, false. This method also returns false if player was not found.</returns>
        public bool RemovePlayer(IPlayer player)
        {
            if (!_actGameState.GameIsRuning)
            {
                return _actGameState.Players.Remove(player);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// If enough player connected to the game than this method
        /// start the game by set the RoundStatus property of game state
        /// to AssociationTelling(first phase of a round).
        /// </summary>
        /// <returns>true if the method could start the game, otherwise false</returns>
        public bool StartGame()
        {
            if(!_actGameState.GameIsRuning)
            {
                int playerCount = _actGameState.Players.Count;

                if (playerCount >= _minPlayerNumber && playerCount <= _maxPlayerNumber)
                {
                    Random random = new Random();                   
                    int actPlayerIndex = random.Next(_actGameState.Players.Count);

                    _actGameState.ActualPlayer = _actGameState.Players[actPlayerIndex];
                    _actGameState.RoundStatus = PhaseStatus.AssociationTelling;

                    MainDeck mainDeck = (MainDeck)_actGameState.MainDeck;
                    mainDeck.Shuffle(); // it shuffles main deck before the game is stated

                    foreach (var player in _actGameState.Players)
                    {
                        _actGameState.Points.Add(player, 0);

                        //deal out six cards to each player
                        Hand hand = new Hand();
                        for (int i = 0; i < 5; i++)
                        {
                            Card drawnCard = (Card)mainDeck.DrawCard();
                            drawnCard.Owner = (Player) player;
                            hand.AddCard(drawnCard);
                        }

                        _actGameState.Hands.Add(player, hand);
                    }                    
                    
                    //if it prepares the first round than it raises the new round event
                    NewRound(this, new EventArgs());

                    return true;
                }
            }
                                    
            return false;            
        }

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate 
        /// players's point (in _actGameState). Than it prepares the next round if the 
        /// game have more otherwise raise the GameEnd event.
        /// </summary>
        public void EvaluatePoints()
        {
            if (_actGameState.RoundStatus == PhaseStatus.RoundEnd)
            {
                Card originalCard = null;
                foreach (var boardCard in _actGameState.BoardDeck.Cards)
                {
                    if (((Card)boardCard).Owner.Equals(_actGameState.ActualPlayer))
                    {
                        originalCard = (Card)boardCard;
                    }
                }
                if (originalCard != null)
                {
                    
                    int goodGuess = 0;
                    foreach (var guessedCard in _actGameState.Guesses)
                    {
                        Player guessedCardOwner = ((Card)guessedCard.Value).Owner;

                        if (originalCard.Equals(guessedCard.Value))
                        {                           
                            _actGameState.Points[guessedCard.Key] = _actGameState.Points[guessedCard.Key] + 3;
                            goodGuess++;
                        }
                        else
                        {                             
                            _actGameState.Points[guessedCardOwner] = _actGameState.Points[guessedCardOwner] + 1;
                        }
                    }
                    
                    

                    //This section cheks whether all players has figured out the original card
                    if (goodGuess != (_actGameState.Players.Count - 1))
                    {                        
                        _actGameState.Points[_actGameState.ActualPlayer] = _actGameState.Points[_actGameState.ActualPlayer] + 3;
                    }
                }


                //This section prepares the next round if the game have more otherwise raise the GameEnd event
                _actGameState.BoardDeck.EvacuateDeck();
                _actGameState.Guesses.Clear();
                _actGameState.CardAssociationText = "";


                if (_actGameState.MainDeck.Cards.Count < _actGameState.Players.Count)
                {
                    if (_actGameState.Hands.First().Value.Cards.Count <= 0)
                    {
                        _actGameState.RoundStatus = PhaseStatus.GameOver;
                        //if all cards are consumed from the MainDeck and players have no more cards too than it raises the game end event.
                        GameEnd(this, new EventArgs());
                    }
                    
                }
                else
                {
                    MainDeck mainDeck = (MainDeck)_actGameState.MainDeck;

                    //draw a card to each player
                    foreach (var playerHand in _actGameState.Hands)
                    {
                        Hand hand = (Hand) playerHand.Value;
                        Card drawnCard = (Card) mainDeck.DrawCard();
                        drawnCard.Owner = (Player) playerHand.Key;
                        hand.AddCard(drawnCard);
                    }
                }

                int actPlayerIndex = _actGameState.Players.IndexOf(_actGameState.ActualPlayer);

                if(actPlayerIndex >= (_actGameState.Players.Count -1))
                {
                    actPlayerIndex = 0;
                }
                else
                {
                    actPlayerIndex++;
                }

                _actGameState.ActualPlayer = _actGameState.Players.ElementAt(actPlayerIndex);
                _actGameState.RoundStatus = PhaseStatus.AssociationTelling;

                //if it prepares the new round than it raises the new round event
                NewRound(this, new EventArgs());

            }
        }

        /// <summary>
        /// If game is runing than this method add a new association text to the 
        /// game state and set story teller (ActualPlayer) to the player who guess this text(in param).
        /// </summary>
        /// <param name="storyText">An association text string</param>
        /// <param name="player">The player who guess the text</param>
        /// <returns>True if game's round status is in AssociationTelling phase and game
        /// is runing. Otherwise return false.  </returns>
        public bool AddAssociationText(string storyText, IPlayer player)
        {
            if(_actGameState.ActualPlayer.Equals(player) && _actGameState.RoundStatus == PhaseStatus.AssociationTelling)
            {
                _actGameState.CardAssociationText = storyText;                
                _actGameState.RoundStatus = PhaseStatus.Putting;
                return true;
            }
            else
            {
                return false;
            }            
        }

        /// <summary>
        /// This will add a new guess to what was the original card in the actual turn.
        /// The guess will be assigned to the given player.(in _actGameState).
        /// </summary>
        /// <param name="player">The player who add the guess</param>
        /// <param name="card">The card is guessed by "player"</param>
        public void NewGuess(IPlayer player, ICard card)
        {
            if (player != null && !player.Equals(_actGameState.ActualPlayer) 
                && _actGameState.RoundStatus == PhaseStatus.Guessing 
                && _actGameState.BoardDeck.Cards.Contains(card))
            {
                bool playerAlreadyGuess = false;

                foreach (var guess in _actGameState.Guesses)
                {
                    if (guess.Key.Equals(player))
                    {
                        playerAlreadyGuess = true;
                        break;
                    }

                }

                if (!playerAlreadyGuess)
                {
                    _actGameState.Guesses.Add(player, card);
                    if (_actGameState.Guesses.Count == (_actGameState.Players.Count - 1))
                    {
                        _actGameState.RoundStatus = PhaseStatus.RoundEnd;
                                                
                        //if all players guessed a card in a turn than it raise the guess phase end event.
                        GuessPhaseEnd(this, new EventArgs());
                    }                    
                }               
            }
        }

        /// <summary>
        /// This method put a card from the player's hands to the board deck(in _actGameState)
        /// </summary>
        /// <param name="player">The player who put the card</param>
        /// <param name="card">The card what will be put by "player".</param>
        public void PutCard(IPlayer player, ICard card)
        {
            if(player != null && _actGameState.RoundStatus == PhaseStatus.Putting)
            {                
                bool playerAlreadyPut = false;

                foreach (var boardCard in _actGameState.BoardDeck.Cards)
                {
                    if (((Card)boardCard).Owner.Equals(player))
                    {
                        playerAlreadyPut = true;
                        break;
                    }
                    
                }

                if (!playerAlreadyPut)
                {
                    IDeck playerHand;

                    if (_actGameState.Hands.TryGetValue(player, out playerHand))
                    {
                        ICard selectedCard = ((Hand)playerHand).GetCard(card);
                        if (selectedCard != null)
                        {
                            _actGameState.BoardDeck.AddCard(selectedCard);

                            if (_actGameState.BoardDeck.Cards.Count == _actGameState.Players.Count)
                            {
                                //shuffle the board deck
                                ((Deck)_actGameState.BoardDeck).Shuffle();

                                _actGameState.RoundStatus = PhaseStatus.Guessing;

                                //if all players put a card in a turn than it raise the putting phase end event.
                                PuttingPhaseEnd(this, new EventArgs());
                            }
                        }
                    }
                }                
            }
        }
    }
}
