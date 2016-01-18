using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "SoundManagerTest" und soll
    ///alle SoundManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class SoundManagerTest
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
        ///Ein Test für "Mute"
        ///</summary>
        [TestMethod()]
        public void MuteTest()
        {
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            SoundManager.Mute = expected;
            actual = SoundManager.Mute;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "PlayForever"
        ///</summary>
        [TestMethod()]
        public void PlayForeverTest()
        {
            Form form = null; // TODO: Passenden Wert initialisieren
            SoundManager.PlayForever(form);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
