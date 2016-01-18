using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "WalkManagerTest" und soll
    ///alle WalkManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class WalkManagerTest
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
        ///Ein Test für "Right"
        ///</summary>
        [TestMethod()]
        public void RightTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Right = expected;
            actual = target.Right;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Left"
        ///</summary>
        [TestMethod()]
        public void LeftTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Left = expected;
            actual = target.Left;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Forward"
        ///</summary>
        [TestMethod()]
        public void ForwardTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Forward = expected;
            actual = target.Forward;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Backward"
        ///</summary>
        [TestMethod()]
        public void BackwardTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Backward = expected;
            actual = target.Backward;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Tick"
        ///</summary>
        [TestMethod()]
        public void TickTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            target.Tick();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "sign"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void signTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            WalkManager_Accessor target = new WalkManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            float f = 0F; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.sign(f);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Jump"
        ///</summary>
        [TestMethod()]
        public void JumpTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game); // TODO: Passenden Wert initialisieren
            target.Jump();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "WalkManager-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void WalkManagerConstructorTest()
        {
            GameManager game = null; // TODO: Passenden Wert initialisieren
            WalkManager target = new WalkManager(game);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
