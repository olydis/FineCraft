using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PhysicsManagerTest" und soll
    ///alle PhysicsManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PhysicsManagerTest
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
        ///Ein Test für "ValidatePhysics"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void ValidatePhysicsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            PhysicsManager_Accessor target = new PhysicsManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            WorldPosition wp = null; // TODO: Passenden Wert initialisieren
            target.ValidatePhysics(wp);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            MainWindow server = null; // TODO: Passenden Wert initialisieren
            PhysicsManager target = new PhysicsManager(server); // TODO: Passenden Wert initialisieren
            WorldPosition wp = null; // TODO: Passenden Wert initialisieren
            target.Update(wp);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "doWork"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void doWorkTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            PhysicsManager_Accessor target = new PhysicsManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.doWork(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "PhysicsManager-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void PhysicsManagerConstructorTest()
        {
            MainWindow server = null; // TODO: Passenden Wert initialisieren
            PhysicsManager target = new PhysicsManager(server);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
