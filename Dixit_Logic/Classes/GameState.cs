using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Classes
{
    public enum PhaseStatus { BeforeStart = 0, AssociationTelling = 1, Putting = 2, Guessing = 3, RoundEnd = 4 };

    /// <summary>
    /// This class describes a state of game. Every property have internal set method
    /// so only the logic can modify the game state.
    /// </summary>
    public class GameState : IGameState
    {
        /// <summary>
        /// Store the player who start the actual turn.
        /// </summary>
        private IPlayer _storyTeller;

        /// <summary>
        /// Store the deck which contains the cards what the players put on the table.
        /// </summary>
        private IDeck _boardDeck;

        /// <summary>
        /// Store a text what describes the association of turn's starter card.
        /// </summary>
        private string _storyText;

        /// <summary>
        /// Store a dictionary associate a palyer with his/her guess.
        /// </summary>
        private Dictionary<IPlayer, ICard> _guesses;

        /// <summary>
        /// Store a dictionary associate a palyer with his/her own hand.
        /// </summary>
        private Dictionary<IPlayer, IDeck> _hands;

        /// <summary>
        ///  Store the deck from wich the players draw new cards.
        /// </summary>
        private IDeck _mainDeck;

        /// <summary>
        /// Store all cards in a game. It will not be modified during the game.
        /// </summary>
        private IReadOnlyList<ICard> _baseCards;

        /// <summary>
        /// Store all players who playe in the actual game. 
        /// </summary>
        private IList<IPlayer> _players;

        /// <summary>
        /// Store a dictionary what associate a palyer with his/her own game-point value.
        /// </summary>
        private Dictionary<IPlayer, int> _points;

        /// <summary>
        /// Store a status about the phase of the current round.
        /// </summary>
        private PhaseStatus _roundStatus;

        /// <summary>
        /// Construct a default game state.
        /// </summary>
        public GameState()
        {          
            _storyTeller = null;
            //_boardDeck = new IDeck();
            _storyText = "";
            _guesses = new Dictionary<IPlayer, ICard>();
            _hands = new Dictionary<IPlayer, IDeck>();
            //_mainDeck = new IDeck();
            _baseCards = new List<ICard>().AsReadOnly();
            _players = new List<IPlayer>();            
            _points = new Dictionary<IPlayer, int>();
            _roundStatus = PhaseStatus.BeforeStart; // set to the game's round starting status
        }

        /// <summary>
        /// The player who start the actual turn.
        /// </summary>
        public IPlayer ActualPlayer
        {
            get
            {
                return _storyTeller;
            }

            internal set
            {
                _storyTeller = value;
            }
        }

        /// <summary>
        /// This are the cards what the players put on the table.
        /// </summary>
        public IDeck BoardDeck
        {
            get
            {
                return _boardDeck;
            }

            internal set
            {
                _boardDeck = value;
            }
        }

        /// <summary>
        /// This is the text what describe the association of turn's starter card.
        /// </summary>
        public string CardAssociationText
        {
            get
            {
                return _storyText;
            }

            internal set
            {
                _storyText = value;
            }
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her guess.
        /// </summary>
        public Dictionary<IPlayer, ICard> Guesses
        {
            get
            {
                return _guesses;
            }

            internal set
            {
                _guesses = value;
            }
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her own hand.
        /// </summary>
        public Dictionary<IPlayer, IDeck> Hands
        {
            get
            {
                return _hands;
            }

            internal set
            {
                _hands = value;
            }
        }

        /// <summary>
        /// This is the deck from wich the players draw new cards.
        /// </summary>
        public IDeck MainDeck
        {
            get
            {
                return _mainDeck;
            }

            internal set
            {
                _mainDeck = value;
            }
        }

        /// <summary>
        /// It contain the whole cards in a game
        /// </summary>
        public IReadOnlyList<ICard> BaseCards
        {
            get
            {
                return _baseCards;
            }

            internal set
            {
                _baseCards = value;
            }
        }

        /// <summary>
        /// It contains all players who playe in the actual game.
        /// </summary>
        public IList<IPlayer> Players
        {
            get
            {
                return _players;
            }

            internal set
            {
                _players = value;
            }
        }

        /// <summary>
        /// It indicate that the game is started or not
        /// </summary>
        public bool GameIsRuning
        {
            get
            {
                return (RoundStatus != PhaseStatus.BeforeStart);
            }
        }

        /// <summary>
        /// This dictionary associate a palyer with his/her own game-point value.
        /// </summary>
        public Dictionary<IPlayer, int> Points
        {
            get
            {
                return _points;
            }

            internal set
            {
                _points = value;
            }
        }

        /// <summary>
        /// It indicate the actual round status. A round always start 
        /// with the "AssociationTelling" phase.
        /// </summary>
        public PhaseStatus RoundStatus
        {
            get
            {
                return _roundStatus;
            }

            internal set
            {
                _roundStatus = value;
            }
        }
    }
}
