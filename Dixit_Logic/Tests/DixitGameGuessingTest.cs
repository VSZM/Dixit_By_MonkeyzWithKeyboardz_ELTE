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
    public class DixitGameGuessingTest
    {
        private DixitGame testGame;

        private IPlayer notActualPlayer;        

        private IDeck nAPlayerHand;

        private ICard nAPlayerPutCard;

        /// <summary>
        /// Set up a dixit game with six player and start the game. The Addplayer and StartGame 
        /// methods are tested in DixtGameBeforeStartTest. Than add an association text which is
        /// tested in DixitGameAssociationTellingTest. After that, all players put a card by 
        /// PutCard method wich is tested in DixitGamePuttingTest.
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

            int actPalyerIndex = testGame.ActualGameState.Players.IndexOf(testGame.ActualGameState.ActualPlayer);
            int notActPlayerIndex = (actPalyerIndex + 1) % testGame.ActualGameState.Players.Count;
            notActualPlayer = testGame.ActualGameState.Players[notActPlayerIndex];            

            testGame.ActualGameState.Hands.TryGetValue(notActualPlayer, out nAPlayerHand);

            testGame.AddAssociationText("Something", testGame.ActualGameState.ActualPlayer);

            foreach (var player in testGame.ActualGameState.Players)
            {
                IDeck playerHand;
                testGame.ActualGameState.Hands.TryGetValue(player, out playerHand);
                testGame.PutCard(player, playerHand.Cards[0]);
            }

            nAPlayerPutCard = null;

            foreach (var boardCard in testGame.ActualGameState.BoardDeck.Cards)
            {
                if (((Card)boardCard).Owner.Equals(notActualPlayer))
                {
                    nAPlayerPutCard = boardCard;
                    break;
                }
            }

        }

        [TestMethod]
        public void TestNewGuessWithNullParams()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            testGame.NewGuess(notActualPlayer, null);
            testGame.NewGuess(notPlayingPlayer, null);
            testGame.NewGuess(null, nAPlayerHand.Cards[0]);
            testGame.NewGuess(null, new Card(546));
            Assert.AreEqual(0, testGame.ActualGameState.Guesses.Count);

        }

        [TestMethod]
        public void TestNewGuessWithAPlayerWhoDonNotPlayeInTheGame()
        {
            IPlayer notPlayingPlayer = new Player("Nobody");

            testGame.NewGuess(notPlayingPlayer, nAPlayerHand.Cards[0]);
            testGame.NewGuess(notPlayingPlayer, new Card(546));
            Assert.AreEqual(0, testGame.ActualGameState.Guesses.Count);
        }

        [TestMethod]
        public void TestNewGuessWithActualPlayer()
        {
            testGame.NewGuess(testGame.ActualGameState.ActualPlayer, nAPlayerHand.Cards[0]);
            Assert.AreEqual(0, testGame.ActualGameState.Guesses.Count);
        }
        
        [TestMethod]
        public void TestNewGuessWithAPlayerWhoDoNotGuessInTheRound()
        {           
            ICard correctGuess = null;
            foreach (var boardCard in testGame.ActualGameState.BoardDeck.Cards)
            {
                if (!((Card)boardCard).Owner.Equals(notActualPlayer))
                {
                    correctGuess = boardCard;
                    break;
                }
            }

            testGame.NewGuess(notActualPlayer, nAPlayerPutCard);
            Assert.AreEqual(0, testGame.ActualGameState.Guesses.Count);

            testGame.NewGuess(notActualPlayer, correctGuess);
            Assert.AreEqual(1, testGame.ActualGameState.Guesses.Count);

        }
        
        [TestMethod]
        public void TestNewGuessWithAPlayerWhoGuessedInTheRound()
        {
            ICard correctGuess = null;
            foreach (var boardCard in testGame.ActualGameState.BoardDeck.Cards)
            {
                if (!((Card)boardCard).Owner.Equals(notActualPlayer))
                {
                    correctGuess = boardCard;
                    break;
                }
            }

            testGame.NewGuess(notActualPlayer, correctGuess);
            Assert.AreEqual(1, testGame.ActualGameState.Guesses.Count);

            foreach (var boardCard in testGame.ActualGameState.BoardDeck.Cards)
            {
                if (!((Card)boardCard).Owner.Equals(notActualPlayer) && boardCard != correctGuess)
                {
                    correctGuess = boardCard;
                    break;
                }
            }

            testGame.NewGuess(notActualPlayer, correctGuess);
            Assert.AreEqual(1, testGame.ActualGameState.Guesses.Count);
        }
        
        [TestMethod]
        public void TestAllPlayerMakeNewGuess()
        {
            ICard correctGuess = null;
            foreach (var boardCard in testGame.ActualGameState.BoardDeck.Cards)
            {
                if (((Card)boardCard).Owner.Equals(testGame.ActualGameState.ActualPlayer))
                {
                    correctGuess = boardCard;
                    break;
                }
            }
            foreach (var player in testGame.ActualGameState.Players)
            {
                if (!player.Equals(testGame.ActualGameState.ActualPlayer))
                {
                    testGame.NewGuess(player, correctGuess);
                }
            }

            Assert.AreEqual(PhaseStatus.RoundEnd, testGame.ActualGameState.RoundStatus);
            Assert.AreEqual((testGame.ActualGameState.Players.Count-1), testGame.ActualGameState.Guesses.Count);
        }
    }
}
