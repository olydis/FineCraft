using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "EasyIniTest" und soll
    ///alle EasyIniTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class EasyIniTest
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
        ///Ein Test für "Write"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void WriteTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            EasyIni_Accessor target = new EasyIni_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.Write();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Set"
        ///</summary>
        public void SetTestHelper<T>()
        {
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            EasyIni target = new EasyIni(name); // TODO: Passenden Wert initialisieren
            string id = string.Empty; // TODO: Passenden Wert initialisieren
            T value = default(T); // TODO: Passenden Wert initialisieren
            target.Set<T>(id, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void SetTest()
        {
            SetTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Save"
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            EasyIni target = new EasyIni(name); // TODO: Passenden Wert initialisieren
            target.Save();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Read"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void ReadTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            EasyIni_Accessor target = new EasyIni_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.Read();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Get"
        ///</summary>
        public void GetTestHelper<T>()
        {
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            EasyIni target = new EasyIni(name); // TODO: Passenden Wert initialisieren
            string id = string.Empty; // TODO: Passenden Wert initialisieren
            T alternative = default(T); // TODO: Passenden Wert initialisieren
            T expected = default(T); // TODO: Passenden Wert initialisieren
            T actual;
            actual = target.Get<T>(id, alternative);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void GetTest()
        {
            GetTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "EasyIni-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void EasyIniConstructorTest()
        {
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            EasyIni target = new EasyIni(name);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
