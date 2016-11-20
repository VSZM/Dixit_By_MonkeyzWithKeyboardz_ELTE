using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;
using Dixit_ServiceLibrary.DataContracts;

namespace Dixit_ServiceLibrary.Interfaces
{
    public interface IDixitServiceCallback
    {
        /// <summary>
        /// Jelzes a klienseknek, hogy a jatek elindult.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void GameStart(GameState state);
        /// <summary>
        /// Jelzes a klienseknek, hogy jatek allapota megvaltozott.
        /// </summary> 
        /// <param name="player">A soron kovetkezo jatekos.</param>
        [OperationContract(IsOneWay = true)]
        void GameStateChanged(GameState state);
        /// <summary>
        /// Jelzes a klienseknek, hogy a jatek vegetert.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void GameEnd(GameState state);
        /// <summary>
        /// Jelzes a klienseknek, hogy a kartya valasztasi fazis vegetert.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void PuttingPhaseEnd();
        /// <summary>
        /// Jelzes a klienseknek, hogy a tippelesi fazis vegetert.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void GuessPhaseEnd();
    }
}
