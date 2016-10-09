using Dixit_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dixit_Service
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDixitServiceCallback))]
    public interface IDixitService
    {
        #region login operations
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void Login();
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void Logout();
        #endregion login operations

        #region game operations
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Game[] ListGames();
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        CreateGameResult CreateGame(string name);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        JoinGameResult JoinGame(Game game);
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void LeaveCurrentGame();
        #endregion game operations

        #region in-game operations

        #endregion in-game operations

    }
    public class CreateGameResult
    {
        public Game Game;
        public bool Success;
        public string ErrorMessage;
    }
    public class JoinGameResult
    {
        public bool Success;
        public string ErrorMessage;
    }
}
