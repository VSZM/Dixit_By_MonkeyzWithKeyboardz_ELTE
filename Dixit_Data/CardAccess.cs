using Dixit_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Images;

namespace Dixit_Data
{
    /// <summary>
    /// This class gives the ids of the images 
    /// and gives an image by its id.
    /// </summary>
    class CardAccess : ICardAccess
    {
        /// <summary>
        /// Get the ids of images in a list.
        /// </summary>
        /// <returns>ids of images</returns>
        List<int> ICardAccess.GetIDList()
        {
            List<int> ids = new List<int>();

            for(int i = 1; i < 3; ++i)
            {
                ids.Add(i);
            }

            return ids;
        }

        /// <summary>
        /// Get the image by its id.
        /// </summary>
        /// <param name="id">id of an image</param>
        /// <returns>image</returns>
        Bitmap ICardAccess.GetImageById(int id)
        {
            return Images.ImagesDll.GetImageById(id);
        }
    }
}
