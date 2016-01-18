using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "WorldPositionTest" und soll
    ///alle WorldPositionTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class WorldPositionTest
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
        ///Ein Test für "Clone"
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = target.Clone;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ChunkPosition"
        ///</summary>
        [TestMethod()]
        public void ChunkPositionTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = target.ChunkPosition;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SetOvergroundZ"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SetOvergroundZTest()
        {
            WorldPosition_Accessor target = new WorldPosition_Accessor(); // TODO: Passenden Wert initialisieren
            target.SetOvergroundZ();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Same"
        ///</summary>
        [TestMethod()]
        public void SameTest()
        {
            WorldPosition wp1 = null; // TODO: Passenden Wert initialisieren
            WorldPosition wp2 = null; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = WorldPosition.Same(wp1, wp2);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FastDistance"
        ///</summary>
        [TestMethod()]
        public void FastDistanceTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.FastDistance(x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            WorldPosition target = new WorldPosition(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "abs"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void absTest()
        {
            WorldPosition_Accessor target = new WorldPosition_Accessor(); // TODO: Passenden Wert initialisieren
            uint num = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.abs(num);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "WorldPosition-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void WorldPositionConstructorTest()
        {
            WorldPosition target = new WorldPosition();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
