using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class represent a game player. A Player object has a unique identifier 
    /// and a name. This attributes cannot be changed after the object is constructed.
    /// </summary>
    class Player : IPlayer
    {
        /// <summary>
        /// The identifier counter. This garant that every player
        /// has a unique identifier.
        /// </summary>
        private static int _newId = 1000;

        /// <summary>
        /// Store the identifier.
        /// </summary>
        private int _id;

        /// <summary>
        /// Store the name of the player
        /// </summary>
        private string _name;

        /// <summary>
        /// Construct a player with the given name and 
        /// assign a unique identifier to it.
        /// </summary>        
        /// <param name="name">Player name</param>
        public Player(string name)
        {
            _id = _newId++;
            _name = name;
        }

        /// <summary>
        /// Give back the player identifier.
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Give back the player name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Compare a Player object with another object to determine they are equal or not.
        /// Compare two Palyer objects basd on their names and identifieres.
        /// </summary>
        /// <param name="obj">Another object</param>
        /// <returns>If the player equals with obj than return true otherwise return flase</returns>
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Player p = (Player)obj;
            return (_id == p._id) && (_name == p._name);
        }

        /// <summary>
        /// Make a hash code basd on the identifier and name has code.
        /// </summary>
        /// <returns>A hash code</returns>
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _id.GetHashCode() ^ _name.GetHashCode();
        }
    }
}
