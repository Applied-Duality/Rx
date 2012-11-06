using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Tx;
using Microsoft.Etw;

namespace _3_EtwFilesTemporal
{
    class Program
    {
        // In this sample we have a Temporal query
        // i.e. the result of the query are not based on system time (time of reading events from file) 
        // but application time (timestamps on the events)
        
        static void Main(string[] args)
        {
            var session = EtwObservable.FromFiles(@"..\..\..\HTTP_Server.etl");

            TimeSource<EtwNativeEvent> timeSource = new TimeSource<EtwNativeEvent>(session,
                e => e.TimeStamp);

                DateTimeOffset startTime = new DateTimeOffset(2011, 1, 23, 22, 7, 27, TimeSpan.Zero);
            ((HistoricalScheduler)timeSource.Scheduler).AdvanceTo(startTime); // hack, the source should start with this time

            var buffers = timeSource
                            .Where(e => e.Id == 2)
                            .Take(13)
                            .Select(e => e.TimeStamp)
                            .Buffer(TimeSpan.FromSeconds(1), timeSource.Scheduler);

            int count = 0;
            buffers.Subscribe(b =>
                {
                    Console.WriteLine("---- {0} ----", count++);
                    foreach (DateTimeOffset t in b)
                    {
                        Console.WriteLine(t);
                    }
                });

            timeSource.Connect();
            Console.ReadLine();
         }
    }
}
