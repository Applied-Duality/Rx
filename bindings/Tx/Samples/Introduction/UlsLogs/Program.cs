using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive;
using System.Reactive.Tx;

namespace UlsLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Playback playback = new Playback();
            playback.AddUlsFiles(@"..\..\WAC.log");

            var s = playback.GetObservable<LeavingMonitoredScope>();
            s.Subscribe(e => Console.Write(e.Scope));

            playback.Run();
        }
    }
}
