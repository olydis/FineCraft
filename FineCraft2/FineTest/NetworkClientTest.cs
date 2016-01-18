using FineCraft.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "NetworkClientTest" und soll
    ///alle NetworkClientTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class NetworkClientTest
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
        ///Ein Test für "IsConnectionLost"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void IsConnectionLostTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            NetworkClient_Accessor target = new NetworkClient_Accessor(param0); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.IsConnectionLost = expected;
            actual = target.IsConnectionLost;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Unregister"
        ///</summary>
        public void UnregisterTestHelper<T>()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            target.Unregister<T>();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void UnregisterTest()
        {
            UnregisterTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Send"
        ///</summary>
        [TestMethod()]
        public void SendTest()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            AwesomeSerializable o = null; // TODO: Passenden Wert initialisieren
            target.Send(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Run"
        ///</summary>
        [TestMethod()]
        public void RunTest()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            target.Run();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Register"
        ///</summary>
        public void RegisterTest1Helper<T>()
            where T : AwesomeSerializable
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            Action<T> handler = null; // TODO: Passenden Wert initialisieren
            target.Register<T>(handler);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void RegisterTest1()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie RegisterTest1Helper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "Register"
        ///</summary>
        public void RegisterTestHelper<T>()
            where T : AwesomeSerializable
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            Action<NetworkClient, T> handler = null; // TODO: Passenden Wert initialisieren
            target.Register<T>(handler);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void RegisterTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie RegisterTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "Reconnect"
        ///</summary>
        [TestMethod()]
        public void ReconnectTest()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Reconnect();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "receive"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void receiveTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            NetworkClient_Accessor target = new NetworkClient_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.receive();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Disconnect"
        ///</summary>
        [TestMethod()]
        public void DisconnectTest()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client); // TODO: Passenden Wert initialisieren
            target.Disconnect();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "connectionLost"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void connectionLostTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            NetworkClient_Accessor target = new NetworkClient_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.connectionLost();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "NetworkClient-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void NetworkClientConstructorTest()
        {
            Func<TcpClient> client = null; // TODO: Passenden Wert initialisieren
            NetworkClient target = new NetworkClient(client);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
