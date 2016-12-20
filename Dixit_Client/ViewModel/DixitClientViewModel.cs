using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Client.Model;
using Dixit_Logic.Interfaces;
using Dixit_Logic.Classes;
using Dixit_Data.Interfaces;

namespace Dixit_Client.ViewModel
{
    /// <summary>
    /// Viewmodel class to maintain the interaction between the view and the game logic
    /// </summary>
    class DixitClientViewModel : ViewModelBase
    {
        //////////////////////////////////////// common part ////////////////////////////////////////
        /// <summary>
        /// own username, because we cannot ask from the service who we are
        /// but get the whole gamestate
        /// </summary>
        private String _username;

        public String UserName {
            get {
                return _username;
            }
            set {
                _username = value;
                HostJoinGameCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Storing the actual player's name
        /// </summary>
        private String _actPlayerName;

        public String ActPlayerName
        {
            get
            {
                return _actPlayerName;
            }
            set
            {
                _actPlayerName = value;
                SendClueCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Model instance to get interaction with the game logic.
        /// </summary>
        private Model.Model model;

        /// <summary>
        /// Players' info
        /// </summary>
        public ObservableCollection<ClientPlayer> Players { get; private set; }

        public DixitClientViewModel()
        {
            Players = new ObservableCollection<ClientPlayer>();
            model = new Model.Model();
            model.LoginFailedEvent += new EventHandler<Exception>(OnLoginFailed);
            model.LoginSuccessEvent += new EventHandler<String>(OnLoginSuccess);
            model.GameStartEvent += new EventHandler<GameStateEventArgs>(OnGameStart);
            model.GameStateChangedEvent += new EventHandler<GameStateEventArgs>(OnGameStateChanged);
            model.GuessPhaseEndEvent += new EventHandler(OnGuessPhaseEnd);
            HostJoinGameCommand = new DelegateCommand(_ => !String.IsNullOrEmpty(UserName), param => hostOrJoin());
            StartGameCommand = new DelegateCommand(param => start());
            PutCardCommand = new DelegateCommand(param => PutCard((Card)param));
            GuessCardCommand  = new DelegateCommand(param => GuessCard((ICard)param));
            SendClueCommand = new DelegateCommand(_ => (UserName.Equals(ActPlayerName) && !String.IsNullOrEmpty(ClueSentence)), param => SendClue());
        }


        //////////////////////////////////////// LoginWindow part ////////////////////////////////////////

        /// <summary>
        /// Event to fire when login failed
        /// </summary>
        public event EventHandler<String> Failed;

        /// <summary>
        /// Event to fire when login was successful
        /// </summary>
        public event EventHandler StartGame;

        /// <summary>
        /// EventHandler to handle failed login attempt
        /// </summary>
        /// <param name="sender">Sender that fired the event</param>
        /// <param name="e">Cause of failure</param>
        private void OnLoginFailed(object sender, Exception e)
        {
            Failed?.Invoke(this, e.Message);
        }

        /// <summary>
        /// EventHandler to handle successful login attempt
        /// </summary>
        /// <param name="sender">Sender that fired the event</param>
        /// <param name="e">Username</param>
        private void OnLoginSuccess(object sender, String e)
        {
            UserName = e;
        }

        /// <summary>
        /// Command to host or join a game
        /// </summary>
        public DelegateCommand HostJoinGameCommand { get; private set; }

        /// <summary>
        /// Command to start the actual game
        /// </summary>
        public DelegateCommand StartGameCommand { get; private set; }

        /// <summary>
        /// Function to host a game or join an existing one
        /// </summary>
        private void hostOrJoin()
        {
            if (String.IsNullOrEmpty(_username)) { return; }
            model.Login(UserName);
            var join = model.JoinGame();
            if (!join.Success) {
                Failed?.Invoke(this, join.ErrorMessage);
            }
        }

        /// <summary>
        /// Start a game
        /// </summary>
        private void start()
        {
            model.StartGame();
        }

        //////////////////////////////////////// GameWindow part ////////////////////////////////////////

        /// <summary>
        /// phasestatus to set constraints on interactions
        /// </summary>
        private PhaseStatus _status;

        private PhaseStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                //todo
            }
        }

        /// <summary>
        /// Command to put card on table
        /// </summary>
        public DelegateCommand PutCardCommand { get; private set; }

        /// <summary>
        /// Command to set guessed card
        /// </summary>
        public DelegateCommand GuessCardCommand { get; private set; }

        /// <summary>
        /// Command to send clue sentence
        /// </summary>
        public DelegateCommand SendClueCommand { get; private set; }

        /// <summary>
        /// Cards held in the player's hand
        /// </summary>
        public ObservableCollection<ICard> CardsInHand { get; private set; }

        /// <summary>
        /// Cards currently on the table
        /// </summary>
        public ObservableCollection<ICard> CardsOnTable { get; private set; }


        /// <summary>
        /// Sentence given by the actual player who put the first card.
        /// </summary>
        private String _clueSentence;
        public String ClueSentence
        {
            get{ return _clueSentence; }
            set{
                if (UserName.Equals(ActPlayerName)) {
                    _clueSentence = value;
                    SendClueCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Put own card on table
        /// </summary>
        /// <param name="card"></param>
        private void PutCard(ICard card)
        {
            model.PutCard(card);
        }

        /// <summary>
        /// Set guessed card
        /// </summary>
        /// <param name="card"></param>
        private void GuessCard(ICard card)
        {
            model.GuessCard(card);
        }

        private void SendClue()
        {
            model.sendClue(ClueSentence);
        }

        private void OnGameStateChanged(object sender, GameStateEventArgs e)
        {
            foreach (var point in e.State.Points) {
                foreach (var player in Players) {
                    if (point.Key.Id == player.Id) {
                        player.Score = point.Value;
                        break;
                    }
                }
            }
            OnPropertyChanged("Players");
            
            ActPlayerName = e.State.ActualPlayer.Name;
            OnPropertyChanged("ActPlayerName");

            ClueSentence = e.State.CardAssociationText;
            OnPropertyChanged("ClueSentence");
            CardsOnTable = new ObservableCollection<ICard>();
            CardsInHand = new ObservableCollection<ICard>();
            foreach (var card in e.State.BoardDeck.Cards) {
                CardsOnTable.Add(new Card(card.Id));
            }

            foreach (var hand in e.State.Hands) {
                if (hand.Key.Name.Equals(UserName)) {
                    foreach (var card in hand.Value.Cards) {
                        CardsInHand.Add(new Card(card.Id));
                    }
                    break;
                }
            }


            OnPropertyChanged("CardsOnTable");
            OnPropertyChanged("CardsInHand");
        }

        /// <summary>
        /// sets up initial gamestate when game starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameStart(object sender, GameStateEventArgs e)
        {
            Players = new ObservableCollection<ClientPlayer>();
            CardsOnTable = new ObservableCollection<ICard>();
            CardsInHand = new ObservableCollection<ICard>();

            foreach (var player in e.State.Players) {
                Players.Add(new ClientPlayer(player.Id, player.Name));
            }

            foreach (var card in e.State.BoardDeck.Cards) {
                CardsOnTable.Add(new ClientCard(card.Id));
            }
            
            foreach (var hand in e.State.Hands) {
                if (hand.Key.Name.Equals(UserName)) {
                    foreach (var card in hand.Value.Cards) {
                        CardsInHand.Add(new Card(card.Id));
                    }
                    break;
                }
            }

            ActPlayerName = e.State.ActualPlayer.Name;

            OnPropertyChanged("Players");
            OnPropertyChanged("CardsOnTable");
            OnPropertyChanged("CardsInHand");
            OnPropertyChanged("ActPlayerName");

            StartGame?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// When guessing phase ends, we set visible all cards on the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGuessPhaseEnd(object sender, EventArgs e)
        {
            foreach (var card in CardsOnTable) {
                var cc = card as ClientCard;
                cc.isVisible = true;
            }
            OnPropertyChanged("CardsOnTable");
        }
    }
}
