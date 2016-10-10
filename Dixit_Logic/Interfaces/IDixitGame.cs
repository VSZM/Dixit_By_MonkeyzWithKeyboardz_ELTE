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
    interface IDixitGame
    {
        /// <summary>
        /// It contain all players who playe in the acutal game. 
        /// </summary>
        IPlayer[] Players
        {
            get;
            set;
        }

        /// <summary>
        /// This is the text what describe the association of turn's starter card.
        /// </summary>
        String CardAssociationText
        {
            get;
            set;
        }

        /// <summary>
        /// The player who start the actual turn.
        /// </summary>
        IPlayer ActualPlayer
        {
            get;
        }

        /// <summary>
        /// This is the deck from wich the players draw new cards.
        /// </summary>
        IDeck MainDeck
        {
            get;
            set;
        }

        /// <summary>
        /// This are the cards what the players put on the table.
        /// </summary>
        IDeck BoardDeck
        {
            get;
            set;
        }

        /// <summary>
        /// This add a new player (by name) to the Players.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <returns>The new player identifier</returns>
        int AddPlayer(String name);

        /// <summary>
        /// This method put a card from the player's cards to the BoardDeck.
        /// </summary>
        /// <param name="player">The player's id who put the card</param>
        /// <param name="card">The card's id what will put.</param>
        void PutCard(int player, int card);

        /// <summary>
        /// This will add a new guess to what was the original card in the actual turn. The guess will store under the given player.
        /// </summary>
        /// <param name="player">The player's id who add the guess</param>
        /// <param name="card">The id of the card is guessed</param>
        void NewGuess(int player, int card);

        /// <summary>
        /// This evaluates the points of actual turn and adds these to the appropriate players's point. 
        /// In the end, it returns with the result of evaluation (pairs of player id and point).
        /// </summary>
        /// <returns>A dictionary, what has a player id "key" with a point "value".</returns>
        Dictionary<int, int> EvaluatePoints();

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
