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
    public class HandTest
    {
        private Hand testHand;

        [TestInitialize]
        public void SetUp()
        {
            testHand = new Hand();

            for (int i = 0; i < 10; i++)
            {
                testHand.AddCard(new Card(i));
            }   
        }

        [TestMethod]
        public void TestGetCardWithNull()
        {
            ICard result = testHand.GetCard(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetCardWithAnOutsiderCard()
        {
            ICard result = testHand.GetCard(new Card(11));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetCardWithACardOfTheHand()
        {
            ICard cardOfTheHand = testHand.Cards[5];
            ICard result = testHand.GetCard(cardOfTheHand);

            Assert.AreSame(cardOfTheHand, result);            
            Assert.IsNull(testHand.GetCard(cardOfTheHand));
            Assert.IsFalse(testHand.Cards.Contains(cardOfTheHand));
        }
    }
}
