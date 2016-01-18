using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Client.Properties;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SettingsTest" und soll
    ///alle SettingsTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SettingsTest
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
        ///Ein Test für "Default"
        ///</summary>
        [TestMethod()]
        public void DefaultTest()
        {
            Settings actual;
            actual = Settings.Default;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Settings-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void SettingsConstructorTest1()
        {
            Settings target = new Settings();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "Tick"
        ///</summary>
        [TestMethod()]
        public void TickTest()
        {
            Settings target = new Settings(); // TODO: Passenden Wert initialisieren
            target.Tick();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            Settings target = new Settings(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            Settings target = new Settings(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Settings-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void SettingsConstructorTest()
        {
            Settings target = new Settings();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
