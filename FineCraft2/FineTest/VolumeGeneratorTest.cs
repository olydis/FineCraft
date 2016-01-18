using FineCraft.WorldGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "VolumeGeneratorTest" und soll
    ///alle VolumeGeneratorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class VolumeGeneratorTest
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
        ///Ein Test für "toSeedComponent"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toSeedComponentTest()
        {
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = VolumeGenerator_Accessor.toSeedComponent(x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "toleranceStep"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toleranceStepTest()
        {
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = VolumeGenerator_Accessor.toleranceStep(tolerance);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "toggleMode"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void toggleModeTest()
        {
            int offset = 0; // TODO: Passenden Wert initialisieren
            int rand = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int min = 0; // TODO: Passenden Wert initialisieren
            int max = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = VolumeGenerator_Accessor.toggleMode(offset, rand, tolerance, min, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "interpolate"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void interpolateTest()
        {
            int[, ,] buffer = null; // TODO: Passenden Wert initialisieren
            VolumeGenerator_Accessor.interpolate(buffer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "getTolerance"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void getToleranceTest()
        {
            int maxTolerance = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = VolumeGenerator_Accessor.getTolerance(maxTolerance);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getFrame3D"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void getFrame3DTest()
        {
            int[, ,] buffer = null; // TODO: Passenden Wert initialisieren
            int x = 0; // TODO: Passenden Wert initialisieren
            int y = 0; // TODO: Passenden Wert initialisieren
            int z = 0; // TODO: Passenden Wert initialisieren
            int d = 0; // TODO: Passenden Wert initialisieren
            int seed = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int[, ,] expected = null; // TODO: Passenden Wert initialisieren
            int[, ,] actual;
            actual = VolumeGenerator_Accessor.getFrame3D(buffer, x, y, z, d, seed, tolerance);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getData3D"
        ///</summary>
        [TestMethod()]
        public void getData3DTest()
        {
            WorldPosition chunkPosition = null; // TODO: Passenden Wert initialisieren
            int seed = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int[, ,] expected = null; // TODO: Passenden Wert initialisieren
            int[, ,] actual;
            actual = VolumeGenerator.getData3D(chunkPosition, seed, tolerance);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getData2D"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void getData2DTest1()
        {
            int[,] bounds = null; // TODO: Passenden Wert initialisieren
            int depth = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int[,] seed = null; // TODO: Passenden Wert initialisieren
            int sizeExp = 0; // TODO: Passenden Wert initialisieren
            int min = 0; // TODO: Passenden Wert initialisieren
            int max = 0; // TODO: Passenden Wert initialisieren
            int[,] expected = null; // TODO: Passenden Wert initialisieren
            int[,] actual;
            actual = VolumeGenerator_Accessor.getData2D(bounds, depth, tolerance, seed, sizeExp, min, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getData2D"
        ///</summary>
        [TestMethod()]
        public void getData2DTest()
        {
            int seedy = 0; // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            int realSize = 0; // TODO: Passenden Wert initialisieren
            int imageSize = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int min = 0; // TODO: Passenden Wert initialisieren
            int max = 0; // TODO: Passenden Wert initialisieren
            int[,] expected = null; // TODO: Passenden Wert initialisieren
            int[,] actual;
            actual = VolumeGenerator.getData2D(seedy, x, y, realSize, imageSize, tolerance, min, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "getBounds2D"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void getBounds2DTest()
        {
            int[,] bounds = null; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            int[,] seed = null; // TODO: Passenden Wert initialisieren
            uint xx = 0; // TODO: Passenden Wert initialisieren
            uint yy = 0; // TODO: Passenden Wert initialisieren
            int depth = 0; // TODO: Passenden Wert initialisieren
            int min = 0; // TODO: Passenden Wert initialisieren
            int max = 0; // TODO: Passenden Wert initialisieren
            VolumeGenerator_Accessor.getBounds2D(bounds, tolerance, seed, xx, yy, depth, min, max);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "fillBuffer3D"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void fillBuffer3DTest()
        {
            WorldPosition chunkPosition = null; // TODO: Passenden Wert initialisieren
            int[, ,] buffer = null; // TODO: Passenden Wert initialisieren
            int x = 0; // TODO: Passenden Wert initialisieren
            int y = 0; // TODO: Passenden Wert initialisieren
            int z = 0; // TODO: Passenden Wert initialisieren
            int exp = 0; // TODO: Passenden Wert initialisieren
            int seed = 0; // TODO: Passenden Wert initialisieren
            int tolerance = 0; // TODO: Passenden Wert initialisieren
            VolumeGenerator_Accessor.fillBuffer3D(chunkPosition, buffer, x, y, z, exp, seed, tolerance);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "clamp"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void clampTest()
        {
            int i = 0; // TODO: Passenden Wert initialisieren
            int min = 0; // TODO: Passenden Wert initialisieren
            int max = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = VolumeGenerator_Accessor.clamp(i, min, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
