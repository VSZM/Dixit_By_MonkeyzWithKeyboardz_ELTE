using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dixit_Logic.Interfaces;

namespace Dixit_Client.Model
{
    /// <summary>
    /// Own Card class of Client to store extra details of the card.
    /// </summary>
    public class ClientCard : ICard
    {
        public ClientCard(int id, Boolean isVisible_=false)
        {
            Id = id;
            isVisible = isVisible_;
            players = new HashSet<IPlayer>();
        }

        public int Id
        {
            get
            {
                if (isVisible) { return Id; }
                return 0;
            }

            private set
            {
                Id = value;
            }
        }

        /// <summary>
        /// Indicates if the card content should be visible on the table 
        /// or just the background
        /// </summary>
        public Boolean isVisible { get; set; }
    
        /// <summary>
        /// Set of players who guessed this card was the original one
        /// </summary>
        public HashSet<IPlayer> players { get; set; }
    }
}
