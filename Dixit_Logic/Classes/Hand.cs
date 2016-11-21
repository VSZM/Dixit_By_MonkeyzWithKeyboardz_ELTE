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
    class Hand : IDeck
    {
        /// <summary>
        /// It stores the list of cards what the hand contain.
        /// </summary>
        private List<ICard> _cards;

        /// <summary>
        /// Return with the cards what stores in _cards
        /// </summary>
        public IList<ICard> Cards
        {
            get
            {
                return _cards;
            }
        }

        /// <summary>
        /// Construct an empty hand
        /// </summary>
        public Hand()
        {
            _cards = new List<ICard>();
        }

        /// <summary>
        /// Construct a hand from the given cards.
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public Hand(IList<ICard> cards)
        {
            _cards = new List<ICard>();
            _cards.AddRange(cards);
        }

        /// <summary>
        /// That is put cards in the hand 
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public void AddCards(IList<ICard> cards)
        {
             _cards.AddRange(cards);            
        }

        /// <summary>
        /// That is put only one card to the hand.
        /// </summary>
        /// <param name="card">the added card</param>
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        /// <summary>
        /// Remove all cards from the hand.
        /// </summary>
        public void EvacuateDeck()
        {
            _cards.Clear();
        }

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
