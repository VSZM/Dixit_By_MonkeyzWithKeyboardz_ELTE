using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Interfaces;

namespace Dixit_Client.ViewModel
{

    /// <summary>
    /// Viewmodel class to maintain the interaction between the view and the game logic
    /// </summary>
    class DixitClientViewModel : ViewModelBase
    {
        /// <summary>
        /// Cards held in the player's hand
        /// </summary>
        public ObservableCollection<ICard> CardsInHand { get; private set; }

        /// <summary>
        /// Cards currently on the table
        /// </summary>
        public ObservableCollection<ICard> CardsOnTable { get; private set; }


        /// <summary>
        /// Players' info
        /// </summary>
        public ObservableCollection<IPlayer> Players { get; private set; }


        /// <summary>
        /// Sentence given by the actual player who put the first card.
        /// </summary>
        public String ClueSentence { get; private set; }

        public int asd { get; set; }

        public DixitClientViewModel()
        {
            asd = 1;
        }
    }
}
