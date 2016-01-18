using FineCraft.HybridData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "UserDataTest" und soll
    ///alle UserDataTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class UserDataTest
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
        ///Ein Test für "UnusedID"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void UnusedIDTest()
        {
            uint actual;
            actual = UserData_Accessor.UnusedID;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Key"
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            UserData target = new UserData(); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Key;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "toMd5"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toMd5Test()
        {
            string pwd = string.Empty; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = UserData_Accessor.toMd5(pwd);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            UserData target = new UserData(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "RegisterUser"
        ///</summary>
        [TestMethod()]
        public void RegisterUserTest()
        {
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            UserData.RegisterUser(username, password);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Login"
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            string username = string.Empty; // TODO: Passenden Wert initialisieren
            string password = string.Empty; // TODO: Passenden Wert initialisieren
            bool autoRegisterNew = false; // TODO: Passenden Wert initialisieren
            UserData expected = null; // TODO: Passenden Wert initialisieren
            UserData actual;
            actual = UserData.Login(username, password, autoRegisterNew);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            UserData target = new UserData(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UserData-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void UserDataConstructorTest()
        {
            UserData target = new UserData();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
