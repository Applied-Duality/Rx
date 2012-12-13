using System;

namespace Tx.Windows
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ManifestEventAttribute : Attribute
    {
        readonly Guid _providerGuid;
        readonly uint _eventId;
        readonly byte _version;

        public ManifestEventAttribute(string providerGuid, uint eventId, byte version)
        {
            _providerGuid = new Guid(providerGuid);
            _eventId = eventId;
            _version = version;
        }

        public Guid ProviderGuid { get { return _providerGuid; } }
        public uint EventId { get { return _eventId; } }
        public byte Version { get { return _version; } }
    }
}