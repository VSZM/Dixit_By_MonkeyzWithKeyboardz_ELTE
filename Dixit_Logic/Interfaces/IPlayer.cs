using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// It is a game player interface. It contains the most necessary properties 
    /// and methods declaration what a player needs during a dixt game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// It is a unique identifier for player.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// The name of the player
        /// </summary>
        string Name
        {
            get;
        }
    }
}
