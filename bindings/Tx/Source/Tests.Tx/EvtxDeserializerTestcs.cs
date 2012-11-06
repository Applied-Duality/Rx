using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;
using Microsoft.Etw;
using Microsoft.Evtx;
using Microsoft.Etw.Microsoft_Windows_HttpService;
using System.Reactive.Concurrency;
using System.Diagnostics.Eventing.Reader;
using System.Reactive.Subjects;
using System.Reactive;

namespace Tests.Tx
{
    [TestClass]
    public class EvtxDeserializerTestcs
    {
        string FileName
        {
            get
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(dir, @"HTTP_Server.etl");
            }
        }

        //[TestMethod]
        //public void EvtxManifestDeserializerOne()
        //{
        //    var subject = new Subject<Timestamped<object>>();
        //    var deserializer = new PartitionKeyDeserializer<EventRecord, ManifestEventPartitionKey>(
        //        new EvtxManifestTypeMap(),
        //        subject);

        //    deserializer.AddKnownType(typeof(Deliver));

        //    ManualResetEvent completed = new ManualResetEvent(false);
        //    int count = 0;
        //    subject.Subscribe(
        //        p =>
        //        {
        //            count++;
        //        },
        //        () =>
        //        {
        //            completed.Set();
        //        });

        //    var input = EvtxEnumerable.FromFiles(FileName).ToObservable();
        //    input.Subscribe(deserializer);
        //    completed.WaitOne();

        //    Assert.AreEqual(291, count);
        //}

        //[TestMethod]
        //public void EvtxanifestDeserializerMany()
        //{
        //    var subject = new Subject<Timestamped<object>>();
        //    var deserializer = new PartitionKeyDeserializer<EventRecord, ManifestEventPartitionKey>(
        //        new EvtxManifestTypeMap(),
        //        subject); 

        //    deserializer.AddKnownType(typeof(Deliver));
        //    deserializer.AddKnownType(typeof(FastResp));

        //    ManualResetEvent completed = new ManualResetEvent(false);
        //    int count = 0;
        //    subject.Subscribe(
        //        p =>
        //        {
        //            count++;
        //        },
        //        () =>
        //        {
        //            completed.Set();
        //        });

        //    var input = EvtxEnumerable.FromFiles(FileName).ToObservable();
        //    input.Subscribe(deserializer);
        //    completed.WaitOne();

        //    Assert.AreEqual(580, count);
        //}
    }
}
