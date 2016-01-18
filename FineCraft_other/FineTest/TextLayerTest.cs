using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "TextLayerTest" und soll
    ///alle TextLayerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class TextLayerTest
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
        ///Ein Test für "Height"
        ///</summary>
        [TestMethod()]
        public void HeightTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.Height;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Write"
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            char c = '\0'; // TODO: Passenden Wert initialisieren
            target.Write(c);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SetText"
        ///</summary>
        [TestMethod()]
        public void SetTextTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            string text = string.Empty; // TODO: Passenden Wert initialisieren
            target.SetText(text);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Reset"
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            target.Reset();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Back"
        ///</summary>
        [TestMethod()]
        public void BackTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible); // TODO: Passenden Wert initialisieren
            target.Back();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "TextLayer-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void TextLayerConstructorTest()
        {
            string statictext = string.Empty; // TODO: Passenden Wert initialisieren
            float depth = 0F; // TODO: Passenden Wert initialisieren
            LayerDock xDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            LayerDock yDock = new LayerDock(); // TODO: Passenden Wert initialisieren
            Func<bool> visible = null; // TODO: Passenden Wert initialisieren
            TextLayer target = new TextLayer(statictext, depth, xDock, yDock, visible);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
