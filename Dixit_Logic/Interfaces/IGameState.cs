using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// It describe a state of game. So, it keep every necessary information about a game's moment.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// It contains all players who playe in the actual game. 
        /// </summary>
        IList<IPlayer> Players
        {
            get;
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her own deck.
        /// </summary>
        Dictionary<IPlayer, IDeck> Hands
        {
            get;
        }

        /// <summary>
        /// It indicate that the game is started or not
        /// </summary>
        bool GameIsRuning
        {
            get;
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her own game-point value.
        /// </summary>
        Dictionary<IPlayer, int> Points
        {
            get;
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her guess.
        /// (guess: Players guess in every turn that what is the originally selected card in the current turn.)
        /// </summary>
        Dictionary<IPlayer, ICard> Guesses
        {
            get;
        }

        /// <summary>
        /// The player who start the actual turn.
        /// </summary>
        IPlayer ActualPlayer
        {
            get;
        }

        /// <summary>
        /// This is the text what describe the association of turn's starter card.
        /// </summary>
        String CardAssociationText
        {
            get;
        }

        /// <summary>
        /// This is the deck from wich the players draw new cards.
        /// </summary>
        IDeck MainDeck
        {
            get;
        }

        /// <summary>
        /// It contain the whole cards in a game
        /// </summary>
        IReadOnlyList<ICard> BaseCards
        {
            get;
        }

        /// <summary>
        /// This are the cards what the players put on the table.
        /// </summary>
        IDeck BoardDeck
        {
            get;
        }

        /// <summary>
        /// Dixit game lasts until one of the players reach this point.
        /// </summary>
        int ObtainablePoint
        {
            get;
            set;
        }
    }
}
