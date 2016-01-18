using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GraphicsHelperTest" und soll
    ///alle GraphicsHelperTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GraphicsHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "TextureCoord"
        ///</summary>
        [TestMethod()]
        public void TextureCoordTest()
        {
            uint index = 0; // TODO: Passenden Wert initialisieren
            Vector2 expected = new Vector2(); // TODO: Passenden Wert initialisieren
            Vector2 actual;
            actual = GraphicsHelper.TextureCoord(index);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Init"
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            GraphicsDevice gd = null; // TODO: Passenden Wert initialisieren
            GraphicsHelper.Init(gd);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "GetIconInfo"
        ///</summary>
        [TestMethod()]
        public void GetIconInfoTest()
        {
            IntPtr hIcon = new IntPtr(); // TODO: Passenden Wert initialisieren
            GraphicsHelper.IconInfo pIconInfo = new GraphicsHelper.IconInfo(); // TODO: Passenden Wert initialisieren
            GraphicsHelper.IconInfo pIconInfoExpected = new GraphicsHelper.IconInfo(); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = GraphicsHelper.GetIconInfo(hIcon, ref pIconInfo);
            Assert.AreEqual(pIconInfoExpected, pIconInfo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CreateIconIndirect"
        ///</summary>
        [TestMethod()]
        public void CreateIconIndirectTest()
        {
            GraphicsHelper.IconInfo icon = new GraphicsHelper.IconInfo(); // TODO: Passenden Wert initialisieren
            GraphicsHelper.IconInfo iconExpected = new GraphicsHelper.IconInfo(); // TODO: Passenden Wert initialisieren
            IntPtr expected = new IntPtr(); // TODO: Passenden Wert initialisieren
            IntPtr actual;
            actual = GraphicsHelper.CreateIconIndirect(ref icon);
            Assert.AreEqual(iconExpected, icon);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Convert"
        ///</summary>
        [TestMethod()]
        public void ConvertTest1()
        {
            Bitmap b = null; // TODO: Passenden Wert initialisieren
            GraphicsDevice gd = null; // TODO: Passenden Wert initialisieren
            Texture2D expected = null; // TODO: Passenden Wert initialisieren
            Texture2D actual;
            actual = GraphicsHelper.Convert(b, gd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Convert"
        ///</summary>
        [TestMethod()]
        public void ConvertTest()
        {
            Bitmap b = null; // TODO: Passenden Wert initialisieren
            int centerX = 0; // TODO: Passenden Wert initialisieren
            int centerY = 0; // TODO: Passenden Wert initialisieren
            Cursor expected = null; // TODO: Passenden Wert initialisieren
            Cursor actual;
            actual = GraphicsHelper.Convert(b, centerX, centerY);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
