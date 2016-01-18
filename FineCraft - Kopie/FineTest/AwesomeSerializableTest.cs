using FineCraft.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AwesomeSerializableTest" und soll
    ///alle AwesomeSerializableTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AwesomeSerializableTest
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
        ///Ein Test für "SerUInt32Arr"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SerUInt32ArrTest()
        {
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            uint[] o = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable_Accessor.SerUInt32Arr(writer, o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            AwesomeSerializable target = CreateAwesomeSerializable(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SerByteArr"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SerByteArrTest()
        {
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            byte[] o = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable_Accessor.SerByteArr(writer, o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SerArr"
        ///</summary>
        public void SerArrTestHelper<T>()
            where T : AwesomeSerializable
        {
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            T[] o = null; // TODO: Passenden Wert initialisieren
            AwesomeSerializable_Accessor.SerArr<T>(writer, o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SerArrTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie SerArrTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "DeserUInt32Arr"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DeserUInt32ArrTest()
        {
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            uint[] expected = null; // TODO: Passenden Wert initialisieren
            uint[] actual;
            actual = AwesomeSerializable_Accessor.DeserUInt32Arr(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        internal virtual AwesomeSerializable CreateAwesomeSerializable()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            AwesomeSerializable target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            AwesomeSerializable target = CreateAwesomeSerializable(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "DeserByteArr"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DeserByteArrTest()
        {
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            byte[] expected = null; // TODO: Passenden Wert initialisieren
            byte[] actual;
            actual = AwesomeSerializable_Accessor.DeserByteArr(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "DeserArr"
        ///</summary>
        public void DeserArrTestHelper<T>()
            where T : AwesomeSerializable, new()
        {
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            T[] expected = null; // TODO: Passenden Wert initialisieren
            T[] actual;
            actual = AwesomeSerializable_Accessor.DeserArr<T>(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DeserArrTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie DeserArrTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "Deser"
        ///</summary>
        public void DeserTestHelper<T>()
            where T : AwesomeSerializable, new()
        {
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            T expected = default(T); // TODO: Passenden Wert initialisieren
            T actual;
            actual = AwesomeSerializable_Accessor.Deser<T>(reader);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DeserTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie DeserTestHelper<T>() mit geeigneten Typparametern auf.");
        }
    }
}
