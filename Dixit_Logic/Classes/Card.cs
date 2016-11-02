using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Interfaces;
using System.Drawing;

namespace Dixit_Logic.Classes
{
    /// <summary>
    /// This class a structure of a gamecard. A Card object will store an image and an unique
    /// indentifier. This values only assigned by the constructor. The image and the identifier
    /// cannot be changed after an object is constructed.
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        ///  The card indentifier
        /// </summary>
        private int _id;

        /// <summary>
        /// The image of the card
        /// </summary>
        Bitmap _image;

        /// <summary>
        /// Construct a card with the given id and image
        /// </summary>
        /// <param name="id">card indentifier</param>
        /// <param name="image">card image</param>
        public Card(int id, Bitmap image)
        {
            _id = id;
            _image = image;
        }

        /// <summary>
        /// Return with the card identifier what stores in _id
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            
        }

        /// <summary>
        /// Return with the card image what stores in _image
        /// </summary>
        public Bitmap Image
        {
            get
            {
                return _image;
            }
        }

        /// <summary>
        /// The equals method depending on the _id only because the id determines
        /// the bitmap image.
        /// </summary>
        /// <param name="obj">the compared object</param>
        /// <returns>the bool value of result of comparing</returns>
        // override object.Equals
        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Card c = (Card)obj;
            return _id == c._id;
        }


        /// <summary>
        /// The new hash code generted form the card id has codes.
        /// </summary>
        /// <returns>hash code int</returns>
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
