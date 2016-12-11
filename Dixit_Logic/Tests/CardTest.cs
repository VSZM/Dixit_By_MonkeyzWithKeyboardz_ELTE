using Dixit_Logic.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestEqualsByCompareCardsWithSameId()
        {
            Card firstCard = new Card(12);
            Card secondCard = new Card(12);            

            bool result = firstCard.Equals(secondCard);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestEqualsByCompareACardWithAnObejct()
        {
            Card firstCard = new Card(12);

            bool result = firstCard.Equals(new Object());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEqualsByCompareACardWithANullPointer()
        {
            Card firstCard = new Card(12);

            bool result = firstCard.Equals(null);

            Assert.IsFalse(result);
        }
    }
}
