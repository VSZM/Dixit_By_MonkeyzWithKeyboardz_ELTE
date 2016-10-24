using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// This is a game's round interface. It cointain what need to a round of dixit game.
    /// </summary>
    public interface IDixitGame
    {
        /// <summary>
        /// This holds the actual game state what is changed by actions during the game.
        /// </summary>
        IGameState ActualGameState
        {
            get;
            set;
        }

        /// <summary>
        /// This add a new player (by name) to the ActualGameState.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <returns>The new player</returns>
        IPlayer AddPlayer(String name);

        /// <summary>
        /// This method put a card from the player's cards to the BoardDeck(in ActualGameState).
        /// </summary>
        /// <param name="player">The player who put the card</param>
        /// <param name="card">The card what will be put by "player".</param>
        void PutCard(IPlayer player, ICard card);

        /// <summary>
        /// This will add a new guess to what was the original card in the actual turn. The guess will store under the given player.
        /// </summary>
        /// <param name="player">The player who add the guess</param>
        /// <param name="card">The card is guessed by "player"</param>
        void NewGuess(IPlayer player, ICard card);

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate players's point (in ActualGameState).         
        /// </summary>
        void EvaluatePoints();

        /// <summary>
        /// This event is triggered when all players put a card in a turn.
        /// </summary>
        event EventHandler PuttingPhaseEnd;

        /// <summary>        
        /// This event is triggered when all players make a guess in a turn.
        /// </summary>
        event EventHandler GuessPhaseEnd;

        /// <summary>     
        /// This event is triggered at the start of a trun when all cards are consumed from the MainDeck and players have no more cards too .
        /// </summary>
        event EventHandler GameEnd;
    }
}
