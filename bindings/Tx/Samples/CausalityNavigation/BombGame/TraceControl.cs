using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BombActor
{
    class TraceControl
    {
        public static void Start()
        {
            var logman = Process.Start("logman.exe", "start bombs -nb 64 512 -bs 1024 -p {8400115e-3a7a-4fb0-95ca-6121397f7c4a} 0xff -o bombs.etl -ets");
            logman.WaitForExit();
       }

        public static void Stop()
        {
            var logman = Process.Start("logman.exe", "stop bombs -ets");
            logman.WaitForExit();
        }
    }
}
