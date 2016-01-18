using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using System.Threading;
using FineCraft.HybridData;
using System.Runtime.CompilerServices;
using FineCraft;

namespace Server
{
    public class Service
    {
        public Service(MainWindow host)
        {
            this.host = host;
            HelpfulStuff.RunPeriodic(SendSettings, 1000);
        }

        MainWindow host;

        int send = 0;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SendSettings()
        {
            send = (send + 1) % 30;
            var settings = SettingsSingleton.TryGetSettings();
            if (settings != null)
            {
                settings.s.Tick();
                if(send % 30 == 0)
                {
                    host.SendBroadcast(settings.s);
                    settings.MakeDirty();
                }
            }
        }
    }
}
