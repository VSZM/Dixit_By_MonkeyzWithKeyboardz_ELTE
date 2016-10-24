using System.Collections.Generic;
using System.Drawing;

namespace Dixit_Data.Interfaces
{
    /// <summary>
    /// This interface loads the images for the cards.
    /// </summary>
    public interface ICardAccess
    {
        /// <summary>
        /// Get the ids of images in a list.
        /// </summary>
        /// <returns>ids of images</returns>
        List<int> GetIDList();

        /// <summary>
        /// Get the image by its id.
        /// </summary>
        /// <param name="id">id of an image</param>
        /// <returns>image</returns>
        Bitmap GetImageById(int id);       
    }
}
