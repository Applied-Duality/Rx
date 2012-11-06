using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using Microsoft.Etw;
using Microsoft.Evtx;
using Microsoft.Etw.Microsoft_Windows_HttpService;
using System.Reactive.Concurrency;

namespace Tests.Tx
{
    [TestClass]
    public class EvtxTest
    {
        string FileName
        {
            get
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(dir, @"HTTP_Server.evtx");
            }
        }

        [TestMethod]
        public void EvtxReader()
        {
            var parser = EvtxEnumerable.FromFiles(FileName);
            int count = parser.Count();

            Assert.AreEqual(2041, count); // in ETW there is one more event with system information
        }
    }
}
