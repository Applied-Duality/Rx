using System;
using System.Reactive.Linq;
using Microsoft.Etw;

namespace EtwFiles
{
    class Program
    {
        // This sample illustrates how to read .ETL (Event Trace Log) files

        static void Main(string[] args)
        {
            var session = EtwObservable.FromFiles(@"..\..\..\HTTP_Server.etl");
            int count = session.Count().First();

            Console.WriteLine(count);
        }
    }
}
