using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "BlockTypeTest" und soll
    ///alle BlockTypeTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class BlockTypeTest
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
        ///Ein Test für "Placeable"
        ///</summary>
        [TestMethod()]
        public void PlaceableTest()
        {
            BlockType target = new BlockType(); // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Placeable;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "BlockType-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void BlockTypeConstructorTest()
        {
            BlockType target = new BlockType();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
