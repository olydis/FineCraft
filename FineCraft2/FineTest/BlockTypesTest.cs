using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "BlockTypesTest" und soll
    ///alle BlockTypesTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class BlockTypesTest
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
        ///Ein Test für "GetWild"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void GetWildTest()
        {
            int num = 0; // TODO: Passenden Wert initialisieren
            float scale = 0F; // TODO: Passenden Wert initialisieren
            VertexAwesome[] expected = null; // TODO: Passenden Wert initialisieren
            VertexAwesome[] actual;
            actual = BlockTypes_Accessor.GetWild(num, scale);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetFold"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void GetFoldTest()
        {
            int num = 0; // TODO: Passenden Wert initialisieren
            float sideScale = 0F; // TODO: Passenden Wert initialisieren
            float lowerZ = 0F; // TODO: Passenden Wert initialisieren
            float upperZ = 0F; // TODO: Passenden Wert initialisieren
            Vector2 relTex = new Vector2(); // TODO: Passenden Wert initialisieren
            VertexAwesome[] expected = null; // TODO: Passenden Wert initialisieren
            VertexAwesome[] actual;
            actual = BlockTypes_Accessor.GetFold(num, sideScale, lowerZ, upperZ, relTex);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetCyl"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void GetCylTest()
        {
            int num = 0; // TODO: Passenden Wert initialisieren
            VertexAwesome[] expected = null; // TODO: Passenden Wert initialisieren
            VertexAwesome[] actual;
            actual = BlockTypes_Accessor.GetCyl(num);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FromID"
        ///</summary>
        [TestMethod()]
        public void FromIDTest1()
        {
            string id = string.Empty; // TODO: Passenden Wert initialisieren
            BlockType expected = null; // TODO: Passenden Wert initialisieren
            BlockType actual;
            actual = BlockTypes.FromID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FromID"
        ///</summary>
        [TestMethod()]
        public void FromIDTest()
        {
            uint id = 0; // TODO: Passenden Wert initialisieren
            BlockType expected = null; // TODO: Passenden Wert initialisieren
            BlockType actual;
            actual = BlockTypes.FromID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "addCustom"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void addCustomTest()
        {
            BlockingType blocking = new BlockingType(); // TODO: Passenden Wert initialisieren
            uint texture = 0; // TODO: Passenden Wert initialisieren
            VertexAwesome[] mesh = null; // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            string description = string.Empty; // TODO: Passenden Wert initialisieren
            BlockTypes_Accessor.addCustom(blocking, texture, mesh, name, description);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "addCube"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void addCubeTest1()
        {
            BlockTypes_Accessor.CubeType type = null; // TODO: Passenden Wert initialisieren
            bool removable = false; // TODO: Passenden Wert initialisieren
            BlockingType blocking = new BlockingType(); // TODO: Passenden Wert initialisieren
            uint texture = 0; // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            string description = string.Empty; // TODO: Passenden Wert initialisieren
            VertexAwesome[] mesh = null; // TODO: Passenden Wert initialisieren
            BlockTypes_Accessor.addCube(type, removable, blocking, texture, name, description, mesh);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "addCube"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void addCubeTest()
        {
            BlockTypes_Accessor.CubeType type = null; // TODO: Passenden Wert initialisieren
            bool removable = false; // TODO: Passenden Wert initialisieren
            BlockingType blocking = new BlockingType(); // TODO: Passenden Wert initialisieren
            uint texture = 0; // TODO: Passenden Wert initialisieren
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            string description = string.Empty; // TODO: Passenden Wert initialisieren
            BlockTypes_Accessor.addCube(type, removable, blocking, texture, name, description);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "add"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void addTest()
        {
            BlockType bt = null; // TODO: Passenden Wert initialisieren
            BlockTypes_Accessor.add(bt);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
