using Dixit_Data.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            
            for(int i = 0; i < names.Count; ++i)
            {
                idsFromNames.Add(Int32.Parse(names[i]));
            }

            // Act
            List<int> ids = ca.GetIDList();
            int a = 2;

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
            Assert.AreEqual(image, imageByFunction);
        }

         List<string> GetNamesWithoutExtensionFromFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string pathOfResources = (path.Substring(0, path.Length - 9)) + "Resources\\";
            string[] files = Directory.GetFiles(pathOfResources);
            List<string> names = new List<string>();

            for(int i = 0; i < files.Length; ++i)
            {
                names.Add(Path.GetFileNameWithoutExtension(files[i]));
            }

            return names;
        }
    }
}
