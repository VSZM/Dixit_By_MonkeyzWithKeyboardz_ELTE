using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dixit_Service.DataContracts
{
    [DataContract]
    public class Card : ICard
    {
        [DataMember]
        public int Id { get; set; }

        public Card() { }
        public Card(int id) { Id = id; }
        public Card(ICard icard)
        {
            if (icard == null) { return; }

            this.Id = icard.Id;
        }

        public static Card Get(int id) { return new Card(id); }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            if (card != null)
            {
                if (card.Id == this.Id)
                {
                    return true;
                }
            }
            return base.Equals(obj);
        }
        public override int GetHashCode() { return 0; }
    }
}