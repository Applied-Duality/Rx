using System;
using System.Reactive.Linq;
using System.Reactive.Tx;
using Microsoft.Etw;
using Microsoft.Evtx;

namespace TxSamples.Playback_All
{
    class Program
    {
        static void Main()
        {
            Playback playback = new Playback();
            playback.AddEtlFiles(@"..\..\..\HTTP_Server.etl");
            playback.AddLogFiles(@"..\..\..\HTTP_Server.evtx");

            IObservable<SystemEvent> all = playback.GetObservable<SystemEvent>();

            all.Count().Subscribe(Console.WriteLine);

            playback.Run();
        }
    }
}
