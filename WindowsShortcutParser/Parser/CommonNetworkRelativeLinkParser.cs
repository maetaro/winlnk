using System;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public static class CommonNetworkRelativeLinkParser
    {
        public static CommonNetworkRelativeLink Parse(BinaryReaderEx reader)
        {
            var entity = new CommonNetworkRelativeLink();
            entity.CommonNetworkRelativeLinkSize = reader.ReadUInt32();
            entity.CommonNetworkRelativeLinkFlags = CommonNetworkRelativeLinkFlags.FromBinary(reader.ReadBytes(4));
            entity.NetNameOffset = reader.ReadUInt32();
            entity.DeviceNameOffset = reader.ReadUInt32();
            var npt = (NetworkProviderType)Enum.ToObject(typeof(NetworkProviderType), (int)reader.ReadUInt32());
            if (Enum.IsDefined(typeof(NetworkProviderType), npt))
            {
                entity.NetworkProviderType = npt;
            }
            if (entity.NetNameOffset > 0x00000014)
            {
                entity.NetNameOffsetUnicode = reader.ReadUInt32();
                entity.DeviceNameOffsetUnicode = reader.ReadUInt32();
            }
            entity.NetName = reader.ReadNullTerminatedString();
            entity.DeviceName = reader.ReadNullTerminatedString();
            if (entity.NetNameOffset > 0x00000014)
            {
                entity.NetNameUnicode = reader.ReadNullTerminatedUnicodeString();
                entity.DeviceNameUnicode = reader.ReadNullTerminatedUnicodeString();
            }
            return entity;
        }
    }
}
