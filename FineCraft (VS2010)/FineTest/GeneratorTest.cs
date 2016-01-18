using FineCraft.WorldGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GeneratorTest" und soll
    ///alle GeneratorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GeneratorTest
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
        ///Ein Test für "GenerateHeightmap"
        ///</summary>
        [TestMethod()]
        public void GenerateHeightmapTest()
        {
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            int realExp = 0; // TODO: Passenden Wert initialisieren
            int bufferExp = 0; // TODO: Passenden Wert initialisieren
            int[,] expected = null; // TODO: Passenden Wert initialisieren
            int[,] actual;
            actual = Generator.GenerateHeightmap(position, realExp, bufferExp);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GenerateHeight"
        ///</summary>
        [TestMethod()]
        public void GenerateHeightTest()
        {
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = Generator.GenerateHeight(position);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GenerateChunk"
        ///</summary>
        [TestMethod()]
        public void GenerateChunkTest()
        {
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            uint[, ,] expected = null; // TODO: Passenden Wert initialisieren
            uint[, ,] actual;
            actual = Generator.GenerateChunk(position);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Generator-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void GeneratorConstructorTest()
        {
            Generator target = new Generator();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
