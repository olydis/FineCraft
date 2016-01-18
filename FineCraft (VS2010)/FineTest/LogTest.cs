using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "LogTest" und soll
    ///alle LogTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class LogTest
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
        ///Ein Test für "Init"
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            Log.Init();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "HandleException"
        ///</summary>
        [TestMethod()]
        public void HandleExceptionTest()
        {
            Exception e = null; // TODO: Passenden Wert initialisieren
            Log.HandleException(e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "CurrentDomain_UnhandledException"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void CurrentDomain_UnhandledExceptionTest()
        {
            object sender = null; // TODO: Passenden Wert initialisieren
            UnhandledExceptionEventArgs e = null; // TODO: Passenden Wert initialisieren
            Log_Accessor.CurrentDomain_UnhandledException(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Application_ThreadException"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void Application_ThreadExceptionTest()
        {
            object sender = null; // TODO: Passenden Wert initialisieren
            ThreadExceptionEventArgs e = null; // TODO: Passenden Wert initialisieren
            Log_Accessor.Application_ThreadException(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
