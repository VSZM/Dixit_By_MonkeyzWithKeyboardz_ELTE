

using Dixit_Data.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Data
{
    [TestClass]
    public class CardAccessTest
    {
        [TestMethod]
        public void TestGetIDList()
        {
            // Arrange
            CardAccess ca = new CardAccess();
            List<string> names = GetNamesWithoutExtensionFromFile();
            List<int> idsFromNames = new List<int>();

            for (int i = 0; i < names.Count; ++i)
            {
                idsFromNames.Add(Int32.Parse(names[i]));
            }

            // Act
            List<int> ids = ca.GetIDList();

            // Assert
            CollectionAssert.AreEqual(ids, idsFromNames);
        }

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

        List<string> GetNamesWithoutExtensionFromFile()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\Resources\");

            string[] files = Directory.GetFiles(path);
            List<string> names = new List<string>();

            for (int i = 0; i < files.Length; ++i)
            {
                names.Add(Path.GetFileNameWithoutExtension(files[i]));
            }

            return names;
        }
    }
}
