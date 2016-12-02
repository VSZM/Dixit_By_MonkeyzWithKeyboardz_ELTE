

using Dixit_Data.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Data
{
    [TestClass]
    public class CardAccessTest
    {
        [TestMethod]
        public void TestGetImageById()
        {
            // Arrange
            Bitmap image = Properties.Resources._1;
            CardAccess ca = new CardAccess();

            // Act
            Bitmap imageByFunction = ca.GetImageById(1);

            // Assert
            Assert.IsNotNull(image);
            Assert.IsNotNull(imageByFunction);
            Assert.AreEqual(image.Size, imageByFunction.Size);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Assert.AreEqual(image.GetPixel(x,y), imageByFunction.GetPixel(x, y));
                }
            }
        }

    }
}
