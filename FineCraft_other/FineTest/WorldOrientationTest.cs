using FineCraft.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Microsoft.Xna.Framework;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "WorldOrientationTest" und soll
    ///alle WorldOrientationTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class WorldOrientationTest
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
        ///Ein Test für "World"
        ///</summary>
        [TestMethod()]
        public void WorldTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            Matrix actual;
            actual = target.World;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "fZ"
        ///</summary>
        [TestMethod()]
        public void fZTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            float actual;
            target.fZ = expected;
            actual = target.fZ;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "fY"
        ///</summary>
        [TestMethod()]
        public void fYTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            float actual;
            target.fY = expected;
            actual = target.fY;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "fX"
        ///</summary>
        [TestMethod()]
        public void fXTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            float expected = 0F; // TODO: Passenden Wert initialisieren
            float actual;
            target.fX = expected;
            actual = target.fX;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Normalize"
        ///</summary>
        [TestMethod()]
        public void NormalizeTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            target.Normalize();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Move"
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            Vector3 delta = new Vector3(); // TODO: Passenden Wert initialisieren
            target.Move(delta);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Goto"
        ///</summary>
        [TestMethod()]
        public void GotoTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            target.Goto(pos);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "GetView"
        ///</summary>
        [TestMethod()]
        public void GetViewTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            Matrix expected = new Matrix(); // TODO: Passenden Wert initialisieren
            Matrix actual;
            actual = target.GetView();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            WorldOrientation target = new WorldOrientation(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "WorldOrientation-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void WorldOrientationConstructorTest()
        {
            WorldOrientation target = new WorldOrientation();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
