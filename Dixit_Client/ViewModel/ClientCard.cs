using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Interfaces;
using System.Collections.ObjectModel;

namespace Dixit_Client.ViewModel
{
    /// <summary>
    /// Own Card class of Client to store extra details of the card.
    /// </summary>
    public class ClientCard : ViewModelBase, ICard
    {
        public ClientCard(int id, Boolean isVisible_)
        {
            Id = id;
            isVisible = isVisible_;
            Players = new ObservableCollection<int>();
        }

        public int Id
        { get; private set; }

        public int idWithVisibility
        {
            get
            {
                if (isVisible) {
                    return Id;
                }
                return 0;
            }
        }

        /// <summary>
        /// Indicates if the card content should be visible on the table 
        /// or just the background
        /// </summary>
        private Boolean _isVisible;
        public Boolean isVisible {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("isVisible");
                OnPropertyChanged("idWithVisibility");
            }
        }

        /// <summary>
        /// Set of players who guessed this card was the original one
        /// </summary>
        public ObservableCollection<int> Players { get; private set; }

        public void AddGuessingPlayer(int player)
        {
            if (!Players.Contains(player)) {
                Players.Add(player);
                OnPropertyChanged("Players");
            }
        }
    }
}
