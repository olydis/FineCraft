using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using FineCraft;
using System;
using Microsoft.Xna.Framework.Graphics;
using FineCraft.Data;
using System.Drawing;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "RendererTest" und soll
    ///alle RendererTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class RendererTest
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
        ///Ein Test für "Volume"
        ///</summary>
        [TestMethod()]
        public void VolumeTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume actual;
            actual = target.Volume;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Singleton"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SingletonTest()
        {
            Renderer expected = null; // TODO: Passenden Wert initialisieren
            Renderer actual;
            Renderer_Accessor.Singleton = expected;
            actual = Renderer_Accessor.Singleton;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ScreenShot"
        ///</summary>
        [TestMethod()]
        public void ScreenShotTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            Bitmap actual;
            actual = target.ScreenShot;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Rendering"
        ///</summary>
        [TestMethod()]
        public void RenderingTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Rendering = expected;
            actual = target.Rendering;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Orientation"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void OrientationTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            WorldOrientation actual;
            actual = target.Orientation;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "MidY"
        ///</summary>
        [TestMethod()]
        public void MidYTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.MidY;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "MidX"
        ///</summary>
        [TestMethod()]
        public void MidXTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.MidX;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "HalfWidth"
        ///</summary>
        [TestMethod()]
        public void HalfWidthTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.HalfWidth;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "HalfHeight"
        ///</summary>
        [TestMethod()]
        public void HalfHeightTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.HalfHeight;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GraphicsEffect"
        ///</summary>
        [TestMethod()]
        public void GraphicsEffectTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            AwesomeEffect actual;
            actual = target.GraphicsEffect;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GraphicsDevice"
        ///</summary>
        [TestMethod()]
        public void GraphicsDeviceTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            GraphicsDevice actual;
            actual = target.GraphicsDevice;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FullScreen"
        ///</summary>
        [TestMethod()]
        public void FullScreenTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.FullScreen = expected;
            actual = target.FullScreen;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "backGround"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void backGroundTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            Color expected = new Color(); // TODO: Passenden Wert initialisieren
            Color actual;
            target.backGround = expected;
            actual = target.backGround;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SetFog"
        ///</summary>
        [TestMethod()]
        public void SetFogTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            int distance = 0; // TODO: Passenden Wert initialisieren
            target.SetFog(distance);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SetDayTime"
        ///</summary>
        [TestMethod()]
        public void SetDayTimeTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            ushort daytime = 0; // TODO: Passenden Wert initialisieren
            target.SetDayTime(daytime);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Repaint"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void RepaintTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.Repaint();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Renderer_Move"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void Renderer_MoveTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.Renderer_Move(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "InitDevice"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void InitDeviceTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.InitDevice();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Cycle"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void CycleTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.Cycle(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "control_Resize"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void control_ResizeTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            Renderer_Accessor target = new Renderer_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.control_Resize(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AddChatHistory"
        ///</summary>
        [TestMethod()]
        public void AddChatHistoryTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager); // TODO: Passenden Wert initialisieren
            string line = string.Empty; // TODO: Passenden Wert initialisieren
            target.AddChatHistory(line);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Renderer-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void RendererConstructorTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameManager manager = null; // TODO: Passenden Wert initialisieren
            Renderer target = new Renderer(control, manager);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
