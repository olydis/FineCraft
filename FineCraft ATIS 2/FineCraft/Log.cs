using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace FineCraft
{
    public static class Log
    {
        public static void Init()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        public static void HandleException(Exception e)
        {
            if (e == null)
            {
                MessageBox.Show("There was some shit going on.",Application.ProductName);
                return;
            }
            //File.WriteAllText("C:\\joch.txt", e.Message + "\r\n" + e.StackTrace);
            MessageBox.Show(e.Message + "\n" + e.StackTrace);
        }
    }
}
