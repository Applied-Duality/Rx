using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace BombActor
{
    class Program
    {
        static Random _random;

        static void Main(string[] args)
        {
            ProtocolNode.Open(OnReceived, OnTimer);
            _random = new Random(ProtocolNode.ActorId);

            Console.WriteLine("Press Enter on any of the consoles to continue");
            Console.ReadLine();

            ProtocolNode.StartAll();

            Console.WriteLine("Press Enter to terminate all");
            Console.WriteLine();
            Console.ReadLine();

            ProtocolNode.StopAll();
        }

        static void OnReceived(IBomb bomb, int from)
        {
            Trace.WriteLine(String.Format("{0} A {1} Received {2} from {3}",
                ProtocolNode.ActorId,
                ProtocolNode.LocalCounter,
                bomb.GetType().Name,
                from));
        }

        static void OnTimer(object state)
        {
            int r = _random.Next(10);

            if (r == 0)
            {
                int to = _random.Next(ProtocolNode.Actors.Length);
                Trace.WriteLine(String.Format("{0} A {1} sending Time Bomb to {2}",
                    ProtocolNode.ActorId,
                    ProtocolNode.LocalCounter,
                    to));
                ProtocolNode.Send(new TimeBomb(), to);
            }
            else
            {
                Trace.WriteLine(String.Format("{0} A {1} ...",
                    ProtocolNode.ActorId,
                    ProtocolNode.LocalCounter));

                return;
            }
        }
    }
}
