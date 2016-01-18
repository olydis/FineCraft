using Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.HybridData;
using System;
using FineCraft.Network;
using FineCraft.Network.PacketTypes;
using FineCraft.DynamicObject;
using FineCraft.Data;
using Client;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "MainWindowTest" und soll
    ///alle MainWindowTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class MainWindowTest
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
        ///Ein Test für "timer1_Tick"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Client.exe")]
        public void timer1_TickTest()
        {
            Client.MainWindow_Accessor target = new Client.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.timer1_Tick(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "InitializeComponent"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Client.exe")]
        public void InitializeComponentTest1()
        {
            Client.MainWindow_Accessor target = new Client.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            target.InitializeComponent();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Dispose"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Client.exe")]
        public void DisposeTest1()
        {
            Client.MainWindow_Accessor target = new Client.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            bool disposing = false; // TODO: Passenden Wert initialisieren
            target.Dispose(disposing);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MainWindow-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void MainWindowConstructorTest1()
        {
            Client.MainWindow_Accessor target = new Client.MainWindow_Accessor();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "userSetCell"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void userSetCellTest()
        {
            MainWindow_Accessor target = new MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            target.userSetCell(userid, position, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "updateOverview_Tick"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void updateOverview_TickTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.updateOverview_Tick(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "unregChunk"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void unregChunkTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            target.unregChunk(userid, position);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "ServerSetCell"
        ///</summary>
        [TestMethod()]
        public void ServerSetCellTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            target.ServerSetCell(position, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SendBroadcast"
        ///</summary>
        [TestMethod()]
        public void SendBroadcastTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            AwesomeSerializable packet = null; // TODO: Passenden Wert initialisieren
            target.SendBroadcast(packet);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "regChunk"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void regChunkTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            Chunk expected = null; // TODO: Passenden Wert initialisieren
            Chunk actual;
            actual = target.regChunk(userid, position);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "pUserPosSync"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pUserPosSyncTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PMyOrientationUpdate u = null; // TODO: Passenden Wert initialisieren
            target.pUserPosSync(nc, u);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pLogin"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pLoginTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PLoginRequest request = null; // TODO: Passenden Wert initialisieren
            target.pLogin(nc, request);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pDynamicObject"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pDynamicObjectTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            DynamicBase u = null; // TODO: Passenden Wert initialisieren
            target.pDynamicObject(nc, u);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChunkUpdate"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pChunkUpdateTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PChunkUpdate chunk = null; // TODO: Passenden Wert initialisieren
            target.pChunkUpdate(nc, chunk);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChunkUnreg"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pChunkUnregTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PChunkUnregister chunk = null; // TODO: Passenden Wert initialisieren
            target.pChunkUnreg(nc, chunk);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChunkReg"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pChunkRegTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PChunkRegister chunk = null; // TODO: Passenden Wert initialisieren
            target.pChunkReg(nc, chunk);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChatLine"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void pChatLineTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            PChatLine u = null; // TODO: Passenden Wert initialisieren
            target.pChatLine(nc, u);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MainWindow_Shown"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void MainWindow_ShownTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.MainWindow_Shown(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "isLoggedIn"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void isLoggedInTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            NetworkClient nc = null; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.isLoggedIn(nc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "InitializeComponent"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void InitializeComponentTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            target.InitializeComponent();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Dispose"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void DisposeTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            bool disposing = false; // TODO: Passenden Wert initialisieren
            target.Dispose(disposing);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "client"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void clientTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            IAsyncResult iar = null; // TODO: Passenden Wert initialisieren
            target.client(iar);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "checkUserPass"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Server.exe")]
        public void checkUserPassTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor(); // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            UserData expected = null; // TODO: Passenden Wert initialisieren
            UserData actual;
            actual = target.checkUserPass(username, password);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "MainWindow-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void MainWindowConstructorTest()
        {
            Server.MainWindow_Accessor target = new Server.MainWindow_Accessor();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
