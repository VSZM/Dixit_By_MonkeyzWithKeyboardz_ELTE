using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Interfaces;

namespace Dixit_Client.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// Event to fire when login failed
        /// </summary>
        /// TODO: use EventHandler that contains the reason of the failure
        public event EventHandler Failed;

        /// <summary>
        /// Event to fire when login was successful
        /// </summary>
        /// TODO: use EventHandler that contains the initial gamestate
        public event EventHandler Success;

        /// <summary>
        /// Collection to store connected players
        /// </summary>
        public ObservableCollection<IPlayer> Players;

        /// <summary>
        /// Function to handle the event of new player joining the game
        /// </summary>
        public void addPlayer(object sender, EventArgs e)
        {
            // Todo : get player from eventargs when we have this type of 
            Players.Add(null);
        }

        /// <summary>
        /// function to host a game
        /// </summary>
        public void host() {
            // todo
        }

        /// <summary>
        /// function to join an existing game
        /// </summary>
        public void join() {
            // todo
        }

        /// <summary>
        /// start a game
        /// </summary>
        public void start()
        {
            if (Players.Count < 3) {
                // todo use EventArgs with string inside it to deliver a reason why it failed
                Failed(this, new EventArgs());
            }
            // todo
        }
    }
}
