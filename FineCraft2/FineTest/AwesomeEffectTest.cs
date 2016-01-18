using FineCraft.RenderEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AwesomeEffectTest" und soll
    ///alle AwesomeEffectTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AwesomeEffectTest
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
        ///Ein Test für "WMatrix"
        ///</summary>
        [TestMethod()]
        public void WMatrixTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            Matrix expected = new Matrix(); // TODO: Passenden Wert initialisieren
            target.WMatrix = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "VPMatrix"
        ///</summary>
        [TestMethod()]
        public void VPMatrixTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            Matrix expected = new Matrix(); // TODO: Passenden Wert initialisieren
            target.VPMatrix = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Texture"
        ///</summary>
        [TestMethod()]
        public void TextureTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            Texture2D expected = null; // TODO: Passenden Wert initialisieren
            target.Texture = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "LightDirection"
        ///</summary>
        [TestMethod()]
        public void LightDirectionTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            Vector3 expected = new Vector3(); // TODO: Passenden Wert initialisieren
            target.LightDirection = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "FogEnd"
        ///</summary>
        [TestMethod()]
        public void FogEndTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            target.FogEnd = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AmbientLightColor"
        ///</summary>
        [TestMethod()]
        public void AmbientLightColorTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            Vector4 expected = new Vector4(); // TODO: Passenden Wert initialisieren
            target.AmbientLightColor = expected;
            Assert.Inconclusive("Lesegeschützte Eigenschaften können nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "setWVP"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void setWVPTest()
        {
            AwesomeEffect_Accessor target = new AwesomeEffect_Accessor(); // TODO: Passenden Wert initialisieren
            target.setWVP();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "EndPass3D"
        ///</summary>
        [TestMethod()]
        public void EndPass3DTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.EndPass3D();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "EndPass2D"
        ///</summary>
        [TestMethod()]
        public void EndPass2DTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.EndPass2D();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "End"
        ///</summary>
        [TestMethod()]
        public void EndTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.End();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "BeginPass3D"
        ///</summary>
        [TestMethod()]
        public void BeginPass3DTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.BeginPass3D();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "BeginPass2D"
        ///</summary>
        [TestMethod()]
        public void BeginPass2DTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.BeginPass2D();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Begin"
        ///</summary>
        [TestMethod()]
        public void BeginTest()
        {
            AwesomeEffect target = new AwesomeEffect(); // TODO: Passenden Wert initialisieren
            target.Begin();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AwesomeEffect-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void AwesomeEffectConstructorTest()
        {
            AwesomeEffect target = new AwesomeEffect();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
