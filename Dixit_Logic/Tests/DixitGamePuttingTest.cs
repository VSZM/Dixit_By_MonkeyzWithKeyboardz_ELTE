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
    public class DixitGamePuttingTest
    {
        private DixitGame testGame;

        private IPlayer notActualPlayer;

        private IDeck nAPlayerHand;

        /// <summary>
        /// Set up a dixit game with six player and start the game. The Addplayer and StartGame 
        /// methods are tested in DixtGameBeforeStartTest. Than add an association text which is
        /// tested in DixitGameAssociationTellingTest.
        /// </summary>
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

            int actPlayerIndex = testGame.ActualGameState.Players.IndexOf(testGame.ActualGameState.ActualPlayer);
            int notActPlayerIndex = (actPlayerIndex + 1) % testGame.ActualGameState.Players.Count;
            notActualPlayer = testGame.ActualGameState.Players[notActPlayerIndex];

            testGame.ActualGameState.Hands.TryGetValue(notActualPlayer, out nAPlayerHand);

            testGame.AddAssociationText("Something", testGame.ActualGameState.ActualPlayer);
        }

        [TestMethod]
        public void TestPutCardWithNullParams()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            testGame.PutCard(notActualPlayer, null);
            testGame.PutCard(notPlayingPlayer, null);
            testGame.PutCard(null, nAPlayerHand.Cards[0]);
            testGame.PutCard(null, new Card(546));
            Assert.AreEqual(0,testGame.ActualGameState.BoardDeck.Cards.Count);

        }

        [TestMethod]
        public void TestPutCardWithAPlayerWhoDonNotPlayeInTheGame()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            testGame.PutCard(notPlayingPlayer, nAPlayerHand.Cards[0]);
            testGame.PutCard(notPlayingPlayer, new Card(546));
            Assert.AreEqual(0, testGame.ActualGameState.BoardDeck.Cards.Count);
        }

        [TestMethod]
        public void TestPutCardWithAPlayerWhoDoNotPutInTheRound()
        {
            testGame.PutCard(notActualPlayer, nAPlayerHand.Cards[0]);
            Assert.AreEqual(1, testGame.ActualGameState.BoardDeck.Cards.Count);
        }

        [TestMethod]
        public void TestPutCardWithAPlayerWhoPutInTheRound()
        {
            testGame.PutCard(notActualPlayer, nAPlayerHand.Cards[0]);
            Assert.AreEqual(1, testGame.ActualGameState.BoardDeck.Cards.Count);
            testGame.PutCard(notActualPlayer, nAPlayerHand.Cards[0]);
            testGame.PutCard(notActualPlayer, nAPlayerHand.Cards[1]);
            Assert.AreEqual(1, testGame.ActualGameState.BoardDeck.Cards.Count);
        }

        [TestMethod]
        public void TestAllPlayerPutCard()
        {
            foreach (var player in testGame.ActualGameState.Players)
            {
                IDeck playerHand;
                testGame.ActualGameState.Hands.TryGetValue(player, out playerHand);
                testGame.PutCard(player, playerHand.Cards[0]);
            }
            Assert.AreEqual(PhaseStatus.Guessing, testGame.ActualGameState.RoundStatus);

            testGame.PutCard(notActualPlayer, nAPlayerHand.Cards[1]);
            Assert.AreEqual(testGame.ActualGameState.Players.Count, testGame.ActualGameState.BoardDeck.Cards.Count);
        }
    }
}
