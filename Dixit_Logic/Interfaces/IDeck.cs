using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// This is a general game deck inteface. A deck consists of cards. It makes the cards' usage more easier.
    /// </summary>
    interface IDeck
    {
        /// <summary>
        /// This contain the deck's cards. 
        /// </summary>
        IList<ICard> Cards
        {
            get;
        }

        /// <summary>
        /// It add optional piece of cards to the deck.
        /// </summary>
        /// <param name="cards">Array of cards what you want to add.</param>
        void AddCards(IList<ICard> cards);

        /// <summary>
        /// Get a specific card from the deck. This card is erased from the deck.
        /// If the given card is not included than it will return with null.
        /// </summary>
        /// <param name="card">A specific card what contain the deck</param>
        /// <returns>The object of drawn card</returns>
        ICard GetCard(ICard card);

        /// <summary>
        /// It erase all cards from the deck. It make an empty deck from your extant deck.
        /// </summary>
        void EvacuateDeck();
    }
}
