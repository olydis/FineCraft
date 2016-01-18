using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System;
using FineCraft.DynamicObject;
using FineCraft.Network.PacketTypes;
using FineCraft.Network;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "MultiPlayerDataProviderTest" und soll
    ///alle MultiPlayerDataProviderTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class MultiPlayerDataProviderTest
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
        ///Ein Test für "Username"
        ///</summary>
        [TestMethod()]
        public void UsernameTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Username;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "UpdateUserPosition"
        ///</summary>
        [TestMethod()]
        public void UpdateUserPositionTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            WorldOrientation orientation = null; // TODO: Passenden Wert initialisieren
            target.UpdateUserPosition(orientation);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UpdateDynamicObject"
        ///</summary>
        [TestMethod()]
        public void UpdateDynamicObjectTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            DynamicBase db = null; // TODO: Passenden Wert initialisieren
            target.UpdateDynamicObject(db);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UpdateChunk"
        ///</summary>
        [TestMethod()]
        public void UpdateChunkTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            PChunkUpdate update = null; // TODO: Passenden Wert initialisieren
            target.UpdateChunk(update);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UnregisterChunk"
        ///</summary>
        [TestMethod()]
        public void UnregisterChunkTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            target.UnregisterChunk(pos);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Start"
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            GameManager engine = null; // TODO: Passenden Wert initialisieren
            target.Start(engine);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SendChatMessage"
        ///</summary>
        [TestMethod()]
        public void SendChatMessageTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            string line = string.Empty; // TODO: Passenden Wert initialisieren
            target.SendChatMessage(line);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "RegisterChunk"
        ///</summary>
        [TestMethod()]
        public void RegisterChunkTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            target.RegisterChunk(pos);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pSettings"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void pSettingsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            Settings data = null; // TODO: Passenden Wert initialisieren
            target.pSettings(data);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pLogin"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void pLoginTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            PLoginResponse response = null; // TODO: Passenden Wert initialisieren
            target.pLogin(response);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChunkUpdate"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void pChunkUpdateTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            PChunkUpdate data = null; // TODO: Passenden Wert initialisieren
            target.pChunkUpdate(data);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "pChunkTransfer"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void pChunkTransferTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            PChunkTransfer data = null; // TODO: Passenden Wert initialisieren
            target.pChunkTransfer(data);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "nc_ConnectionLost"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void nc_ConnectionLostTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            NetworkClient client = null; // TODO: Passenden Wert initialisieren
            target.nc_ConnectionLost(client);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "IncomingChatLine"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void IncomingChatLineTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            PChatLine packet = null; // TODO: Passenden Wert initialisieren
            target.IncomingChatLine(packet);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "flushRequests"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void flushRequestsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.flushRequests(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "DynamicChange"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DynamicChangeTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider_Accessor target = new MultiPlayerDataProvider_Accessor(param0); // TODO: Passenden Wert initialisieren
            DynamicBase packet = null; // TODO: Passenden Wert initialisieren
            target.DynamicChange(packet);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MultiPlayerDataProvider-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void MultiPlayerDataProviderConstructorTest()
        {
            Func<TcpClient> tc = null; // TODO: Passenden Wert initialisieren
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            MultiPlayerDataProvider target = new MultiPlayerDataProvider(tc, username, password);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
