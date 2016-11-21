using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Classes;

namespace Dixit_Client.Model
{
    public class ClientPlayer : Player
    {
        public ClientPlayer(string name) : base(name)
        {
            Score = 0;
        }

        public int Score { get; set; }
    }
}
