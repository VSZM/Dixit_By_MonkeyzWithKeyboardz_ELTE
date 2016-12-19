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
    public class PlayerTest
    {
        private Player testPlayer;

        [TestInitialize]
        public void SetUp()
        {
            testPlayer = new Player("Leonard");
        }

        [TestMethod]
        public void TestEqualsByCompareSamePlayer()
        {
            bool result = testPlayer.Equals(testPlayer);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestEqualsByCompareAPlayerWithAnObejct()
        {
            bool result = testPlayer.Equals(new Object());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEqualsByCompareAPlayerWithANullPointer()
        {
            bool result = testPlayer.Equals(null);

            Assert.IsFalse(result);
        }
    }
}
