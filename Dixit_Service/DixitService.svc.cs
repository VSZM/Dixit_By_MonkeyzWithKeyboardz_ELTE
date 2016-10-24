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
        private Dictionary<string, UserInfo> Users = new Dictionary<string, UserInfo>();
        //private Dictionary<string, IDixitGame> Games = new Dictionary<string, IDixitGame>();
        private IDixitGame Game;

        #region Login methods
        public void Login()
        {
            var ui = new UserInfo();
            ui.Username = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            ui.Callback = OperationContext.Current.GetCallbackChannel<IDixitServiceCallback>();
            Users.Add(ui.Username, ui);
        }
        public void Logout()
        {
            RemoveUser(OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
        }
        private void RemoveUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) { return; }

            if (Users.ContainsKey(username))
            {
                Users.Remove(username);
            }
        }
        #endregion
        public CreateGameResult CreateGame(string name)
        {
            var r = new CreateGameResult();
            //r.Games = 
            return r;
        }
        public JoinGameResult JoinGame(IDixitGame game)
        {
            throw new NotImplementedException();
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
            return Dixit_Logic.KnownTypesProvider.GetKnownTypes();
        }
    }
}
