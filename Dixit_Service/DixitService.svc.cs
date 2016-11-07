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

namespace Dixit_Service
{
    [ServiceKnownType("RegisterKnownTypes", typeof(DixitService))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class DixitService : IDixitService
    {
        private HashSet<UserInfo> Users = new HashSet<UserInfo>();
        private HashSet<GameInfo> Games = new HashSet<GameInfo>();

        #region Login methods
        public void Login()
        {
            var ui = GetUserInfo();
        }
        public void Logout()
        {
            var ui = GetUserInfo();
            RemoveUser(ui.Username);
        }
        private void RemoveUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) { return; }
            Users.RemoveWhere(x => x.Username == username);
            foreach (var game in Games)
            {
                game.Users.RemoveWhere(x => x.Username == username);
            }
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
        #endregion
        public CreateGameResult CreateGame(string name)
        {
            var r = new CreateGameResult();
            if (!Games.Any(x => x.GameName == name))
            {
                var gi = new GameInfo();
                gi.GameName = name;
                gi.Game = (null as IDixitGame); //TODO
                Games.Add(gi);
                InitGame(gi);
                r.Success = true;
            }
            else
            {
                r.Success = false;
                r.ErrorMessage = "Game already exists.";
            }
            return r;
        }
        private void InitGame(GameInfo gameinfo)
        {
            gameinfo.Game.GameEnd += CurrentGame_GameEnd;
            gameinfo.Game.PuttingPhaseEnd += CurrentGame_PuttingPhaseEnd;
            gameinfo.Game.GuessPhaseEnd += CurrentGame_GuessPhaseEnd;
        }
        public JoinGameResult JoinGame(string name)
        {
            var r = new JoinGameResult();
            try
            {
                var ui = GetUserInfo();
                var gi = GetGameInfo(name);
                if (gi != null)
                {
                    var game = gi.Game;
                    gi.Users.Add(ui);
                    var player = gi.Game.AddPlayer(ui.Username);
                    gi.Players[ui] = player;
                }
            }
            catch (Exception e)
            {
                r.Success = false;
                r.ErrorMessage = e.ToString();
            }
            return r;
        }
        private GameInfo GetGameInfo(string gamename)
        {
            if (string.IsNullOrEmpty(gamename)) { return null; }
            var gi = Games.FirstOrDefault(x => x.GameName == gamename);
            return gi;
        }
        private GameInfo GetGameInfo(UserInfo userinfo)
        {
            if (userinfo == null) { return null; }
            var gi = Games.FirstOrDefault(x => x.Users.Contains(userinfo));
            return gi;
        }
        private GameInfo GetGameInfo(IDixitGame game)
        {
            if (game == null) { return null; }
            var gi = Games.FirstOrDefault(x => x.Game == game);
            return gi;
        }
        private void CurrentGame_PuttingPhaseEnd(object sender, EventArgs e)
        {
            var game = sender as IDixitGame;
            if (game != null)
            {
                var gameinfo = GetGameInfo(game);
                if (gameinfo != null)
                {
                }
            }
        }
        private void CurrentGame_GuessPhaseEnd(object sender, EventArgs e)
        {
            var game = sender as IDixitGame;
            if (game != null)
            {
                var gameinfo = GetGameInfo(game);
                if (gameinfo != null)
                {
                }
            }
        }
        private void CurrentGame_GameEnd(object sender, EventArgs e)
        {
            var game = sender as IDixitGame;
            if (game != null)
            {
                var gameinfo = GetGameInfo(game);
                if (gameinfo != null)
                {
                    var state = game.ActualGameState;
                    foreach (var user in gameinfo.Users)
                    {
                        var callback = user.Callback;
                        callback.GameEnd(state);
                    }
                }
            }
        }

        public void LeaveGame(IDixitGame game)
        {
            throw new NotImplementedException();
        }
        public List<IDixitGame> ListGames()
        {
            throw new NotImplementedException();
        }
        public SelectCardResult SelectCard(IDixitGame game, ICard card)
        {
            throw new NotImplementedException();
        }
        public SelectCardResult SelectCardWithStory(IDixitGame game, ICard card, string story)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<Type> RegisterKnownTypes(ICustomAttributeProvider provider)
        {
            return Dixit_Logic.KnownTypesProvider.GetKnownTypes().Union(GetKnownTypes());
        }
        private static IEnumerable<Type> GetKnownTypes()
        {
            yield break;
        }
    }
}
