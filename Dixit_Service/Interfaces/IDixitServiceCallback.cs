using Dixit_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Service
{
    public interface IDixitServiceCallback
    {
        /// <summary>
        /// m:161005: Jelzes a klienseknek, hogy a jatek elindult.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void CurrentGameStart();
        /// <summary>
        /// m:161005: Jelzes a klienseknek, hogy a jatek vegetert;
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void CurrentGameEnd();
        /// <summary>
        /// m:161005: Jelzes a klienseknek, hogy soron kovetkezo jatekos megvaltozott.
        /// </summary> 
        /// <param name="player">A soron kovetkezo jatekos.</param>
        [OperationContract(IsOneWay = true)]
        void CurrentPlayerChanged(Player player);
    }
}
