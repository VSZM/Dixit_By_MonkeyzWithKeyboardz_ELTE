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
    [KnownType("GetKnownTypes")]
    public class GameState
    {
        [DataMember]
        public bool GameIsRunning { get; internal set; }
        [DataMember]
        public Player ActualPlayer { get; internal set; }
        [DataMember]
        public string CardAssociationText { get; internal set; }
        [DataMember]
        public Deck MainDeck { get; internal set; }
        [DataMember]
        public Deck BoardDeck { get; internal set; }

        [DataMember]
        public List<Player> Players { get; internal set; }
        [DataMember]
        public Dictionary<Player, Deck> Hands { get; internal set; }
        [DataMember]
        public Dictionary<Player, int> Points { get; internal set; }
        [DataMember]
        public Dictionary<Player, Card> Guesses { get; internal set; }
        [DataMember]
        public PhaseStatus RoundStatus;

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
            RoundStatus = igamestate.RoundStatus;
        }

        public GameState ToPlayerState(IPlayer player)
        {
            return this;
        }

        static Type[] GetKnownTypes()
        {
            return new Type[] {
                typeof(Player),
                typeof(Deck),
                typeof(Card),
                typeof(List<Player>),
                typeof(Dictionary<Player, Deck>),
                typeof(Dictionary<Player, int>),
                typeof(Dictionary<Player, Card>),
                typeof(PhaseStatus)
            };
        }
    }
}
