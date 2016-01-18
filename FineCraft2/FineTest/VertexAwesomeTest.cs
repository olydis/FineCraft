using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "VertexAwesomeTest" und soll
    ///alle VertexAwesomeTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class VertexAwesomeTest
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
        ///Ein Test für "VertexElements"
        ///</summary>
        [TestMethod()]
        public void VertexElementsTest()
        {
            VertexElement[] actual;
            actual = VertexAwesome.VertexElements;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SizeInBytes"
        ///</summary>
        [TestMethod()]
        public void SizeInBytesTest()
        {
            int actual;
            actual = VertexAwesome.SizeInBytes;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "VertexAwesome-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void VertexAwesomeConstructorTest()
        {
            byte color = 0; // TODO: Passenden Wert initialisieren
            Vector3 position = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 normal = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector2 textureCoordinate = new Vector2(); // TODO: Passenden Wert initialisieren
            VertexAwesome target = new VertexAwesome(color, position, normal, textureCoordinate);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
