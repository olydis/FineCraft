using FineCraft.HybridData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SettingsSingletonTest" und soll
    ///alle SettingsSingletonTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SettingsSingletonTest
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
        ///Ein Test für "Key"
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            SettingsSingleton target = new SettingsSingleton(); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Key;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "TryGetSettings"
        ///</summary>
        [TestMethod()]
        public void TryGetSettingsTest()
        {
            SettingsSingleton expected = null; // TODO: Passenden Wert initialisieren
            SettingsSingleton actual;
            actual = SettingsSingleton.TryGetSettings();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            SettingsSingleton target = new SettingsSingleton(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "RegisterSettings"
        ///</summary>
        [TestMethod()]
        public void RegisterSettingsTest()
        {
            uint userid = 0; // TODO: Passenden Wert initialisieren
            Settings expected = null; // TODO: Passenden Wert initialisieren
            Settings actual;
            actual = SettingsSingleton.RegisterSettings(userid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            SettingsSingleton target = new SettingsSingleton(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SettingsSingleton-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void SettingsSingletonConstructorTest()
        {
            SettingsSingleton target = new SettingsSingleton();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
