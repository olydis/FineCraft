using FineCraft.DynamicObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "DynamicBaseTest" und soll
    ///alle DynamicBaseTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class DynamicBaseTest
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
        ///Ein Test für "Old"
        ///</summary>
        [TestMethod()]
        public void OldTest()
        {
            DynamicBase target = CreateDynamicBase(); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Old = expected;
            actual = target.Old;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        internal virtual DynamicBase_Accessor CreateDynamicBase_Accessor()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            DynamicBase_Accessor target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "ID"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void IDTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            DynamicBase_Accessor target = new DynamicBase_Accessor(param0); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            target.ID = expected;
            actual = target.ID;
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
            // Der private-Accessor für SerializeSub wurde nicht gefunden. Erstellen Sie das Projekt neu, das den Accessor enthält, oder führen Sie "Publicize.exe" manuell aus.
            Assert.Inconclusive("Der private-Accessor für SerializeSub wurde nicht gefunden. Erstellen Sie das Pro" +
                    "jekt neu, das den Accessor enthält, oder führen Sie \"Publicize.exe\" manuell aus." +
                    "");
        }

        /// <summary>
        ///Ein Test für "Serialize"
        ///</summary>
        [TestMethod()]
        public void SerializeTest()
        {
            DynamicBase target = CreateDynamicBase(); // TODO: Passenden Wert initialisieren
            BinaryWriter writer = null; // TODO: Passenden Wert initialisieren
            target.Serialize(writer);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Render"
        ///</summary>
        [TestMethod()]
        public void RenderTest()
        {
            DynamicBase target = CreateDynamicBase(); // TODO: Passenden Wert initialisieren
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
            // Der private-Accessor für DeserializeSub wurde nicht gefunden. Erstellen Sie das Projekt neu, das den Accessor enthält, oder führen Sie "Publicize.exe" manuell aus.
            Assert.Inconclusive("Der private-Accessor für DeserializeSub wurde nicht gefunden. Erstellen Sie das P" +
                    "rojekt neu, das den Accessor enthält, oder führen Sie \"Publicize.exe\" manuell au" +
                    "s.");
        }

        internal virtual DynamicBase CreateDynamicBase()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            DynamicBase target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "Deserialize"
        ///</summary>
        [TestMethod()]
        public void DeserializeTest()
        {
            DynamicBase target = CreateDynamicBase(); // TODO: Passenden Wert initialisieren
            BinaryReader reader = null; // TODO: Passenden Wert initialisieren
            target.Deserialize(reader);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
