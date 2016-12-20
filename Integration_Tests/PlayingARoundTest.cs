using Dixit.Injectors;
using Dixit_Logic.Classes;
using Dixit_Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Integration_Tests
{
    [TestClass]
    public class PlayingARoundTest
    {
        public void SetUpGame(out IDixitGame game, out List<IPlayer> players)
        {
            game = new DixitGame();
            players = new List<IPlayer>();

            players.Add(game.AddPlayer("player1"));
            players.Add(game.AddPlayer("player2"));
            players.Add(game.AddPlayer("player3"));
            players.Add(game.AddPlayer("player4"));

            game.StartGame();
        }

        [TestMethod]
        public void EverybodyGuessTheCard()
        {
            IDixitGame game1;
            List<IPlayer> players1;
            SetUpGame(out game1, out players1);

            IPlayer storyTeller;
            List<ICard> cards;
            ICard cardOfStoryTeller;
            PrepareTheCards(out storyTeller, out cards, out cardOfStoryTeller, game1, players1);

            for (int i = 0; i < players1.Count; ++i)
            {
                if (players1[i] != storyTeller)
                {
                    game1.NewGuess(players1[i], cardOfStoryTeller);
                }
            }

            game1.EvaluatePoints();

            Assert.IsTrue(game1.ActualGameState.Points[storyTeller] == 0);
            for (int i = 0; i < players1.Count; ++i)
            {
                if (players1[i] != storyTeller)
                {
                    Assert.IsTrue(game1.ActualGameState.Points[players1[i]] == 3);
                }
            }
        }
        
        [TestMethod]
        public void NobodyGuessTheCard()
        {
            IDixitGame game2;
            List<IPlayer> players2;
            SetUpGame(out game2, out players2);

            IPlayer storyTeller;
            List<ICard> cards;
            ICard cardOfStoryTeller;
            PrepareTheCards(out storyTeller, out cards, out cardOfStoryTeller, game2, players2);

            cards.Remove(cardOfStoryTeller);
            Card card1 = (Card)cards[0];
            Card card2 = (Card)cards[1];

            players2.Remove(storyTeller);

            for(int i = 0; i < players2.Count; ++i)
            {
                if(card1.Owner == players2[i])
                {
                    game2.NewGuess(players2[i], card2);
                }
                else
                {
                    game2.NewGuess(players2[i], card1);
                }
            }

            game2.EvaluatePoints();

            Assert.IsTrue(game2.ActualGameState.Points[storyTeller] == 0);
            Assert.IsTrue(game2.ActualGameState.Points[card1.Owner] == 2);
            Assert.IsTrue(game2.ActualGameState.Points[card2.Owner] == 1);

            for (int i = 0; i < players2.Count; ++i)
            {
                if (players2[i]!= card1.Owner && players2[i] != card2.Owner)
                {
                    Assert.IsTrue(game2.ActualGameState.Points[players2[i]] == 0);
                }
            }
        }

        [TestMethod]
        public void SomebodyGuessTheCard()
        {
            IDixitGame game3;
            List<IPlayer> players3;
            SetUpGame(out game3, out players3);

            IPlayer storyTeller;
            List<ICard> cards;
            ICard cardOfStoryTeller;
            PrepareTheCards(out storyTeller, out cards, out cardOfStoryTeller, game3, players3);

            cards.Remove(cardOfStoryTeller);
            players3.Remove(storyTeller);

            Card cardOfFirstPlayer = null;
            for(int i = 0; i < cards.Count; ++i)
            {
                Card card = (Card)cards[i];
                if(card.Owner == players3[0])
                {
                    cardOfFirstPlayer = card;
                    break;
                }
            }

            game3.NewGuess(players3[0], cardOfStoryTeller);
            game3.NewGuess(players3[1], cardOfFirstPlayer);
            game3.NewGuess(players3[2], cardOfFirstPlayer);

            game3.EvaluatePoints();

            Assert.IsTrue(game3.ActualGameState.Points[storyTeller] == 3);
            Assert.IsTrue(game3.ActualGameState.Points[players3[0]] == 5);
            Assert.IsTrue(game3.ActualGameState.Points[players3[1]] == 0);
            Assert.IsTrue(game3.ActualGameState.Points[players3[2]] == 0);
        }
        
        void PrepareTheCards(out IPlayer storyTeller, out List<ICard> cards, out ICard cardOfStoryTeller, IDixitGame game, List<IPlayer> players)
        {
            storyTeller = game.ActualGameState.ActualPlayer;
            cards = new List<ICard>();
            game.AddAssociationText("Dream", storyTeller);
            cardOfStoryTeller = getCardFromPlayer(storyTeller, game);
            game.PutCard(storyTeller, cardOfStoryTeller);
            cards.Add(cardOfStoryTeller);
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i] != storyTeller)
                {
                    ICard actCard = getCardFromPlayer(players[i], game);
                    game.PutCard(players[i], actCard);
                    cards.Add(actCard);
                }
            }
        }

        ICard getCardFromPlayer(IPlayer player, IDixitGame game)
        {
            IEnumerator<ICard> enumerator = game.ActualGameState.Hands[player].Cards.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
            throw new Exception("no actual card");
        }
    }
}