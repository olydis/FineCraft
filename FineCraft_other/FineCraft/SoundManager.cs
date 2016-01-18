using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using System.Media;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.DirectX.DirectSound;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FineCraft
{
    public static class SoundManager
    {
        static SoundManager()
        {
        }

        public static bool Mute { get; set; }

        public static void PlayForever()
        {
            ThreadStart play = () =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                    DirectoryInfo di = HelpfulStuff.BaseDirectory;

                    try
                    {
                        Device sounddevice = new Device();
                        sounddevice.SetCooperativeLevel(Static.Window, CooperativeLevel.Normal);

                        BufferDescription description = new BufferDescription();
                        description.ControlEffects = false;
                        description.ControlVolume = true;
                        while (true)
                        {
                            foreach (FileInfo file in di.GetFiles("*.wav"))
                                try
                                {
                                    SecondaryBuffer shotsound = new SecondaryBuffer(file.FullName, description, sounddevice);
                                    try
                                    {
                                        shotsound.Play(0, BufferPlayFlags.Default);
                                        while (shotsound.Status.Playing)
                                        {
                                            shotsound.Volume = Mute ? -10000 : 0;
                                            Thread.Sleep(100);
                                        }
                                        Thread.Sleep(2000);
                                    }
                                    catch { shotsound.Dispose(); }
                                }
                                catch { }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("DirectSound initialization failed. You won`t have music...");
                        return;
                    }
                };
            new Thread(play).Start();
        }
    }
}
