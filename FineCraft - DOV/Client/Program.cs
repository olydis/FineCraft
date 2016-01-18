using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FineCraft;
using System.Diagnostics;

namespace Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Init();
            try
            {
                //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            catch(Exception e)
            {
                Log.HandleException(e);
            }
        }
    }
}
