using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "CDictionaryTest" und soll
    ///alle CDictionaryTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class CDictionaryTest
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
        ///Ein Test für "Values"
        ///</summary>
        public void ValuesTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            List<TValue> actual;
            actual = target.Values;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void ValuesTest()
        {
            ValuesTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Keys"
        ///</summary>
        public void KeysTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            List<TKey> actual;
            actual = target.Keys;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void KeysTest()
        {
            KeysTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Item"
        ///</summary>
        public void ItemTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            TKey key = default(TKey); // TODO: Passenden Wert initialisieren
            TValue expected = default(TValue); // TODO: Passenden Wert initialisieren
            TValue actual;
            target[key] = expected;
            actual = target[key];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "AsEnumerable"
        ///</summary>
        public void AsEnumerableTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            List<KeyValuePair<TKey, TValue>> actual;
            actual = target.AsEnumerable;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void AsEnumerableTest()
        {
            AsEnumerableTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Remove"
        ///</summary>
        public void RemoveTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            TKey key = default(TKey); // TODO: Passenden Wert initialisieren
            target.Remove(key);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void RemoveTest()
        {
            RemoveTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "ContainsKey"
        ///</summary>
        public void ContainsKeyTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            TKey key = default(TKey); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.ContainsKey(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        [TestMethod()]
        public void ContainsKeyTest()
        {
            ContainsKeyTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Clear"
        ///</summary>
        public void ClearTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            target.Clear();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void ClearTest()
        {
            ClearTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "Add"
        ///</summary>
        public void AddTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>(); // TODO: Passenden Wert initialisieren
            TKey key = default(TKey); // TODO: Passenden Wert initialisieren
            TValue value = default(TValue); // TODO: Passenden Wert initialisieren
            target.Add(key, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///Ein Test für "CDictionary`2-Konstruktor"
        ///</summary>
        public void CDictionaryConstructorTestHelper<TKey, TValue>()
        {
            CDictionary<TKey, TValue> target = new CDictionary<TKey, TValue>();
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        [TestMethod()]
        public void CDictionaryConstructorTest()
        {
            CDictionaryConstructorTestHelper<GenericParameterHelper, GenericParameterHelper>();
        }
    }
}
