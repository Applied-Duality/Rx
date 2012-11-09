using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Tx;
using Microsoft.Etw;
using Microsoft.Etw.Microsoft_Windows_Kernel_Network;
using System.Net;

namespace TxSamples.Playback_RealTime
{
    class Program
    {
        static void Main()
        {
            Playback playback = new Playback();
            playback.AddRealTimeSession("tcp");

            var recv = from req in playback.GetObservable<KNetEvt_RecvIPV4>()
                        select new
                        {
                            Time = req.OccurenceTime,
                            Size = req.size,
                            Address = new IPAddress(req.daddr)
                        };


            recv.Subscribe(e=>Console.WriteLine("{0} : Received {1,5} bytes from {2}", e.Time, e.Size, e.Address));

            playback.Start();
        }
    }
}
