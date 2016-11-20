using Dixit_Logic.Interfaces;
using Dixit_Service.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_ServiceLibrary.DataContracts
{
    [DataContract]
    public class Deck
    {
        public List<Card> Cards { get; internal set; } = new List<Card>();

        public Deck() { }
        public Deck(IDeck ideck)
        {
            if (ideck == null) { return; }
            foreach (var icard in ideck.Cards)
            {
                Cards.Add(new Card(icard));
            }       
        }
    }
}
