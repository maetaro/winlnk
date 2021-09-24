using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public class LinkInfoParser
    {
        public static LinkInfo Parse(BinaryReaderEx reader)
        {
            var linkInfoFirstPosition = reader.Position;
            var entity = new LinkInfo();
            entity.LinkInfoSize = reader.ReadUInt32();
            entity.LinkInfoHeaderSize = reader.ReadUInt32();
            entity.LinkInfoFlags = LinkInfoFlags.FromBinary(reader.ReadBytes(4));
            entity.VolumeIDOffset = reader.ReadUInt32();
            entity.LocalBasePathOffset = reader.ReadUInt32();
            entity.CommonNetworkRelativeLinkOffset = reader.ReadUInt32();
            entity.CommonPathSuffixOffset = reader.ReadUInt32();
            if (entity.LinkInfoHeaderSize >= 0x24)
            {
                entity.LocalBasePathOffsetUnicode = reader.ReadUInt32();
                entity.CommonPathSuffixOffsetUnicode = reader.ReadUInt32();
            }
            if (entity.LinkInfoFlags.VolumeIDAndLocalBasePath)
            {
                entity.VolumeID = VolumeIDParser.Parse(reader);
                entity.LocalBasePath = reader.ReadNullTerminatedString();
            }
            if (entity.LinkInfoFlags.CommonNetworkRelativeLinkAndPathSuffix)
            {
                entity.CommonNetworkRelativeLink = CommonNetworkRelativeLinkParser.Parse(reader);
            }
            if (entity.CommonPathSuffixOffset > 0)
            {
                reader.Seek(linkInfoFirstPosition + entity.CommonPathSuffixOffset);
                entity.CommonPathSuffix = reader.ReadNullTerminatedString();
            }
            if (entity.LinkInfoFlags.VolumeIDAndLocalBasePath && entity.LinkInfoHeaderSize >= 0x00000024)
            {
                reader.Seek(linkInfoFirstPosition + entity.LocalBasePathOffsetUnicode);
                entity.LocalBasePathUnicode = reader.ReadNullTerminatedUnicodeString();
            }
            if (entity.LinkInfoHeaderSize >= 0x00000024)
            {
                reader.Seek(linkInfoFirstPosition + entity.CommonPathSuffixOffsetUnicode);
                entity.CommonPathSuffixUnicode = reader.ReadNullTerminatedUnicodeString();
            }

            return entity;
        }

        public static void Serialize(Stream stream, LinkInfo entity)
        {
            stream.Write(BitConverter.GetBytes(entity.LinkInfoSize), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.LinkInfoHeaderSize), 0, 4);
            stream.Write(entity.LinkInfoFlags.ToByteArray(), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.VolumeIDOffset), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.LocalBasePathOffset), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.CommonNetworkRelativeLinkOffset), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.CommonPathSuffixOffset), 0, 4);
            if (entity.LinkInfoHeaderSize >= 0x24)
            {
                stream.Write(BitConverter.GetBytes(entity.LocalBasePathOffsetUnicode), 0, 4);
                stream.Write(BitConverter.GetBytes(entity.CommonPathSuffixOffsetUnicode), 0, 4);
            }
            if (entity.LinkInfoFlags.VolumeIDAndLocalBasePath)
            {
                VolumeIDParser.Serialize(stream, entity.VolumeID);
                var buff = System.Text.Encoding.Default.GetBytes(entity.LocalBasePath);
                stream.Write(buff, 0, buff.Length);
            }
            if (entity.LinkInfoFlags.CommonNetworkRelativeLinkAndPathSuffix)
            {
                CommonNetworkRelativeLinkParser.Serialize(stream, entity.CommonNetworkRelativeLink);
            }
            //if (entity.CommonPathSuffixOffset > 0)
            //{
            //    reader.Seek(linkInfoFirstPosition + entity.CommonPathSuffixOffset);
            //    entity.CommonPathSuffix = reader.ReadNullTerminatedString();
            //}
            //if (entity.LinkInfoFlags.VolumeIDAndLocalBasePath && entity.LinkInfoHeaderSize >= 0x00000024)
            //{
            //    reader.Seek(linkInfoFirstPosition + entity.LocalBasePathOffsetUnicode);
            //    entity.LocalBasePathUnicode = reader.ReadNullTerminatedUnicodeString();
            //}
            //if (entity.LinkInfoHeaderSize >= 0x00000024)
            //{
            //    reader.Seek(linkInfoFirstPosition + entity.CommonPathSuffixOffsetUnicode);
            //    entity.CommonPathSuffixUnicode = reader.ReadNullTerminatedUnicodeString();
            //}
        }
    }
}
