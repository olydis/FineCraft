using FineCraft.HybridData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "HybridObjectTest" und soll
    ///alle HybridObjectTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class HybridObjectTest
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
        ///Ein Test für "LifeCount"
        ///</summary>
        [TestMethod()]
        public void LifeCountTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.LifeCount;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Key"
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Key;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Class"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void ClassTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            HybridObject_Accessor target = new HybridObject_Accessor(param0); // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.Class;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "WhoKnows"
        ///</summary>
        [TestMethod()]
        public void WhoKnowsTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            IEnumerable<uint> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<uint> actual;
            actual = target.WhoKnows();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "visitorThread"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void visitorThreadTest()
        {
            object joch = null; // TODO: Passenden Wert initialisieren
            HybridObject_Accessor.visitorThread(joch);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Visit"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void VisitTest()
        {
            HybridObject o = null; // TODO: Passenden Wert initialisieren
            HybridObject_Accessor.Visit(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Useless"
        ///</summary>
        [TestMethod()]
        public void UselessTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            target.Useless(userid);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UnregisterUser"
        ///</summary>
        [TestMethod()]
        public void UnregisterUserTest()
        {
            uint userid = 0; // TODO: Passenden Wert initialisieren
            HybridObject.UnregisterUser(userid);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "UnregisterObject"
        ///</summary>
        [TestMethod()]
        public void UnregisterObjectTest()
        {
            HybridObject o = null; // TODO: Passenden Wert initialisieren
            HybridObject.UnregisterObject(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "TryGetObject"
        ///</summary>
        public void TryGetObjectTestHelper<T>()
            where T : HybridObject, new()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            T expected = new T(); // TODO: Passenden Wert initialisieren
            T actual;
            actual = HybridObject.TryGetObject<T>(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void TryGetObjectTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie TryGetObjectTestHelper<T>() mit geeigneten Typparametern auf." +
                    "");
        }

        /// <summary>
        ///Ein Test für "ToString"
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        internal virtual HybridObject_Accessor CreateHybridObject_Accessor()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            HybridObject_Accessor target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "Save"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SaveTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            HybridObject_Accessor target = new HybridObject_Accessor(param0); // TODO: Passenden Wert initialisieren
            target.Save();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "RegisterNewObject"
        ///</summary>
        [TestMethod()]
        public void RegisterNewObjectTest()
        {
            HybridObject o = null; // TODO: Passenden Wert initialisieren
            bool isdirty = false; // TODO: Passenden Wert initialisieren
            HybridObject.RegisterNewObject(o, isdirty);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        internal virtual HybridObject CreateHybridObject()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            HybridObject target = null;
            return target;
        }

        /// <summary>
        ///Ein Test für "MakeDirty"
        ///</summary>
        [TestMethod()]
        public void MakeDirtyTest()
        {
            HybridObject target = CreateHybridObject(); // TODO: Passenden Wert initialisieren
            IEnumerable<uint> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<uint> actual;
            actual = target.MakeDirty();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Load"
        ///</summary>
        public void LoadTestHelper<T>()
            where T : HybridObject, new()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            HybridObject_Accessor.Load<T>(key);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void LoadTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie LoadTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "HasObject"
        ///</summary>
        public void HasObjectTestHelper<T>()
            where T : HybridObject
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = HybridObject.HasObject<T>(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void HasObjectTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie HasObjectTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "GetObject"
        ///</summary>
        public void GetObjectTest1Helper<T>()
            where T : HybridObject, new()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            uint userid = 0; // TODO: Passenden Wert initialisieren
            T expected = new T(); // TODO: Passenden Wert initialisieren
            T actual;
            actual = HybridObject.GetObject<T>(key, userid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void GetObjectTest1()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie GetObjectTest1Helper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "GetObject"
        ///</summary>
        public void GetObjectTestHelper<T>()
            where T : HybridObject, new()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            T expected = new T(); // TODO: Passenden Wert initialisieren
            T actual;
            actual = HybridObject.GetObject<T>(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void GetObjectTest()
        {
            Assert.Inconclusive("Es wurde kein geeigneter Typparameter gefunden, der die Typeinschränkungen von T " +
                    "erfüllt. Rufen Sie GetObjectTestHelper<T>() mit geeigneten Typparametern auf.");
        }

        /// <summary>
        ///Ein Test für "GetLoaded"
        ///</summary>
        [TestMethod()]
        public void GetLoadedTest()
        {
            IEnumerable<HybridObject> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<HybridObject> actual;
            actual = HybridObject.GetLoaded();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetAvailable"
        ///</summary>
        public void GetAvailableTestHelper<T>()
        {
            IEnumerable<string> expected = null; // TODO: Passenden Wert initialisieren
            IEnumerable<string> actual;
            actual = HybridObject.GetAvailable<T>();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void GetAvailableTest()
        {
            GetAvailableTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "FileName"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void FileNameTest1()
        {
            HybridObject o = null; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = HybridObject_Accessor.FileName(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "FileName"
        ///</summary>
        public void FileNameTestHelper<T>()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = HybridObject_Accessor.FileName<T>(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void FileNameTest()
        {
            FileNameTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CacheKey"
        ///</summary>
        public void CacheKeyTest1Helper<T>()
        {
            string key = string.Empty; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = HybridObject_Accessor.CacheKey<T>(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void CacheKeyTest1()
        {
            CacheKeyTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CacheKey"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void CacheKeyTest()
        {
            HybridObject o = null; // TODO: Passenden Wert initialisieren
            string expected = string.Empty; // TODO: Passenden Wert initialisieren
            string actual;
            actual = HybridObject_Accessor.CacheKey(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
