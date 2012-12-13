﻿using System;
using System.Collections.Generic;

namespace Tx.Windows
{
    public class ClassicEventPartitionKey
    {
        public Guid EventGuid { get; set; }
        public byte Opcode { get; set; }
        public byte Version { get; set; }

        public class Comparer : IEqualityComparer<ClassicEventPartitionKey>
        {
            public bool Equals(ClassicEventPartitionKey x, ClassicEventPartitionKey y)
            {
                return (x.Opcode == y.Opcode) &&
                    (x.EventGuid == y.EventGuid) &&
                    (x.Version == y.Version);
            }

            public int GetHashCode(ClassicEventPartitionKey obj)
            {
                return (int)obj.Opcode;
            }
        }
    }
}
