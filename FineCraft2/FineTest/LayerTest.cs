using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "LayerTest" und soll
    ///alle LayerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class LayerTest
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
        ///Ein Test für "Translation"
        ///</summary>
        [TestMethod()]
        public void TranslationTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            Func<Vector2> expected = null; // TODO: Passenden Wert initialisieren
            Func<Vector2> actual;
            target.Translation = expected;
            actual = target.Translation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CellCount"
        ///</summary>
        [TestMethod()]
        public void CellCountTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.CellCount;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "UpdateCell"
        ///</summary>
        [TestMethod()]
        public void UpdateCellTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            int cellIndex = 0; // TODO: Passenden Wert initialisieren
            LayerCell cell = null; // TODO: Passenden Wert initialisieren
            target.UpdateCell(cellIndex, cell);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "toTexCoords"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toTexCoordsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Layer_Accessor target = new Layer_Accessor(param0); // TODO: Passenden Wert initialisieren
            Rectangle r = new Rectangle(); // TODO: Passenden Wert initialisieren
            Vector2[] expected = null; // TODO: Passenden Wert initialisieren
            Vector2[] actual;
            actual = target.toTexCoords(r);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "toScreenCoords"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toScreenCoordsTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Layer_Accessor target = new Layer_Accessor(param0); // TODO: Passenden Wert initialisieren
            Rectangle r = new Rectangle(); // TODO: Passenden Wert initialisieren
            Vector3[] expected = null; // TODO: Passenden Wert initialisieren
            Vector3[] actual;
            actual = target.toScreenCoords(r);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Reset"
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            target.Reset();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Render"
        ///</summary>
        [TestMethod()]
        public void RenderTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            target.Render();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Push"
        ///</summary>
        [TestMethod()]
        public void PushTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            LayerCell cell = null; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.Push(cell);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Pop"
        ///</summary>
        [TestMethod()]
        public void PopTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            target.Pop();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "InitLayerRendering"
        ///</summary>
        [TestMethod()]
        public void InitLayerRenderingTest()
        {
            Layer.InitLayerRendering();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Layer-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void LayerConstructorTest()
        {
            Texture2D textureMap = null; // TODO: Passenden Wert initialisieren
            int maxCells = 0; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            Layer target = new Layer(textureMap, maxCells, depth, xDock, yDock, visible);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
