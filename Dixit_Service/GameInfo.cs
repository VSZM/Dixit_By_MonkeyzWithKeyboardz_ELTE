using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixit_Service
{
    public class GameInfo
    {
        public string GameName;
        public IDixitGame Game;
        public HashSet<UserInfo> Users = new HashSet<UserInfo>();
        public Dictionary<UserInfo, IPlayer> Players = new Dictionary<UserInfo, IPlayer>();
    }
}