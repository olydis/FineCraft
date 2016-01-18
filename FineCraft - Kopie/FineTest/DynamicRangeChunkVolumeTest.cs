using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using FineCraft;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "DynamicRangeChunkVolumeTest" und soll
    ///alle DynamicRangeChunkVolumeTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DynamicRangeChunkVolumeTest
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
        ///Ein Test für "Vertices"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void VerticesTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            target.Vertices = expected;
            actual = target.Vertices;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "WishSomething"
        ///</summary>
        [TestMethod()]
        public void WishSomethingTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            int toDo = 0; // TODO: Passenden Wert initialisieren
            int toDoExpected = 0; // TODO: Passenden Wert initialisieren
            target.WishSomething(ref toDo);
            Assert.AreEqual(toDoExpected, toDo);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "visible"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void visibleTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint chunkX = 0; // TODO: Passenden Wert initialisieren
            uint chunkY = 0; // TODO: Passenden Wert initialisieren
            uint chunkZ = 0; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.visible(chunkX, chunkY, chunkZ);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "UpdatePositionFast"
        ///</summary>
        [TestMethod()]
        public void UpdatePositionFastTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            target.UpdatePositionFast(pos);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UpdatePosition"
        ///</summary>
        [TestMethod()]
        public void UpdatePositionTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            target.UpdatePosition();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UpdateChunk"
        ///</summary>
        [TestMethod()]
        public void UpdateChunkTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            target.UpdateChunk(x, y, z, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Render"
        ///</summary>
        [TestMethod()]
        public void RenderTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            BoundingFrustum frustum = null; // TODO: Passenden Wert initialisieren
            target.Render(frustum);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "RedrawWithSurrounding"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void RedrawWithSurroundingTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint chunkX = 0; // TODO: Passenden Wert initialisieren
            uint chunkY = 0; // TODO: Passenden Wert initialisieren
            uint chunkZ = 0; // TODO: Passenden Wert initialisieren
            target.RedrawWithSurrounding(chunkX, chunkY, chunkZ);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Redraw"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void RedrawTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint chunkX = 0; // TODO: Passenden Wert initialisieren
            uint chunkY = 0; // TODO: Passenden Wert initialisieren
            uint chunkZ = 0; // TODO: Passenden Wert initialisieren
            target.Redraw(chunkX, chunkY, chunkZ);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "ReadValue"
        ///</summary>
        [TestMethod()]
        public void ReadValueTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.ReadValue(x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "InsertChunk"
        ///</summary>
        [TestMethod()]
        public void InsertChunkTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider); // TODO: Passenden Wert initialisieren
            Chunk c = null; // TODO: Passenden Wert initialisieren
            target.InsertChunk(c);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "FreeVertexBuffers"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void FreeVertexBuffersTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            Chunk vol = null; // TODO: Passenden Wert initialisieren
            target.FreeVertexBuffers(vol);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "distance"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void distanceTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint a = 0; // TODO: Passenden Wert initialisieren
            uint b = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.distance(a, b);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "coordToIndex"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void coordToIndexTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.coordToIndex(x);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "coordToChunkCoord"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void coordToChunkCoordTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.coordToChunkCoord(x);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "abs"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void absTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume_Accessor target = new DynamicRangeChunkVolume_Accessor(param0); // TODO: Passenden Wert initialisieren
            uint i = 0; // TODO: Passenden Wert initialisieren
            long expected = 0; // TODO: Passenden Wert initialisieren
            long actual;
            actual = target.abs(i);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "DynamicRangeChunkVolume-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void DynamicRangeChunkVolumeConstructorTest()
        {
            GraphicsDevice device = null; // TODO: Passenden Wert initialisieren
            GameDataProvider provider = null; // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume target = new DynamicRangeChunkVolume(device, provider);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
