﻿using System;
using System.Collections.Generic;

namespace Tx.Windows
{
    public class ManifestEventPartitionKey
    {
        public Guid ProviderId { get; set; }
        public ushort EventId { get; set; }
        public byte Version { get; set; }

        public class Comparer : IEqualityComparer<ManifestEventPartitionKey>
        {
            public bool Equals(ManifestEventPartitionKey x, ManifestEventPartitionKey y)
            {
                return (x.EventId == y.EventId) &&
                    (x.ProviderId == y.ProviderId) &&
                    (x.Version == y.Version);
            }

            public int GetHashCode(ManifestEventPartitionKey obj)
            {
                return (int)obj.EventId;
            }
        }
    }
}
