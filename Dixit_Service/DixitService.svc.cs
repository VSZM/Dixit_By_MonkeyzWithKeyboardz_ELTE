using Dixit_ServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dixit_Logic.Interfaces;
using System.Reflection;
using Dixit_Service.DataContracts;
using Dixit_ServiceLibrary.DataContracts;
using Dixit.Injectors;

namespace Dixit_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class DixitService : IDixitService
    {
        private HashSet<UserInfo> Users = new HashSet<UserInfo>();
        private GameInfo GameInfo;
        private IDixitGame CurrentGame { get { return GameInfo?.Game; } }

        #region login methods
        public void Login(string username)
        {
            CreateUserInfo(username);
        }
        public void Logout()
        {
            var ui = GetUserInfo();
            RemoveUser(ui);
        }
        private void RemoveUser(UserInfo ui)
        {
            if (ui == null) { return; }

            Users.Remove(ui);
            if (GameInfo != null) { GameInfo.RemovePlayer(ui); }
        }
        private void CreateUserInfo(string username)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IDixitServiceCallback>();
            var ui = Users.FirstOrDefault(x => x.Callback == callback);
            if (ui == null)
            {
                ui = new UserInfo();
                ui.Username = username;
                ui.Callback = callback;
                Users.Add(ui);
            }
        }
        private UserInfo GetUserInfo()
        {
            //UserInfo ui = null;
            //var username = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            var callback = OperationContext.Current.GetCallbackChannel<IDixitServiceCallback>();
            return Users.FirstOrDefault(x => x.Callback == callback);
        }
        private IPlayer GetPlayer()
        {
            var ui = GetUserInfo();
            return GetPlayer(ui);
        }
        private IPlayer GetPlayer(UserInfo ui)
        {
            if (ui == null) { return null; }
            IPlayer player = null;
            if (GameInfo.Players.TryGetValue(ui, out player))
            {
                return player;
            }
            return null;
        }
        #endregion login methods

        #region game methods
        public JoinGameResult JoinGame()
        {
            var ui = GetUserInfo();
            var r = new JoinGameResult();
            if (GameInfo == null)
            {
                CreateGame();
                GameInfo.AddPlayer(ui);
                r.Success = true;
            }
            else
            {
                if (CurrentGame.ActualGameState.GameIsRuning)
                {
                    r.Success = false;
                    r.ErrorMessage = "Game is running";
                    return r;
                }
                GameInfo.AddPlayer(ui);
                r.Success = true;
            }
            return r;
        }
        private void CreateGame()
        {
            var r = LogicInjector.Container.GetInstance<IDixitGame>();
            GameInfo = new GameInfo();
            GameInfo.Game = r;
            var state = r.ActualGameState;
            GameInfo.Cards = state.BaseCards.ToDictionary(c => Card.Get(c.Id), c => c);
            r.GameEnd += CurrentGame_GameEnd;
            r.PuttingPhaseEnd += CurrentGame_PuttingPhaseEnd;
            r.GuessPhaseEnd += CurrentGame_GuessPhaseEnd;
        }
        public void StartGame()
        {
            if (CurrentGame == null) { return; }
            if (CurrentGame.StartGame())
            {
                var gamestate = GetGameState();
                foreach (var ui in GameInfo.Players.Keys)
                {
                    var playerstate = gamestate.ToPlayerState(GetPlayer(ui));
                    ui.Callback.GameStart(playerstate);
                }
            }
        }
        public void LeaveGame()
        {
            if (CurrentGame == null) { return; }
            var ui = GetUserInfo();
            var player = GameInfo.Players[ui];
            CurrentGame.RemovePlayer(player);
        }
        #endregion game methods

        #region in-game methods
        public void AddAssociationText(string story)
        {
            if (CurrentGame == null) { return; }
            var player = GetPlayer();
            CurrentGame.AddAssociationText(story, player);
            var gamestate = CurrentGame.ActualGameState;
            GameStateChanged();
        }
        public void PutCard(Card card)
        {
            if (CurrentGame == null) { return; }
            var player = GetPlayer();
            CurrentGame.PutCard(player, GetCard(card));
            var gamestate = CurrentGame.ActualGameState;
            GameStateChanged();
        }
        public void NewGuess(Card card)
        {
            if (CurrentGame == null) { return; }
            var player = GetPlayer();
            CurrentGame.NewGuess(player, GetCard(card));
            GameStateChanged();
        }
        private void CurrentGame_GuessPhaseEnd(object sender, EventArgs e)
        {
            foreach (var ui in GameInfo.Players.Keys)
            {
                ui.Callback.GuessPhaseEnd();
            }
        }
        private void CurrentGame_PuttingPhaseEnd(object sender, EventArgs e)
        {
            foreach (var ui in GameInfo.Players.Keys)
            {
                ui.Callback.PuttingPhaseEnd();
            }
        }
        private void CurrentGame_GameEnd(object sender, EventArgs e)
        {
            var gamestate = GetGameState();
            foreach (var ui in GameInfo.Players.Keys)
            {
                var playerstate = gamestate.ToPlayerState(GetPlayer(ui));
                ui.Callback.GameEnd(playerstate);
            }
        }
        #endregion in-game methods
        private void GameStateChanged()
        {
            var gamestate = GetGameState();
            foreach (var ui in GameInfo.Players.Keys)
            {
                var playerstate = gamestate.ToPlayerState(GetPlayer(ui));
                ui.Callback.GameStateChanged(playerstate);
            }
        }
        private ICard GetCard(int id)
        {
            ICard card = null;
            if (GameInfo.Cards.TryGetValue(Card.Get(id), out card))
            {
                return card;
            }
            return null;
        }
        private ICard GetCard(Card card)
        {
            return GetCard(card.Id);
        }
        private GameState GetGameState()
        {
            if (CurrentGame == null) { return null; }
            var state = new GameState(CurrentGame.ActualGameState);
            return state;
        }
    }
}
