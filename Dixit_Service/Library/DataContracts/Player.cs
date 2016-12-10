using Dixit_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_ServiceLibrary.DataContracts
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; internal set; }
        [DataMember]
        public string Name { get; internal set; }

        public Player() { }
        public Player(IPlayer iplayer)
        {
            if (iplayer == null) { return; }

            this.Id = iplayer.Id;
            this.Name = iplayer.Name;
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            if (player != null)
            {
                if (player.Id == this.Id)
                {
                    return true;
                }
            }
            return base.Equals(obj);
        }
        public override int GetHashCode() { return 0; }
    }
}
