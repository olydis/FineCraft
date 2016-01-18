using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AwesomeMeshTest" und soll
    ///alle AwesomeMeshTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AwesomeMeshTest
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
        ///Ein Test für "Mesh"
        ///</summary>
        [TestMethod()]
        public void MeshTest()
        {
            AwesomeMesh target = new AwesomeMesh(); // TODO: Passenden Wert initialisieren
            VertexAwesome[] expected = null; // TODO: Passenden Wert initialisieren
            VertexAwesome[] actual;
            target.Mesh = expected;
            actual = target.Mesh;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Draw"
        ///</summary>
        [TestMethod()]
        public void DrawTest1()
        {
            AwesomeMesh target = new AwesomeMesh(); // TODO: Passenden Wert initialisieren
            WorldOrientation o = null; // TODO: Passenden Wert initialisieren
            target.Draw(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Draw"
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            AwesomeMesh target = new AwesomeMesh(); // TODO: Passenden Wert initialisieren
            Matrix m = new Matrix(); // TODO: Passenden Wert initialisieren
            target.Draw(m);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AwesomeMesh-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void AwesomeMeshConstructorTest()
        {
            AwesomeMesh target = new AwesomeMesh();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
