using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dixit.Injectors;
using Dixit_Logic.Interfaces;
using Dixit_Logic.Classes;

namespace Integration_Tests
{
    [TestClass]
    public class GameLogicTests
    {
        private IDixitGame game;

        [TestInitialize]
        public void SetUp()
        {
            game = LogicInjector.Container.GetInstance<IDixitGame>();
            game.AddPlayer("Brigi");
            game.AddPlayer("Zsófi");
            game.AddPlayer("Gábor");
            game.AddPlayer("Geri");
            game.AddPlayer("Marci");
            game.AddPlayer("Matyi");
            game.StartGame();
        }

        [TestMethod]
        public void TestGameStarts()
        {
            Assert.IsTrue(game.ActualGameState.GameIsRuning);
            Assert.AreEqual(PhaseStatus.AssociationTelling, game.ActualGameState.RoundStatus);
            foreach (var player in game.ActualGameState.Players)
            {
                Assert.AreEqual(0, game.ActualGameState.Points[player]);
                Assert.IsNotNull(game.ActualGameState.Hands[player]);
                Assert.IsTrue(game.ActualGameState.Hands[player].Cards.Count > 0);
            }
            Assert.IsTrue(string.IsNullOrEmpty(game.ActualGameState.CardAssociationText));
        }

        /// <summary>
        /// When none of the players reach the obtainable point than the game continue until
        /// the main deck has less cards then number of players of the game and players have no more cards too.
        /// </summary>
        [TestMethod]
        public void TestPlayersNotReachTheObtainablePoint()
        {
            game.ActualGameState.ObtainablePoint = game.ActualGameState.BaseCards.Count * 20;
            while (game.ActualGameState.Hands.First().Value.Cards.Count != 0)
            {
                Assert.AreNotEqual(PhaseStatus.GameOver, game.ActualGameState.RoundStatus);

                game.AddAssociationText("Something", game.ActualGameState.ActualPlayer);
                
                IDeck actPlayerHand;
                game.ActualGameState.Hands.TryGetValue(game.ActualGameState.ActualPlayer, out actPlayerHand);
                ICard originalCard = actPlayerHand.Cards.First();
                game.PutCard(game.ActualGameState.ActualPlayer, originalCard);

                foreach (var player in game.ActualGameState.Players)
                {                    
                    if (!player.Equals(game.ActualGameState.ActualPlayer))
                    {
                        IDeck playerHand;
                        game.ActualGameState.Hands.TryGetValue(player, out playerHand);
                        game.PutCard(player, playerHand.Cards.First());
                    }
                    
                }

                foreach (var player in game.ActualGameState.Players)
                {
                    if (!player.Equals(game.ActualGameState.ActualPlayer))
                    {
                        game.NewGuess(player, originalCard);
                    }
                }

                game.EvaluatePoints();
            }
            Assert.AreEqual(PhaseStatus.GameOver, game.ActualGameState.RoundStatus);
            Assert.IsTrue(game.ActualGameState.BoardDeck.Cards.Count < game.ActualGameState.Players.Count);

            foreach (var playerHand in game.ActualGameState.Hands)
            {
                Assert.AreEqual(0, playerHand.Value.Cards.Count);
            }
        }
    }
}
