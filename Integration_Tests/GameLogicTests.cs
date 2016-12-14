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
    }
}
