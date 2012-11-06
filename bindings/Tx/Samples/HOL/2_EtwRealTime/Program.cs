using System;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Reactive.Linq;
using Microsoft.Etw;

namespace Etw
{
    // This sample illustrates how to count events from real-time session

    class Program
    {
        static void Main(string[] args)
        {
            // Setting up real-time session
            string sessionName = "TxRealTime";
            Guid providerId = new Guid("C86AFF37-01B3-438C-A623-C69FCE033110");

            StartTrace(sessionName, providerId);

            var session = EtwObservable.FromSession("TxRealTime");

            var count = from w in session.Window(TimeSpan.FromSeconds(1))
                        from c in w.Count()
                        select c;

            var subscription = count.Subscribe(Console.WriteLine);

            // Generating events into the session
            var provider = new EventProvider(providerId);
            var descriptor = new EventDescriptor(1, 0, 0, 4, 0, 0, 1);
            var observer = new EtwObserver<long>(provider, descriptor);

            var timer = Observable.Interval(TimeSpan.FromMilliseconds(10)).Subscribe(observer);

            Console.WriteLine("listening to events...");
            Console.ReadLine();
            subscription.Dispose();
            timer.Dispose();
        }

        static void StartTrace(string sessionName, Guid providerId)
        {
            Process logman = Process.Start("logman.exe", "stop TxRealTime -ets");
            logman.WaitForExit();

            logman = Process.Start("logman.exe", "create trace " + sessionName + " -rt -nb 2 2 -bs 1024 -p {" + providerId + "} -ets");
            logman.WaitForExit();
        }
    }
}
