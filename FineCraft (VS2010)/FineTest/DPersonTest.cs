using FineCraft.DynamicObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "DPersonTest" und soll
    ///alle DPersonTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DPersonTest
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
        ///Ein Test für "Name"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void NameTest()
        {
            DPerson_Accessor target = new DPerson_Accessor(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "SerializeSub"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SerializeSubTest()
        {
            DPerson_Accessor target = new DPerson_Accessor(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.SerializeSub(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Render"
        ///</summary>
        [TestMethod()]
        public void RenderTest()
        {
            DPerson target = new DPerson(); // TODO: Passenden Wert initialisieren
            target.Render();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "DeserializeSub"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void DeserializeSubTest()
        {
            DPerson_Accessor target = new DPerson_Accessor(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.DeserializeSub(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "DPerson-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void DPersonConstructorTest1()
        {
            DPerson target = new DPerson();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "DPerson-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void DPersonConstructorTest()
        {
            string name = string.Empty; // TODO: Passenden Wert initialisieren
            DPerson target = new DPerson(name);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
