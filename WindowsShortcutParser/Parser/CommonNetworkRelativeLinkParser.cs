using System;
using System.IO;
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
            entity.NetworkProviderType = new NetworkProviderType(reader.ReadUInt32());
            //if (entity.CommonNetworkRelativeLinkFlags.ValidNetType)
            //{
            //    entity.NetworkProviderType = npt;
            //}
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

        public static void Serialize(Stream stream, CommonNetworkRelativeLink entity)
        {
            stream.Write(BitConverter.GetBytes(entity.CommonNetworkRelativeLinkSize), 0, 4);
            stream.Write(entity.CommonNetworkRelativeLinkFlags.ToByteArray(), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.NetNameOffset), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.DeviceNameOffset), 0, 4);
        }
    }
}
