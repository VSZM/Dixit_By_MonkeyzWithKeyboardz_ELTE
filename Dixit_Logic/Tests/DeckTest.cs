using Dixit_Logic.Classes;
using Dixit_Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Tests
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void TestAddCardAndAddCardsAndEvacuateMethods()
        {
            Deck firstDeck = new Deck();
            Deck secondDeck = new Deck();

            List<ICard> cardList = new List<ICard>();

            for (int i = 0; i < 10; i++)
            {
                Card newCard = new Card(i);
                firstDeck.AddCard(newCard);
                cardList.Add(newCard);
            }

            secondDeck.AddCards(cardList);

            Assert.IsTrue(firstDeck.Cards.SequenceEqual(secondDeck.Cards));

            firstDeck.EvacuateDeck();
            Assert.IsFalse(firstDeck.Cards.SequenceEqual(secondDeck.Cards));

            secondDeck.EvacuateDeck();
            Assert.IsTrue(firstDeck.Cards.SequenceEqual(secondDeck.Cards));

        }

        [TestMethod]
        public void TestShuffleMakeDifferentCardOrder()
        {
            List<ICard> cardList = new List<ICard>();

            for (int i = 0; i < 10; i++)
            {                
                cardList.Add(new Card(i));
            }

            Deck firstDeck = new Deck(cardList);
     
            bool newOrder = false;

            //if the deck doesn't get a new order, than the program try to shuffle the deck once again
            //becous in some cases after shuffling, the deck can get back the original order
            for (int j = 0; j < 1; j++)
            {
                firstDeck.Shuffle();

                for (int i = 0; i < cardList.Count; i++)
                {
                    if (firstDeck.Cards[i] != cardList[i])
                    {
                        newOrder = true;
                        break;
                    }
                }
                if (newOrder)
                {
                    break;
                }
            }

            Assert.IsTrue(newOrder);
            Assert.IsTrue(new HashSet<ICard>(cardList).SetEquals(firstDeck.Cards));
        }
    }
}
