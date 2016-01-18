using FineCraft.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Globalization;
using System.Resources;
using Client.Properties;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ResourcesTest" und soll
    ///alle ResourcesTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ResourcesTest
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
        ///Ein Test für "ResourceManager"
        ///</summary>
        [TestMethod()]
        public void ResourceManagerTest1()
        {
            ResourceManager actual;
            actual = Resources.ResourceManager;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Culture"
        ///</summary>
        [TestMethod()]
        public void CultureTest1()
        {
            CultureInfo expected = null; // TODO: Passenden Wert initialisieren
            CultureInfo actual;
            Resources.Culture = expected;
            actual = Resources.Culture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Resources-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void ResourcesConstructorTest1()
        {
            Resources target = new Resources();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "Textures"
        ///</summary>
        [TestMethod()]
        public void TexturesTest()
        {
            Bitmap actual;
            actual = Resources.Textures;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ResourceManager"
        ///</summary>
        [TestMethod()]
        public void ResourceManagerTest()
        {
            ResourceManager actual;
            actual = Resources.ResourceManager;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Culture"
        ///</summary>
        [TestMethod()]
        public void CultureTest()
        {
            CultureInfo expected = null; // TODO: Passenden Wert initialisieren
            CultureInfo actual;
            Resources.Culture = expected;
            actual = Resources.Culture;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "charMap"
        ///</summary>
        [TestMethod()]
        public void charMapTest()
        {
            Bitmap actual;
            actual = Resources.charMap;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Resources-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void ResourcesConstructorTest()
        {
            Resources target = new Resources();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
