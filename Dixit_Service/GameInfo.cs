using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dixit_Service
{
    public class GameInfo
    {
        public IDixitGame Game;
        public Dictionary<UserInfo, IPlayer> Players = new Dictionary<UserInfo, IPlayer>();

        public void AddPlayer(UserInfo ui)
        {
            if (ui == null) { return; }

            var player = Game.AddPlayer(ui.Username);
            if (player != null)
            {
                Players[ui] = player;
            }
        }
        public void RemovePlayer(UserInfo ui)
        {

        }
    }
}