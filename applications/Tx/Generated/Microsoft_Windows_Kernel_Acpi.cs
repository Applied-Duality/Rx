// 
//    This code was generated by EtwEventTypeGen.exe 
//

using System;

namespace Tx.Windows.Microsoft_Windows_Kernel_Acpi
{
    [ManifestEvent("{c514638f-7723-485b-bcfc-96565d735d4a}", 5, 0)]
    [Format("The active cooling device %6 has been turned %8.              Thermal zone device instance: %2              Active cooling package: _AC%3              Namespace object: _AL%4")]
    public class __5 : SystemEvent
    {
        [EventField("win:UInt16")]
        public ushort ThermalZoneDeviceInstanceLength { get; set; }

        [EventField("win:UnicodeString")]
        public string ThermalZoneDeviceInstance { get; set; }

        [EventField("win:UInt32")]
        public uint ActiveCoolingLevel { get; set; }

        [EventField("win:UInt32")]
        public uint ActiveCoolingDeviceIndex { get; set; }

        [EventField("win:UInt16")]
        public ushort FanDeviceInstanceLength { get; set; }

        [EventField("win:UnicodeString")]
        public string FanDeviceInstance { get; set; }

        [EventField("win:UInt16")]
        public ushort PowerStateLength { get; set; }

        [EventField("win:UnicodeString")]
        public string PowerState { get; set; }
    }

    [ManifestEvent("{c514638f-7723-485b-bcfc-96565d735d4a}", 4, 0)]
    [Format("A trip point change notification (Notify(thermal_zone, 0x81)) for ACPI thermal zone %2 has been received.              _TMP = %3K              _PSV = %4K              _AC0 = %5K              _AC1 = %6K              _AC2 = %7K              _AC3 = %8K              _AC4 = %9K              _AC5 = %10K              _AC6 = %11K              _AC7 = %12K              _AC8 = %13K              _AC9 = %14K              _HOT = %15K              _CRT = %16K")]
    public class __4 : SystemEvent
    {
        [EventField("win:UInt16")]
        public ushort ThermalZoneDeviceInstanceLength { get; set; }

        [EventField("win:UnicodeString")]
        public string ThermalZoneDeviceInstance { get; set; }

        [EventField("win:UInt32")]
        public uint _TMP { get; set; }

        [EventField("win:UInt32")]
        public uint _PSV { get; set; }

        [EventField("win:UInt32")]
        public uint _AC0 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC1 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC2 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC3 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC4 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC5 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC6 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC7 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC8 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC9 { get; set; }

        [EventField("win:UInt32")]
        public uint _HOT { get; set; }

        [EventField("win:UInt32")]
        public uint _CRT { get; set; }
    }

    [ManifestEvent("{c514638f-7723-485b-bcfc-96565d735d4a}", 3, 0)]
    [Format("A temperature change notification (Notify(thermal_zone, 0x80)) for ACPI thermal zone %2 has been received.              _TMP = %3K              _PSV = %4K              _AC0 = %5K              _AC1 = %6K              _AC2 = %7K              _AC3 = %8K              _AC4 = %9K              _AC5 = %10K              _AC6 = %11K              _AC7 = %12K              _AC8 = %13K              _AC9 = %14K              _HOT = %15K              _CRT = %16K")]
    public class __3 : SystemEvent
    {
        [EventField("win:UInt16")]
        public ushort ThermalZoneDeviceInstanceLength { get; set; }

        [EventField("win:UnicodeString")]
        public string ThermalZoneDeviceInstance { get; set; }

        [EventField("win:UInt32")]
        public uint _TMP { get; set; }

        [EventField("win:UInt32")]
        public uint _PSV { get; set; }

        [EventField("win:UInt32")]
        public uint _AC0 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC1 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC2 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC3 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC4 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC5 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC6 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC7 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC8 { get; set; }

        [EventField("win:UInt32")]
        public uint _AC9 { get; set; }

        [EventField("win:UInt32")]
        public uint _HOT { get; set; }

        [EventField("win:UInt32")]
        public uint _CRT { get; set; }
    }

    [ManifestEvent("{c514638f-7723-485b-bcfc-96565d735d4a}", 2, 0)]
    [Format("Unexpected GPE event was fired on GPE bits that should be disabled.")]
    public class GpeEventHandling__2 : SystemEvent
    {
        [EventField("win:UInt32")]
        public uint GpeRegister { get; set; }

        [EventField("win:UInt8")]
        public byte UnexpectedEventMap { get; set; }
    }

    [ManifestEvent("{c514638f-7723-485b-bcfc-96565d735d4a}", 1, 0)]
    [Format("A memory range descriptor has been marked as reserved.")]
    public class ResourceTranslation__1 : SystemEvent
    {
        [EventField("win:UInt8")]
        public byte ResourceFlag { get; set; }

        [EventField("win:UInt8")]
        public byte GeneralFlag { get; set; }

        [EventField("win:UInt8")]
        public byte TypeSpecificFlag { get; set; }

        [EventField("win:UInt64")]
        public ulong Granularity { get; set; }

        [EventField("win:UInt64")]
        public ulong AddressMin { get; set; }

        [EventField("win:UInt64")]
        public ulong AddressMax { get; set; }

        [EventField("win:UInt64")]
        public ulong AddressTranslation { get; set; }

        [EventField("win:UInt64")]
        public ulong AddressLength { get; set; }
    }

}