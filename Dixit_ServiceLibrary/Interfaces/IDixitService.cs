using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dixit_Logic.Interfaces;
using Dixit_Service.DataContracts;
using Dixit_ServiceLibrary.DataContracts;

namespace Dixit_ServiceLibrary.Interfaces
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
        /// Csatlakozas a jatekhoz.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        JoinGameResult JoinGame();
        /// <summary>
        /// Jatek elinditasa.
        /// </summary>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void StartGame();
        /// <summary>
        /// Jatek elhagyasa.
        /// </summary>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void LeaveGame();
        #endregion game operations

        #region in-game operations
        /// <summary>
        /// A kartyahoz tarsitott tortenet megadas.
        /// </summary>
        /// <param name="card">A tortenet szoveg.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void AddAssociationText(string story);
        /// <summary>
        /// A tortenet es a kezdokartya meghatarozasahoz.
        /// </summary>
        /// <param name="card">A valasztando kartya.</param>
        /// <param name="story">A kartyahoz tartozo tortenet.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void NewGuess(Card card);
        /// <summary>
        /// A jatekos sajat kartyai kozul valo valasztashoz, valamint a tortenethez legjobban hasonlito kartya valasztasahoz.
        /// </summary>
        /// <param name="card">A valasztando kartya.</param>
        /// <returns></returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void PutCard(Card card);
        #endregion in-game operations
    }

}
