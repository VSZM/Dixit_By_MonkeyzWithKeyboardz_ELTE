using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Service
{
    public interface IDixitServiceCallback
    {
        /// <summary>
        /// Jelzes a klienseknek, hogy a jatek elindult.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void GameStart(IGameState state);
        /// <summary>
        /// Jelzes a klienseknek, hogy jatek allapota megvaltozott.
        /// </summary> 
        /// <param name="player">A soron kovetkezo jatekos.</param>
        [OperationContract(IsOneWay = true)]
        void GameStateChanged(IGameState state);
        /// <summary>
        /// Jelzes a klienseknek, hogy a jatek vegetert.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void GameEnd(IGameState state);
    }
}
