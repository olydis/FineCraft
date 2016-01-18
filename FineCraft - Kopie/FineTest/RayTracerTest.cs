using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "RayTracerTest" und soll
    ///alle RayTracerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class RayTracerTest
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
        ///Ein Test für "Tail"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void TailTest()
        {
            float x = 0F; // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            float actual;
            actual = RayTracer_Accessor.Tail(x);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "NextNewBlock"
        ///</summary>
        [TestMethod()]
        public void NextNewBlockTest()
        {
            Vector3 position = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 delta = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 side = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 sideExpected = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 expected = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 actual;
            actual = RayTracer.NextNewBlock(position, delta, out side);
            Assert.AreEqual(sideExpected, side);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "NextFlip"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void NextFlipTest()
        {
            float x = 0F; // TODO: Passenden Wert initialisieren
            float d = 0F; // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            float actual;
            actual = RayTracer_Accessor.NextFlip(x, d);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FirstHitWithSide"
        ///</summary>
        [TestMethod()]
        public void FirstHitWithSideTest1()
        {
            GameManager gm = null; // TODO: Passenden Wert initialisieren
            int maxDist = 0; // TODO: Passenden Wert initialisieren
            WorldPosition absoluteOffset = null; // TODO: Passenden Wert initialisieren
            Vector3 offset = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 delta = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 side = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 sideExpected = new Vector3(); // TODO: Passenden Wert initialisieren
            WorldPosition expected = null; // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = RayTracer.FirstHitWithSide(gm, maxDist, absoluteOffset, offset, delta, out side);
            Assert.AreEqual(sideExpected, side);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FirstHitWithSide"
        ///</summary>
        [TestMethod()]
        public void FirstHitWithSideTest()
        {
            GameManager gm = null; // TODO: Passenden Wert initialisieren
            int maxDist = 0; // TODO: Passenden Wert initialisieren
            WorldPosition absoluteOffset = null; // TODO: Passenden Wert initialisieren
            Matrix view = new Matrix(); // TODO: Passenden Wert initialisieren
            Vector3 side = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 sideExpected = new Vector3(); // TODO: Passenden Wert initialisieren
            WorldPosition expected = null; // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = RayTracer.FirstHitWithSide(gm, maxDist, absoluteOffset, view, out side);
            Assert.AreEqual(sideExpected, side);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FirstHit"
        ///</summary>
        [TestMethod()]
        public void FirstHitTest1()
        {
            GameManager gm = null; // TODO: Passenden Wert initialisieren
            int maxDist = 0; // TODO: Passenden Wert initialisieren
            WorldPosition absoluteOffset = null; // TODO: Passenden Wert initialisieren
            Matrix view = new Matrix(); // TODO: Passenden Wert initialisieren
            WorldPosition expected = null; // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = RayTracer.FirstHit(gm, maxDist, absoluteOffset, view);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FirstHit"
        ///</summary>
        [TestMethod()]
        public void FirstHitTest()
        {
            GameManager gm = null; // TODO: Passenden Wert initialisieren
            int maxDist = 0; // TODO: Passenden Wert initialisieren
            WorldPosition absoluteOffset = null; // TODO: Passenden Wert initialisieren
            Vector3 offset = new Vector3(); // TODO: Passenden Wert initialisieren
            Vector3 delta = new Vector3(); // TODO: Passenden Wert initialisieren
            WorldPosition expected = null; // TODO: Passenden Wert initialisieren
            WorldPosition actual;
            actual = RayTracer.FirstHit(gm, maxDist, absoluteOffset, offset, delta);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
