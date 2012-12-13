using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Reflection;
using Microsoft.Etw;
using Microsoft.Evtx;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Etw.Microsoft_Windows_HttpService;
using System;
using System.Collections.Generic;

namespace Tests.Tx
{
    [TestClass]
    public class PullMergeSortTest
    {
        [TestMethod]
        public void MissingSample()
        {
            // This is test for specific bug reproted by Miles Trochesset 
            // The sample 2 in the example below was missing and 22 was duplicated
            int[] log1 = { 1, 11, 21 };
            int[] log2 = { 2, 12, 22 };
            List<IEnumerator<int>> inputs = new List<IEnumerator<int>>();
            inputs.Add(((IEnumerable<int>)log1).GetEnumerator());
            inputs.Add(((IEnumerable<int>)log2).GetEnumerator());

            PullMergeSort<int> sort = new PullMergeSort<int>(
                 i => DateTime.MinValue.AddSeconds(i),
                 inputs);

            var all = sort.ToArray();

            Assert.AreEqual(all.Count(), 6);
            Assert.AreEqual(all[1], 2);
        }
    }
}
