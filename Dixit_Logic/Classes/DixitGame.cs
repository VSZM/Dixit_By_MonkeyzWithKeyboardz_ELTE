using System;
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
    class DixitGame : IDixitGame
    {
        static DixitGame()
        {
            Injector.Container.Register<IDixitGame, DixitGame>();
        }

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
        /// This add a new player (by name) to the _actGameState.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <returns>The new player</returns>
        public IPlayer AddPlayer(string name)
        {
            Player newPlayer = new Player(name);
            _actGameState.Players.Add(newPlayer);

            return newPlayer;
        }

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate players's point (in _actGameState).         
        /// </summary>
        public void EvaluatePoints()
        {
            throw new NotImplementedException();
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
    }
}
