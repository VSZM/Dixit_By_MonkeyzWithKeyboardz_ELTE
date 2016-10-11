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
        /// It add optional piece of cards to the deck.
        /// </summary>
        /// <param name="cards">Array of cards what you want to add.</param>
        void AddCards(IList<ICard> cards);

        /// <summary>
        /// It change the card order in the deck, what make a new drawing order.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Draw a card from the deck. The drawn card is erased in the deck.
        /// </summary>
        /// <returns>The object of drawn card</returns>
        ICard Draw();

        /// <summary>
        /// It erase all cards from the deck. It make an empty deck from your extant deck.
        /// </summary>
        void EvacuateDeck();
    }
}
