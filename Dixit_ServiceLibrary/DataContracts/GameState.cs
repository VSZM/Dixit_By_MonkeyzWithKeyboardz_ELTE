using Dixit_Logic.Interfaces;
using Dixit_Service.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_ServiceLibrary.DataContracts
{
    [DataContract]
    public class GameState
    {
        public bool GameIsRunning { get; internal set; }
        public Player ActualPlayer { get; internal set; }
        public string CardAssociationText { get; internal set; }
        public Deck MainDeck { get; internal set; }
        public Deck BoardDeck { get; internal set; }

        public List<Player> Players { get; internal set; }
        public Dictionary<Player, Deck> Hands { get; internal set; }
        public Dictionary<Player, int> Points { get; internal set; }
        public Dictionary<Player, Card> Guesses { get; internal set; }

        public GameState() { }
        public GameState(IGameState igamestate)
        {
            if (igamestate == null) { return; }

            GameIsRunning = igamestate.GameIsRuning;
            ActualPlayer = new Player(igamestate.ActualPlayer);
            CardAssociationText = igamestate.CardAssociationText;
            MainDeck = new Deck(igamestate.MainDeck);
            BoardDeck = new Deck(igamestate.BoardDeck);

            Players = igamestate.Players.Select(x => new Player(x)).ToList();
            Hands = igamestate.Hands.ToDictionary(x => new Player(x.Key), x => new Deck(x.Value));
            Points = igamestate.Points.ToDictionary(x => new Player(x.Key), x => x.Value);
            Guesses = igamestate.Guesses.ToDictionary(x => new Player(x.Key), x => new Card(x.Value));
        }

        public GameState ToPlayerState(IPlayer player)
        {
            return this;
        }
    }
}
