using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ServiceTest" und soll
    ///alle ServiceTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ServiceTest
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
        ///Ein Test für "SendSettings"
        ///</summary>
        [TestMethod()]
        public void SendSettingsTest()
        {
            MainWindow host = null; // TODO: Passenden Wert initialisieren
            Service target = new Service(host); // TODO: Passenden Wert initialisieren
            target.SendSettings();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "sendSettings"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void sendSettingsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Service_Accessor target = new Service_Accessor(param0); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.sendSettings(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Service-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void ServiceConstructorTest()
        {
            MainWindow host = null; // TODO: Passenden Wert initialisieren
            Service target = new Service(host);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
