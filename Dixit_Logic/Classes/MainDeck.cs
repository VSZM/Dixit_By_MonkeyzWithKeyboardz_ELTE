using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represents the main deck. The main deck is from which the players draw new cards.
    /// </summary>
    public class MainDeck : Deck
    {
        /// <summary>
        /// Construct an empty main deck
        /// </summary>
        public MainDeck() : base() {}

        /// <summary>
        /// Construct a main deck from the given cards.
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public MainDeck(IList<ICard> cards) : base(cards) {}

        /// <summary>
        /// It gives back the first card from the deck 
        /// and ereases that from the deck.
        /// </summary>
        /// <returns>The first card from the deck</returns>
        public ICard DrawCard()
        {
            ICard card = _cards.First();
            _cards.Remove(card);
            return card;
        }
    }
}
