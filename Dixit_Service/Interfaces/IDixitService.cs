using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dixit_Logic.Interfaces;
using Dixit_Service;

namespace Dixit_ServiceLibrary.Interfaces
{
    [ServiceKnownType("RegisterKnownTypes", typeof(DixitService))]
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
        /// <summary>
        /// Aktualis jatekok lekerdezese.
        /// </summary>
        /// <returns>Jatek lista.</returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        List<IDixitGame> ListGames();
        /// <summary>
        /// Jatek letrehozasa.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        CreateGameResult CreateGame(string name);
        /// <summary>
        /// Csatlakozas a jatekhoz.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        JoinGameResult JoinGame(string gamename);
        /// <summary>
        /// Jatek elhagyasa.
        /// </summary>
        /// <param name="game">Az elhagyando jatek.</param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void LeaveGame(IDixitGame game);
        #endregion game operations

        #region in-game operations
        /// <summary>
        /// A tortenet es a kezdokartya meghatarozasahoz.
        /// </summary>
        /// <param name="game">Az aktualis jatek.</param>
        /// <param name="card">A valasztando kartya.</param>
        /// <param name="story">A kartyahoz tartozo tortenet.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        SelectCardResult SelectCardWithStory(IDixitGame game, ICard card, string story);
        /// <summary>
        /// A jatekos sajat kartyai kozul valo valasztashoz, valamint a tortenethez legjobban hasonlito kartya valasztasahoz.
        /// </summary>
        /// <param name="game">Az aktualis jatek.</param>
        /// <param name="card">A valasztando kartya.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        SelectCardResult SelectCard(IDixitGame game, ICard card);
        #endregion in-game operations

    }
    public class CreateGameResult
    {
        public IDixitGame Game;
        public bool Success;
        public string ErrorMessage;
    }
    public class JoinGameResult
    {
        public bool Success = true;
        public string ErrorMessage;
    }
    public class SelectCardResult
    {
        public bool Success = true;
        public string ErrorMessage;
    }
}
