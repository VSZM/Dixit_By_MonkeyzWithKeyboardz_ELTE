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
using Dixit.Common;
using Dixit_ServiceLibrary.DataContracts;

namespace Dixit_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class DixitService : IDixitService
    {
        private HashSet<UserInfo> Users = new HashSet<UserInfo>();
        private GameInfo GameInfo;
        private IDixitGame CurrentGame { get { return GameInfo?.Game; } }

        #region login methods
        public void Login()
        {
            GetUserInfo();
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
        private UserInfo GetUserInfo()
        {
            UserInfo ui = null;
            var username = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            if (!Users.Any(x => x.Username == username))
            {
                ui = new UserInfo();
                ui.Username = username;
                ui.Callback = OperationContext.Current.GetCallbackChannel<IDixitServiceCallback>();
                Users.Add(ui);
            }
            return ui;
        }
        #endregion login methods

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
                //if (CurrentGame.MaxPlayerCount > CurrentGame.PlayerCount) //TODO
                {
                    GameInfo.AddPlayer(ui);
                    r.Success = true;
                }
            }
            return r;
        }
        private void CreateGame()
        {
            var r = Injector.Container.GetInstance<IDixitGame>();
            GameInfo = new GameInfo();
            GameInfo.Game = r;
            r.GameEnd += CurrentGame_GameEnd;
            r.PuttingPhaseEnd += CurrentGame_PuttingPhaseEnd;
            r.GuessPhaseEnd += CurrentGame_GuessPhaseEnd;
        }
        private void CurrentGame_GuessPhaseEnd(object sender, EventArgs e)
        {
            var ui = GetUserInfo();
            foreach (var player in GameInfo.Players.Keys)
            {

            }
        }
        private void CurrentGame_PuttingPhaseEnd(object sender, EventArgs e)
        {
            var ui = GetUserInfo();
            foreach (var player in GameInfo.Players.Keys)
            {

            }

        }
        private void CurrentGame_GameEnd(object sender, EventArgs e)
        {
            var state = new GameState();
            foreach (var player in GameInfo.Players.Keys)
            {
                player.Callback.GameEnd(state);
            }
        }
        public void LeaveGame()
        {
            if (CurrentGame == null) { return; }
            var ui = GetUserInfo();
            var player = GameInfo.Players[ui];
            //CurrentGame.RemovePlayer(player); //TODO
        }
        public SelectCardResult SelectCard(Card card)
        {
            var r = new SelectCardResult();
            if (CurrentGame == null) { return r; }
            //GameInfo.Game.PutCard(
            return r;
        }
        public SelectCardResult SelectCardWithStory(Card card, string story)
        {
            var r = new SelectCardResult();
            if (CurrentGame == null) { return r; }

            return r;
        }
    }
}
