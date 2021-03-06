﻿using Dixit_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Dixit_Data.Properties;
using System.Resources;
using System.Globalization;
using System.Collections;

namespace Dixit_Data
{
    /// <summary>
    /// Loads images for cards.
    /// </summary>
    public class CardAccess : ICardAccess
    {
        /// <summary>
        /// Gets ids in a list.
        /// </summary>
        /// <returns></returns>
        public List<int> GetIDList()
        {
            List<int> tempList = new List<int>();
            ResourceManager rm = Properties.Resources.ResourceManager;
            ResourceSet resourceSet = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                try {
                    int idName = Int32.Parse(resourceKey);
                    tempList.Add(idName);
                } catch (FormatException) { }
            }

            return tempList;
        }

        /// <summary>
        /// Gets an imaage by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bitmap GetImageById(int id)
        {
            return (Bitmap)Resources.ResourceManager.GetObject(id.ToString());
        }

        /// <summary>
        /// Gets the back image of card.
        /// </summary>
        /// <returns></returns>
        public Bitmap GetCardBack()
        {
            return (Bitmap)Resources.ResourceManager.GetObject("cardback");
        }
    }
}
