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
        /// Model instance to get interaction with the game logic.
        /// </summary>
        private Model.Model model;

        /// <summary>
        /// Players' info
        /// </summary>
        public ObservableCollection<ClientPlayer> Players { get; private set; }

        public DixitClientViewModel()
        {
            //UserName = null;
            Players = new ObservableCollection<ClientPlayer>();
            model = new Model.Model();
            model.LoginFailedEvent += new EventHandler<Exception>(OnLoginFailed);
            model.LoginSuccessEvent += new EventHandler<String>(OnLoginSuccess);
            model.GameStartEvent += new EventHandler<GameStateEventArgs>(OnGameStart);
            model.GameStateChangedEvent += new EventHandler<GameStateEventArgs>(OnGameStateChanged);
            HostJoinGameCommand = new DelegateCommand(_ => !String.IsNullOrEmpty(UserName), param => hostOrJoin());
            StartGameCommand = new DelegateCommand(param => start());
            SelectCardCommand = new DelegateCommand(param => SelectCard((int)param));
        }


        //////////////////////////////////////// LoginWindow part ////////////////////////////////////////

        /// <summary>
        /// Event to fire when login failed
        /// </summary>
        /// TODO: use EventHandler that contains the reason of the failure
        public event EventHandler<String> Failed;

        /// <summary>
        /// Event to fire when login was successful
        /// </summary>
        /// TODO: use EventHandler that contains the initial gamestate
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
            //if (Players.Count < 3) { return; }
            StartGame?.Invoke(this, EventArgs.Empty);
        }




        //////////////////////////////////////// GameWindow part ////////////////////////////////////////

        /// <summary>
        /// Command to set selected card
        /// </summary>
        public DelegateCommand SelectCardCommand { get; private set; }

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
        public String ClueSentence { get; private set; }

        private void SelectCard(int id)
        {
            // call some function in the model to tell which card is selected
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

        private void OnGameStart(object sender, GameStateEventArgs e)
        {
            Players = new ObservableCollection<ClientPlayer>();
            CardsOnTable = new ObservableCollection<ICard>();
            CardsInHand = new ObservableCollection<ICard>();

            foreach (var player in e.State.Players) {
                Players.Add(new ClientPlayer(player.Id, player.Name));
            }

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

            OnPropertyChanged("Players");
            OnPropertyChanged("CardsOnTable");
            OnPropertyChanged("CardsInHand");

        }
    }
}
