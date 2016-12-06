using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Classes;

namespace Dixit_Client.Model
{
    public class ClientPlayer
    {
        public ClientPlayer(int id, String name)
        {
            Id = id;
            Name = name;
            Score = 0;
        }
        public int Score { get; set; }

        public int Id { get; private set; }
        public String Name { get; }
    }
}
