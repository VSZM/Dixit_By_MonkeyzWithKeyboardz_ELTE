using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_ServiceLibrary.DataContracts
{
    [DataContract]
    public class GameState
    {
        public GameState() { }

        public GameState(IGameState igamestate)
        {

        }

        public GameState ToPlayerState(IPlayer player)
        {
            return this;
        }
    }
}
