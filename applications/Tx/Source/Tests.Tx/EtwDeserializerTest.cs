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
using Microsoft.Etw.Microsoft_Windows_HttpService;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Reactive;

namespace Tests.Tx
{
    [TestClass]
    public class EtwDeserializerTest
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
        //public void EtwManifestDeserializerOne()
        //{
        //    var subject = new Subject<Timestamped<object>>();
        //    var deserializer = new PartitionKeyDeserializer<EtwNativeEvent, ManifestEventPartitionKey>( 
        //        new EtwManifestTypeMap(), 
        //        subject);
        //    deserializer.AddKnownType(typeof(Parse));

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

        //    var input = EtwObservable.FromFiles(FileName);
        //    input.Subscribe(deserializer);
        //    completed.WaitOne();

        //    Assert.AreEqual(291, count);
        //}

        //[TestMethod]
        //public void EtwManifestDeserializerMany()
        //{
        //    var subject = new Subject<Timestamped<object>>();
        //    var deserializer = new PartitionKeyDeserializer<EtwNativeEvent, ManifestEventPartitionKey>(
        //        new EtwManifestTypeMap(),
        //        subject);        
        //    deserializer.AddKnownType(typeof(Parse));
        //    deserializer.AddKnownType(typeof(FastSend));
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

        //    var input = EtwObservable.FromFiles(FileName);
        //    input.Subscribe(deserializer);
        //    completed.WaitOne();

        //    Assert.AreEqual(871, count);
        //}
    }
}
