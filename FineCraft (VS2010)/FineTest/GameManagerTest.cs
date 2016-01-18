using FineCraft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using FineCraft.Network.PacketTypes;
using FineCraft.Data;

namespace FineTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GameManagerTest" und soll
    ///alle GameManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GameManagerTest
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
        ///Ein Test für "Volume"
        ///</summary>
        [TestMethod()]
        public void VolumeTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            DynamicRangeChunkVolume actual;
            actual = target.Volume;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "UserData"
        ///</summary>
        [TestMethod()]
        public void UserDataTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            PLoginResponse expected = null; // TODO: Passenden Wert initialisieren
            PLoginResponse actual;
            target.UserData = expected;
            actual = target.UserData;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Running"
        ///</summary>
        [TestMethod()]
        public void RunningTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            target.Running = expected;
            actual = target.Running;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Orientation"
        ///</summary>
        [TestMethod()]
        public void OrientationTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            WorldOrientation actual;
            actual = target.Orientation;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "DataProvider"
        ///</summary>
        [TestMethod()]
        public void DataProviderTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            GameDataProvider actual;
            actual = target.DataProvider;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CurrentMaterial"
        ///</summary>
        [TestMethod()]
        public void CurrentMaterialTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.CurrentMaterial;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.Update(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Sync"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void SyncTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object o = null; // TODO: Passenden Wert initialisieren
            target.Sync(o);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "swap"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void swapTest()
        {
            uint a = 0; // TODO: Passenden Wert initialisieren
            uint aExpected = 0; // TODO: Passenden Wert initialisieren
            uint b = 0; // TODO: Passenden Wert initialisieren
            uint bExpected = 0; // TODO: Passenden Wert initialisieren
            GameManager_Accessor.swap(ref a, ref b);
            Assert.AreEqual(aExpected, a);
            Assert.AreEqual(bExpected, b);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "SetValue"
        ///</summary>
        [TestMethod()]
        public void SetValueTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            uint value = 0; // TODO: Passenden Wert initialisieren
            target.SetValue(pos, value);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MouseXY"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void MouseXYTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            int x = 0; // TODO: Passenden Wert initialisieren
            int y = 0; // TODO: Passenden Wert initialisieren
            target.MouseXY(x, y);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MouseWheel"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void MouseWheelTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            MouseEventArgs e = null; // TODO: Passenden Wert initialisieren
            target.MouseWheel(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MouseUp"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void MouseUpTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            MouseEventArgs e = null; // TODO: Passenden Wert initialisieren
            target.MouseUp(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "MouseDown"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void MouseDownTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            MouseEventArgs e = null; // TODO: Passenden Wert initialisieren
            target.MouseDown(sender, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "KeyUp"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void KeyUpTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            KeyEventArgs er = null; // TODO: Passenden Wert initialisieren
            target.KeyUp(sender, er);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "KeyPress"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void KeyPressTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            KeyPressEventArgs er = null; // TODO: Passenden Wert initialisieren
            target.KeyPress(sender, er);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "KeyDown"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FineCraft.dll")]
        public void KeyDownTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            GameManager_Accessor target = new GameManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            object sender = null; // TODO: Passenden Wert initialisieren
            KeyEventArgs er = null; // TODO: Passenden Wert initialisieren
            target.KeyDown(sender, er);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "HandleMouseMove"
        ///</summary>
        [TestMethod()]
        public void HandleMouseMoveTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            target.HandleMouseMove();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        [TestMethod()]
        public void GetValueTest1()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            WorldPosition pos = null; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.GetValue(pos);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "GetValue"
        ///</summary>
        [TestMethod()]
        public void GetValueTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            uint x = 0; // TODO: Passenden Wert initialisieren
            uint y = 0; // TODO: Passenden Wert initialisieren
            uint z = 0; // TODO: Passenden Wert initialisieren
            uint expected = 0; // TODO: Passenden Wert initialisieren
            uint actual;
            actual = target.GetValue(x, y, z);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "DisplayLine"
        ///</summary>
        [TestMethod()]
        public void DisplayLineTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider); // TODO: Passenden Wert initialisieren
            PChatLine line = null; // TODO: Passenden Wert initialisieren
            target.DisplayLine(line);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "GameManager-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void GameManagerConstructorTest()
        {
            Control control = null; // TODO: Passenden Wert initialisieren
            GameDataProvider dataProvider = null; // TODO: Passenden Wert initialisieren
            GameManager target = new GameManager(control, dataProvider);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }
    }
}
