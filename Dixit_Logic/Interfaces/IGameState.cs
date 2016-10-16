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
    interface IGameState
    {

        /// <summary>
        /// This dictionary associate a palyer with own deck.
        /// </summary>
        Dictionary<IPlayer, IDeck> Hands
        {
            get;
            set;
        }

        /// <summary>
        /// This dictionary associate a palyer with own game's point value.
        /// </summary>
        Dictionary<IPlayer, int> Points
        {
            get;
            set;
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her guess.
        /// (guess: Players guess in every turn that what is the originally selected card in the current turn.)
        /// </summary>
        Dictionary<IPlayer, ICard> Guesses
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
    }
}
