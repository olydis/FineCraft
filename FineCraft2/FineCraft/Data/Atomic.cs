using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace FineCraft.Data
{
    class Atomic
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Do(Action action)
        {
            action();
        }
    }
}
