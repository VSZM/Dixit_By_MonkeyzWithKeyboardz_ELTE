using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represnt a bit general card deck (as board deck). A Deck object consists of 
    /// cards and provides the basic operations what we want to do with a deck (e.g add cards 
    /// to a deck, shuffle cards in a deck).
    /// </summary>
    public class Deck : IDeck
    {
        /// <summary>
        /// It stores the list of cards what the deck contain.
        /// </summary>
        protected List<ICard> _cards;

        /// <summary>
        /// Construct an empty deck
        /// </summary>
        public Deck()
        {
            _cards = new List<ICard>();
        }

        /// <summary>
        /// Construct a deck from the given cards.
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public Deck(IList<ICard> cards)
        {
            _cards = new List<ICard>();
            _cards.AddRange(cards);          
        }

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
        ///  That is put cards in the deck 
        /// </summary>
        /// <param name="cards">An IList implementation what contains card(ICard)s</param>
        public void AddCards(IList<ICard> cards)
        {
            _cards.AddRange(cards);
        }

        /// <summary>
        /// That is put only one card to the deck.
        /// </summary>
        /// <param name="card">the added card</param>
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        /// <summary>
        /// Remove all cards from the deck.
        /// </summary>
        public void EvacuateDeck()
        {
            _cards.Clear();
        }

        /// <summary>
        /// It changes the oder of the cards in the deck.
        /// </summary>
        public void Shuffle()
        {
            Random rand = new Random();
            _cards = _cards.OrderBy(c => rand.Next()).ToList();
        }
    }
}
