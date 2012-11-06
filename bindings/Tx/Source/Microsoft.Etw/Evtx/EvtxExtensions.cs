using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Tx;
using Microsoft.Evtx;
using System.Reactive.Concurrency;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Etw;

namespace Microsoft.Evtx
{
    public static class EvtxExtensions
    {
        [FileParser(".evtx", "Event Log")]
        public static void AddLogFiles(this IPlaybackConfiguration playback, params string[] files)
        {
            playback.AddInput(
                () => EvtxEnumerable.FromFiles(files).ToObservable(ThreadPoolScheduler.Instance),
                typeof(EvtxManifestTypeMap),
                typeof(EvtxTypeMap));
        }
    }
}
