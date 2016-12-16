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
    public class DixtGameBeforeStartTest
    {

        private DixitGame testGame;
        

        [TestInitialize]
        public void SetUp()
        {
            testGame = new DixitGame();  
        }

        [TestMethod]
        public void TestAddPlayerAndRemovePlayerBeforeStart()
        {            
            Assert.AreEqual(PhaseStatus.BeforeStart, testGame.ActualGameState.RoundStatus);
            IPlayer addedPlayer = testGame.AddPlayer("Matyi");

            Assert.AreEqual(PhaseStatus.BeforeStart, testGame.ActualGameState.RoundStatus);
            Assert.AreEqual("Matyi", addedPlayer.Name);

            Assert.IsTrue(testGame.RemovePlayer(addedPlayer));
            Assert.AreEqual(PhaseStatus.BeforeStart, testGame.ActualGameState.RoundStatus);
            Assert.AreEqual(0, testGame.ActualGameState.Players.Count);
        }

        [TestMethod]
        public void TestAddPlayerAndRemovePlayerAfterStart()
        {            
            for (int i = 0; i < 6; i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            testGame.StartGame();

            Assert.AreNotEqual(PhaseStatus.BeforeStart, testGame.ActualGameState.RoundStatus);
            IPlayer addedPlayer = testGame.AddPlayer("Matyi");

            Assert.AreNotEqual(PhaseStatus.BeforeStart, testGame.ActualGameState.RoundStatus);
            Assert.IsNull(addedPlayer);

            Assert.IsFalse(testGame.RemovePlayer(testGame.ActualGameState.Players.First()));
            Assert.AreEqual(6, testGame.ActualGameState.Players.Count);
        }

        [TestMethod]
        public void TestStartGameWithLessThanMinPlayerNumber()
        {            
            for (int i = 0; i < (testGame.MinPlayerNumber - 1); i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            Assert.IsFalse(testGame.StartGame());
        }

        [TestMethod]
        public void TestStartGameWithMinPlayerNumber()
        {            
            for (int i = 0; i < testGame.MinPlayerNumber; i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            Assert.IsTrue(testGame.StartGame());
        }

        [TestMethod]
        public void TestStartGameWithMaxPlayerNumber()
        {
            for (int i = 0; i < testGame.MaxPlayerNumber; i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            Assert.IsTrue(testGame.StartGame());
        }

        [TestMethod]
        public void TestStartGameWithMoreThanMaxPlayerNumber()
        {
            for (int i = 0; i < (testGame.MaxPlayerNumber + 1); i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            Assert.IsFalse(testGame.StartGame());
        }

        [TestMethod]
        public void TestStartGameAfterStart()
        {
            for (int i = 0; i < testGame.MinPlayerNumber; i++)
            {
                testGame.AddPlayer("Player" + i);
            }

            testGame.StartGame();

            Assert.IsFalse(testGame.StartGame());
        }
    }
}
