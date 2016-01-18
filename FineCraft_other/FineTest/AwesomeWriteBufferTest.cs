using FineCraft.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AwesomeWriteBufferTest" und soll
    ///alle AwesomeWriteBufferTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AwesomeWriteBufferTest
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
        ///Ein Test für "Position"
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            long expected = 0; // TODO: Passenden Wert initialisieren
            long actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Length"
        ///</summary>
        [TestMethod()]
        public void LengthTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            long actual;
            actual = target.Length;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CanWrite"
        ///</summary>
        [TestMethod()]
        public void CanWriteTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.CanWrite;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CanSeek"
        ///</summary>
        [TestMethod()]
        public void CanSeekTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.CanSeek;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CanRead"
        ///</summary>
        [TestMethod()]
        public void CanReadTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.CanRead;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Write"
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            byte[] buffer = null; // TODO: Passenden Wert initialisieren
            int offset = 0; // TODO: Passenden Wert initialisieren
            int count = 0; // TODO: Passenden Wert initialisieren
            target.Write(buffer, offset, count);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SetLength"
        ///</summary>
        [TestMethod()]
        public void SetLengthTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            long value = 0; // TODO: Passenden Wert initialisieren
            target.SetLength(value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Seek"
        ///</summary>
        [TestMethod()]
        public void SeekTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            long offset = 0; // TODO: Passenden Wert initialisieren
            SeekOrigin origin = new SeekOrigin(); // TODO: Passenden Wert initialisieren
            long expected = 0; // TODO: Passenden Wert initialisieren
            long actual;
            actual = target.Seek(offset, origin);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Read"
        ///</summary>
        [TestMethod()]
        public void ReadTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            byte[] buffer = null; // TODO: Passenden Wert initialisieren
            int offset = 0; // TODO: Passenden Wert initialisieren
            int count = 0; // TODO: Passenden Wert initialisieren
            int expected = 0; // TODO: Passenden Wert initialisieren
            int actual;
            actual = target.Read(buffer, offset, count);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Flush"
        ///</summary>
        [TestMethod()]
        public void FlushTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying); // TODO: Passenden Wert initialisieren
            target.Flush();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "AwesomeWriteBuffer-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void AwesomeWriteBufferConstructorTest()
        {
            Stream underlying = null; // TODO: Passenden Wert initialisieren
            AwesomeWriteBuffer target = new AwesomeWriteBuffer(underlying);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
