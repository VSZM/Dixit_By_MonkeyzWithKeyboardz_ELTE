﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;
using Dixit.Common;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represent a dixit game. It contains the actual game state and 
    /// the operations which are modify the game state.
    /// </summary>
    public class DixitGame : IDixitGame
    {
        static DixitGame()
        {
            Injector.Container.Register<IDixitGame, DixitGame>();
        }

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
        /// This event is triggered at the start of a trun when all cards are consumed from the MainDeck and players have no more cards too .
        /// </summary>
        public event EventHandler GameEnd;

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
        /// start the game by set the GameIsRuning property of game state to true.
        /// </summary>
        /// <returns>true if the method could start the game, otherwise false</returns>
        public bool StartGame()
        {
            int playerCount = _actGameState.Players.Count;

            if (playerCount >= _minPlayerNumber && playerCount <= _maxPlayerNumber)
            {
                _actGameState.GameIsRuning = true;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate players's point (in _actGameState).         
        /// </summary>
        public void EvaluatePoints()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If game is runing than this method add a new association text to the game state
        /// </summary>
        /// <param name="storyText">An association text string</param>
        /// <returns>True if game's round status is in AssociationTelling phase and game
        /// is runing. Otherwise return false.  </returns>
        public bool AddAssociationText(string storyText)
        {
            if(_actGameState.GameIsRuning && _actGameState.RoundStatus == PhaseStatus.AssociationTelling)
            {
                _actGameState.CardAssociationText = storyText;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method put a card from the player's hands to the board deck(in _actGameState)
        /// </summary>
        /// <param name="player">The player who put the card</param>
        /// <param name="card">The card what will be put by "player".</param>
        public void PutCard(IPlayer player, ICard card)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICard> GetAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
