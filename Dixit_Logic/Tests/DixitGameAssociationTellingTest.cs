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
    public class DixitGameAssociationTellingTest
    {
        private DixitGame testGame;

        private IPlayer notActualPlayer;

        [TestInitialize]
        public void SetUp()
        {
            testGame = new DixitGame();
            testGame.AddPlayer("Brigi");
            testGame.AddPlayer("Zsófi");
            testGame.AddPlayer("Gábor");
            testGame.AddPlayer("Geri");
            testGame.AddPlayer("Marci");
            testGame.AddPlayer("Matyi");
            testGame.StartGame();

            int actPalyerIndex = testGame.ActualGameState.Players.IndexOf(testGame.ActualGameState.ActualPlayer);
            int notActPlayerIndex = (actPalyerIndex + 1) % testGame.ActualGameState.Players.Count;
            notActualPlayer = testGame.ActualGameState.Players[notActPlayerIndex];
        }


        [TestMethod]
        public void TestAddAssociationTextWithNullParams()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            Assert.IsFalse(testGame.AddAssociationText(null, notActualPlayer));
            Assert.IsFalse(testGame.AddAssociationText(null, notPlayingPlayer));
            Assert.IsFalse(testGame.AddAssociationText(null, testGame.ActualGameState.ActualPlayer));
            Assert.IsFalse(testGame.AddAssociationText("Something", null));
            Assert.IsFalse(testGame.AddAssociationText(null, null));
        }

        [TestMethod]
        public void TestAddAssociationTextWithANotActualPlayer()
        {
            Assert.AreEqual(PhaseStatus.AssociationTelling, testGame.ActualGameState.RoundStatus);
            Assert.IsFalse(testGame.AddAssociationText("Something", notActualPlayer));
            Assert.AreEqual(PhaseStatus.AssociationTelling, testGame.ActualGameState.RoundStatus);
        }


        [TestMethod]
        public void TestAddAssociationTextWithAPlayerWhoDonNotPlayeInTheGame()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            Assert.AreEqual(PhaseStatus.AssociationTelling, testGame.ActualGameState.RoundStatus);
            Assert.IsFalse(testGame.AddAssociationText("Something", notPlayingPlayer));
            Assert.AreEqual(PhaseStatus.AssociationTelling, testGame.ActualGameState.RoundStatus);
        }

        [TestMethod]
        public void TestAddAssociationTextWithAnActualPlayer()
        {
            Assert.AreEqual(PhaseStatus.AssociationTelling, testGame.ActualGameState.RoundStatus);
            Assert.IsTrue(testGame.AddAssociationText("Something", testGame.ActualGameState.ActualPlayer));

            Assert.AreEqual(PhaseStatus.Putting, testGame.ActualGameState.RoundStatus);
            Assert.IsFalse(testGame.AddAssociationText("Something", testGame.ActualGameState.ActualPlayer));
        }        

    }
}
