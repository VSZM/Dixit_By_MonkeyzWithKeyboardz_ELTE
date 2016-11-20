using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dixit_Service.DataContracts
{
    [DataContract]
    public class Card
    {
        public int Id { get; set; }

        public Card() { }
        public Card(int id) { Id = id; }

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