using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dixit_Logic.Interfaces
{
    /// <summary>
    /// This interface loads the images for the cards.
    /// </summary>
    public interface IImageAccess
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
