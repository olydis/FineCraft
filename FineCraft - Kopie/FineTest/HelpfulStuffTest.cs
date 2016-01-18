using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using FineCraft.Data;
using System.Threading;
using System;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "HelpfulStuffTest" und soll
    ///alle HelpfulStuffTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class HelpfulStuffTest
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
        ///Ein Test für "BaseDirectory"
        ///</summary>
        [TestMethod()]
        public void BaseDirectoryTest()
        {
            DirectoryInfo actual;
            actual = HelpfulStuff.BaseDirectory;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Try"
        ///</summary>
        [TestMethod()]
        public void TryTest()
        {
            Action a = null; // TODO: Passenden Wert initialisieren
            HelpfulStuff.Try(a);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Run"
        ///</summary>
        [TestMethod()]
        public void RunTest()
        {
            ThreadStart a = null; // TODO: Passenden Wert initialisieren
            HelpfulStuff.Run(a);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "getCube"
        ///</summary>
        [TestMethod()]
        public void getCubeTest()
        {
            float bBoxSize = 0F; // TODO: Passenden Wert initialisieren
            Vector2 basis = new Vector2(); // TODO: Passenden Wert initialisieren
            AwesomeMesh expected = null; // TODO: Passenden Wert initialisieren
            AwesomeMesh actual;
            actual = HelpfulStuff.getCube(bBoxSize, basis);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ClampPos"
        ///</summary>
        [TestMethod()]
        public void ClampPosTest()
        {
            int[,] _16x16 = null; // TODO: Passenden Wert initialisieren
            uint max = 0; // TODO: Passenden Wert initialisieren
            HelpfulStuff.ClampPos(_16x16, max);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Clamp"
        ///</summary>
        [TestMethod()]
        public void ClampTest()
        {
            int[,] _16x16 = null; // TODO: Passenden Wert initialisieren
            uint minmax = 0; // TODO: Passenden Wert initialisieren
            HelpfulStuff.Clamp(_16x16, minmax);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "abs"
        ///</summary>
        [TestMethod()]
        public void absTest1()
        {
            uint i = 0; // TODO: Passenden Wert initialisieren
            uint max = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = HelpfulStuff.abs(i, max);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "abs"
        ///</summary>
        [TestMethod()]
        public void absTest()
        {
            uint i = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = HelpfulStuff.abs(i);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
