using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "FastRandomTest" und soll
    ///alle FastRandomTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class FastRandomTest
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
        ///Ein Test für "Single"
        ///</summary>
        [TestMethod()]
        public void SingleTest()
        {
            int seed = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = FastRandom.Single(seed);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Reinitialise"
        ///</summary>
        [TestMethod()]
        public void ReinitialiseTest()
        {
            FastRandom target = new FastRandom(); // TODO: Passenden Wert initialisieren
            int seed = 0; // TODO: Passenden Wert initialisieren
            target.Reinitialise(seed);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Next"
        ///</summary>
        [TestMethod()]
        public void NextTest()
        {
            FastRandom target = new FastRandom(); // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.Next();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FastRandom-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void FastRandomConstructorTest1()
        {
            int seed = 0; // TODO: Passenden Wert initialisieren
            FastRandom target = new FastRandom(seed);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "FastRandom-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void FastRandomConstructorTest()
        {
            FastRandom target = new FastRandom();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
