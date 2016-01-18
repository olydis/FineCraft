using FineCraft.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AwesomeFormatterTest" und soll
    ///alle AwesomeFormatterTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AwesomeFormatterTest
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
        ///Ein Test für "SerializeKnown"
        ///</summary>
        [TestMethod()]
        public void SerializeKnownTest()
        {
            AwesomeFormatter target = new AwesomeFormatter(); // TODO: Passenden Wert initialisieren
            Stream s = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable o = null; // TODO: Passenden Wert initialisieren
            target.SerializeKnown(s, o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            AwesomeFormatter target = new AwesomeFormatter(); // TODO: Passenden Wert initialisieren
            Stream s = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable o = null; // TODO: Passenden Wert initialisieren
            target.Serialize(s, o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "DeserializeKnown"
        ///</summary>
        public void DeserializeKnownTestHelper<T>()
            where T : AwesomeSerializable, new()
        {
            AwesomeFormatter target = new AwesomeFormatter(); // TODO: Passenden Wert initialisieren
            Stream s = null; // TODO: Passenden Wert initialisieren
            T expected = new T(); // TODO: Passenden Wert initialisieren
            T actual;
            actual = target.DeserializeKnown<T>(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void DeserializeKnownTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie DeserializeKnownTestHelper<T>() mit geeigneten Typparametern " +
                    "auf.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            AwesomeFormatter target = new AwesomeFormatter(); // TODO: Passenden Wert initialisieren
            Stream s = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable expected = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable actual;
            actual = target.Deserialize(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "AwesomeFormatter-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void AwesomeFormatterConstructorTest()
        {
            AwesomeFormatter target = new AwesomeFormatter();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
