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
        /// <summary>
        /// Aktualis jatekok lekerdezese.
        /// </summary>
        /// <returns>Jatek lista.</returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Game[] ListGames();
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
        JoinGameResult JoinGame(Game game);
        /// <summary>
        /// Jatek elhagyasa.
        /// </summary>
        /// <param name="game">Az elhagyando jatek.</param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void LeaveGame(Game game);
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
        SelectCardResult SelectCardWithStory(Game game, Card card, string story);
        /// <summary>
        /// A jatekos sajat kartyai kozul valo valasztashoz, valamint a tortenethez legjobban hasonlito kartya valasztasahoz.
        /// </summary>
        /// <param name="game">Az aktualis jatek.</param>
        /// <param name="card">A valasztando kartya.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        SelectCardResult SelectCard(Game game, Card card);
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
    public class SelectCardResult
    {
        public bool Success;
        public string ErrorMessage;
    }
}
