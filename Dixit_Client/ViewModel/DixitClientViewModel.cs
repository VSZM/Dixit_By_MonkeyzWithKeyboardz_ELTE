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
            model.GameEndEvent += new EventHandler<GameStateEventArgs>(OnGameEnd);
            model.GameStartEvent += new EventHandler<GameStateEventArgs>(OnGameStart);
            model.GameStateChangedEvent += new EventHandler<GameStateEventArgs>(OnGameStateChanged);
            model.PuttingPhaseEndEvent += new EventHandler(OnPutPhaseEnd);
            model.GuessPhaseEndEvent += new EventHandler(OnGuessPhaseEnd);
            HostJoinGameCommand = new DelegateCommand(_ => !String.IsNullOrEmpty(UserName), _ => hostOrJoin());
            StartGameCommand = new DelegateCommand(_ => start());
            PutCardCommand = new DelegateCommand(_ => Status.Equals(PhaseStatus.Putting), param => PutCard((Card)param));
            GuessCardCommand  = new DelegateCommand(_ => Status.Equals(PhaseStatus.Guessing), param => GuessCard((ICard)param));
            SendClueCommand = new DelegateCommand(_ => UserName.Equals(ActPlayerName) 
                                                       && !String.IsNullOrEmpty(ClueSentence)
                                                       && Status.Equals(PhaseStatus.AssociationTelling),
                                                  _ => SendClue());
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


        public event EventHandler<String> GameEndEvent;
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
                PutCardCommand.RaiseCanExecuteChanged();
                GuessCardCommand.RaiseCanExecuteChanged();
                SendClueCommand.RaiseCanExecuteChanged();
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
            get { return _clueSentence; }
            set {
                if (UserName.Equals(ActPlayerName) && Status.Equals(PhaseStatus.AssociationTelling)) {
                    _clueSentence = value;
                    SendClueCommand.RaiseCanExecuteChanged();
                    OnPropertyChanged("ClueSentence");
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

        /// <summary>
        /// Sending new cluesentence for the model
        /// </summary>
        private void SendClue()
        {
            model.sendClue(ClueSentence);
        }

        /// <summary>
        /// update the client gamestate to correspond the actual gamestate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameStateChanged(object sender, GameStateEventArgs e)
        {
            Status = e.State.RoundStatus;
            if (Status.Equals(PhaseStatus.BeforeStart)) {
                Players.Clear();
                foreach (var player in e.State.Players) {
                    Players.Add(new ClientPlayer(player.Id, player.Name));
                }
                OnPropertyChanged("Players");
                return;
            }
            foreach (var point in e.State.Points) {
                foreach (var player in Players) {
                    if (point.Key.Id.Equals(player.Id)) {
                        player.Score = point.Value;
                        break;
                    }
                }
            }
            OnPropertyChanged("Players");
            
            ActPlayerName = e.State.ActualPlayer.Name;
            OnPropertyChanged("ActPlayerName");

            _clueSentence = e.State.CardAssociationText;
            OnPropertyChanged("ClueSentence");
            CardsOnTable = new ObservableCollection<ICard>();
            CardsInHand = new ObservableCollection<ICard>();
            foreach (var card in e.State.BoardDeck.Cards) {
                CardsOnTable.Add(new ClientCard(card.Id, !Status.Equals(PhaseStatus.Putting)));
            }

            foreach (var hand in e.State.Hands) {
                if (hand.Key.Name.Equals(UserName)) {
                    foreach (var card in hand.Value.Cards) {
                        CardsInHand.Add(new Card(card.Id));
                    }
                    break;
                }
            }

            foreach (var guess in e.State.Guesses) {
                foreach (var card in CardsOnTable) {
                    if (guess.Value.Id.Equals(card.Id)) {
                        ((ClientCard)card).AddGuessingPlayer(guess.Key.Id);
                    }
                }
            }
            
            OnPropertyChanged("CardsOnTable");
            OnPropertyChanged("CardsInHand");
        }

        /// <summary>
        /// Event handler for game ending
        /// </summary>
        private void OnGameEnd(object sender, GameStateEventArgs e)
        {
            GameEndEvent?.Invoke(this, "Game over");
        }

        /// <summary>
        /// sets up initial gamestate when game starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameStart(object sender, GameStateEventArgs e)
        {
            Status = e.State.RoundStatus;
            Players = new ObservableCollection<ClientPlayer>();
            CardsOnTable = new ObservableCollection<ICard>();
            CardsInHand = new ObservableCollection<ICard>();

            foreach (var player in e.State.Players) {
                Players.Add(new ClientPlayer(player.Id, player.Name));
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
        private void OnPutPhaseEnd(object sender, EventArgs e)
        {
            foreach (ClientCard card in CardsOnTable) {
                card.isVisible = true;
            }
            OnPropertyChanged("CardsOnTable");
        }

        /// <summary>
        /// Eventhandler for guessphase end
        /// fire property changed event to show who
        /// guessed which card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGuessPhaseEnd(object sender, EventArgs e) {
            OnPropertyChanged("CardsOnTable");
        }
    }
}
