using FineCraft.HybridData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.Data;
using System.IO;
using System.Collections.Generic;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "OctTreeTest" und soll
    ///alle OctTreeTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class OctTreeTest
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
        ///Ein Test für "Z"
        ///</summary>
        [TestMethod()]
        public void ZTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.Z;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Y"
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.Y;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "X"
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.X;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Position"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void PositionTest()
        {
            OctTree_Accessor target = new OctTree_Accessor(); // TODO: Passenden Wert initialisieren
            WorldPosition expected = null; // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Key"
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Key;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Item"
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            target[x, y, z] = expected;
            actual = target[x, y, z];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "IsPure"
        ///</summary>
        [TestMethod()]
        public void IsPureTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.IsPure;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Set"
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            IEnumerable<uint> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<uint> actual;
            actual = target.Set(x, y, z, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Optimize"
        ///</summary>
        [TestMethod()]
        public void OptimizeTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            target.Optimize();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "GetTree"
        ///</summary>
        [TestMethod()]
        public void GetTreeTest1()
        {
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            OctTree expected = null; // TODO: Passenden Wert initialisieren
            OctTree actual;
            actual = OctTree.GetTree(position);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetTree"
        ///</summary>
        [TestMethod()]
        public void GetTreeTest()
        {
            WorldPosition position = null; // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            OctTree expected = null; // TODO: Passenden Wert initialisieren
            OctTree actual;
            actual = OctTree.GetTree(position, userid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetChunk"
        ///</summary>
        [TestMethod()]
        public void GetChunkTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            Chunk expected = null; // TODO: Passenden Wert initialisieren
            Chunk actual;
            actual = target.GetChunk();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Get"
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.Get(x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            OctTree target = new OctTree(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "OctTree-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void OctTreeConstructorTest1()
        {
            OctTree target = new OctTree();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "OctTree-Konstruktor"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void OctTreeConstructorTest()
        {
            Chunk c = null; // TODO: Passenden Wert initialisieren
            OctTree_Accessor target = new OctTree_Accessor(c);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
