using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FineCraft;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Init();
            try
            {
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(new MainWindow());
            }
            catch (Exception e)
            {
                Log.HandleException(e);
            }
        }
    }
}
