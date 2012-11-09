using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Microsoft.Evtx;

namespace TxSamples.EvtxRaw
{
    class Program
    {
        static void Main()
        {
            IEnumerable<EventRecord> evtx = EvtxEnumerable.FromFiles(@"..\..\..\HTTP_Server.evtx");
            Console.WriteLine(evtx.Count());
        }
    }
}
