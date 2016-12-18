using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represnts the card deck what a player hold in his/her hands.
    /// </summary>
    public class Hand : Deck
    {
        /// <summary>
        /// Construct an empty hand
        /// </summary>
        public Hand() : base() {}

        /// <summary>
        /// Construct a hand from the given cards.
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public Hand(IList<ICard> cards) : base(cards) {}

        /// <summary>
        /// It will removes a specific card from the hand and returns with this card.
        /// If the card is not in the hand than returns with null.
        /// </summary>
        /// <param name="card">The card what we want from the hand</param>
        /// <returns>If the card was found than return with its card param otherwise return with null</returns>
        public ICard GetCard(ICard card)
        {
            if (_cards.Contains(card))
            {
                _cards.Remove(card);
                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
