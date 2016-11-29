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
    public interface IDeck
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
        /// It add one card to the deck
        /// </summary>
        /// <param name="card">the added card</param>
        void AddCard(ICard card);

        /// <summary>
        /// It erase all cards from the deck. It make an empty deck from your extant deck.
        /// </summary>
        void EvacuateDeck();
    }
}
