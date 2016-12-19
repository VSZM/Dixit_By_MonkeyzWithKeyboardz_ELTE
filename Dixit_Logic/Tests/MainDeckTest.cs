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
    public class MainDeckTest
    {
        [TestMethod]
        public void TestDrawCardWithEmptyMainDeck()
        {
            MainDeck testMainDeck = new MainDeck();

            Assert.IsNull(testMainDeck.DrawCard());
        }

        [TestMethod]
        public void TestDrawCardWithNonemptyMainDeck()
        {
            MainDeck testMaindDeck = new MainDeck();

            for (int i = 0; i < 50; i++)
            {
                testMaindDeck.AddCard(new Card(i));
            }

            ICard drawnCard = testMaindDeck.DrawCard();

            Assert.IsTrue(drawnCard.Id >= 0 && drawnCard.Id < 50);
            Assert.IsFalse(testMaindDeck.Cards.Contains(drawnCard));
        }
    }
}
