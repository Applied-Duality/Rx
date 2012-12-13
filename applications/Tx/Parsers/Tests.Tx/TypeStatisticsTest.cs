using System;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Reflection;
using Microsoft.Etw;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Evtx;

namespace Tests.Tx
{
    [TestClass]
    public class TypeStatisticsTest
    {
        string EtlFileName
        {
            get
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(dir, @"HTTP_Server.etl");
            }
        }

        string EvtxFileName
        {
            get
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(dir, @"HTTP_Server.evtx");
            }
        }

        [TestMethod]
        public void EtwTypeStatistics()
        {
            var stat = new TypeOccurenceStatistics(Assembly.GetExecutingAssembly().GetTypes());
            stat.AddEtlFiles(EtlFileName);
            stat.Run();

            Assert.AreEqual(12, stat.Statistics.Count);
        }

        [TestMethod]
        public void EvtxTypeStatistics()
        {
            var stat = new TypeOccurenceStatistics(Assembly.GetExecutingAssembly().GetTypes());
            stat.AddLogFiles(EvtxFileName);
            stat.Run();

            Assert.AreEqual(12, stat.Statistics.Count);
        }
    }
}
