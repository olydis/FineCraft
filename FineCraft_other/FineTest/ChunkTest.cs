using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ChunkTest" und soll
    ///alle ChunkTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ChunkTest
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
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
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
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
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
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.X;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "IsPure"
        ///</summary>
        [TestMethod()]
        public void IsPureTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
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
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ToDraw"
        ///</summary>
        [TestMethod()]
        public void ToDrawTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            GraphicsDevice dev = null; // TODO: Passenden Wert initialisieren
            VertexBuffer[] expected = null; // TODO: Passenden Wert initialisieren
            VertexBuffer[] actual;
            actual = target.ToDraw(dev);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Set"
        ///</summary>
        [TestMethod()]
        public void SetTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            target.Set(x, y, z, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
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
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            target.Optimize();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "IsVisibleTo"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void IsVisibleToTest()
        {
            Chunk_Accessor target = new Chunk_Accessor(); // TODO: Passenden Wert initialisieren
            BlockType block = null; // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.IsVisibleTo(block, x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getFace"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void getFaceTest()
        {
            Chunk_Accessor target = new Chunk_Accessor(); // TODO: Passenden Wert initialisieren
            bool bothSides = false; // TODO: Passenden Wert initialisieren
            Vector2 uv = new Vector2(); // TODO: Passenden Wert initialisieren
            byte light = 0; // TODO: Passenden Wert initialisieren
            Vector3 internalOffset = new Vector3(); // TODO: Passenden Wert initialisieren
            Matrix rotate = new Matrix(); // TODO: Passenden Wert initialisieren
            IEnumerable<VertexAwesome> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<VertexAwesome> actual;
            actual = target.getFace(bothSides, uv, light, internalOffset, rotate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Get"
        ///</summary>
        [TestMethod()]
        public void GetTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
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
        ///Ein Test für "Explode"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void ExplodeTest()
        {
            Chunk_Accessor target = new Chunk_Accessor(); // TODO: Passenden Wert initialisieren
            byte[] expected = null; // TODO: Passenden Wert initialisieren
            byte[] actual;
            actual = target.Explode();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AssignVolume"
        ///</summary>
        [TestMethod()]
        public void AssignVolumeTest()
        {
            Chunk target = new Chunk(); // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume parentVolume = null; // TODO: Passenden Wert initialisieren
            target.AssignVolume(parentVolume);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Chunk-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void ChunkConstructorTest()
        {
            Chunk target = new Chunk();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
