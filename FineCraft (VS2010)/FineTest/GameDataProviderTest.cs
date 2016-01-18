using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.Data;
using FineCraft.Network.PacketTypes;
using FineCraft.DynamicObject;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GameDataProviderTest" und soll
    ///alle GameDataProviderTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GameDataProviderTest
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
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
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
            string line = string.Empty; // TODO: Passenden Wert initialisieren
            target.SendChatMessage(line);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        internal virtual GameDataProvider CreateGameDataProvider()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            GameDataProvider target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "RegisterChunk"
        ///</summary>
        [TestMethod()]
        public void RegisterChunkTest()
        {
            GameDataProvider target = CreateGameDataProvider(); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            target.RegisterChunk(pos);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
