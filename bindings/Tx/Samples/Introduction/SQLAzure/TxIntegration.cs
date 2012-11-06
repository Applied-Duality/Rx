using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Globalization;

namespace SQLAzure
{
    class PartitionEvent
    {
        public DateTime Timeflag { get; set; }
        public string PartitionId { get; set; }
    }

    class TraceLineMap : IRootTypeMap<TraceLine, PartitionEvent>
    {
        IObserver<Timestamped<object>> _observer;

        public Func<TraceLine, DateTimeOffset> TimeFunction
        {
            get { return e => e.Timeflag; }
        }

        public Func<TraceLine, object> GetTransform(Type outputType)
        {
            return e => new PartitionEvent { Timeflag = e.Timeflag, PartitionId = GetPartitionId(e.Detail) };
        }

        const string prefix = "partitionKey '0x";

        static string GetPartitionId(string detail)
        {
            int index = detail.IndexOf(prefix);
            return detail.Substring(index + prefix.Length, 16);
        }
    }

    public static class PlaybackExtensions
    {
        public static void AddTextTrace(this IPlaybackConfiguration playback, string file)
        {
            playback.AddInput(
                () => CsvEnumerable.ReadFile(file).ToObservable(ThreadPoolScheduler.Instance), 
                typeof(TraceLineMap));
        }
    }
}
