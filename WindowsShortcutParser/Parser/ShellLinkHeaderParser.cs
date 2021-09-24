using System;
using System.Text.Json;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public static class ShellLinkHeaderParser
    {
        public static ShellLinkHeader Deserialize(BinaryReaderEx reader)
        {
            var entity = new ShellLinkHeader();
            entity.HeaderSize = reader.ReadInt32();
            entity.LinkCLSID = new Guid(reader.ReadBytes(16));
            entity.LinkFlags = LinkFlags.FromBinary(reader.ReadBytes(4));
            entity.FileAttributes = FileAttributes.FromBinary(reader.ReadBytes(4));
            entity.CreationTime = DateTime.FromFileTime(reader.ReadInt64());
            entity.AccessTime = DateTime.FromFileTime(reader.ReadInt64());
            entity.WriteTime = DateTime.FromFileTime(reader.ReadInt64());
            entity.FileSize = reader.ReadUInt32();
            entity.IconIndex = reader.ReadInt32();
            entity.ShowCommand = reader.ReadUInt32();
            entity.HotKey = HotKeyFlags.FromBinary(reader.ReadBytes(2));
            entity.Reserved1 = reader.ReadBytes(2);
            entity.Reserved2 = reader.ReadBytes(4);
            entity.Reserved3 = reader.ReadBytes(4);
            return entity;
        }

        public static void Serialize(System.IO.Stream stream, ShellLinkHeader entity)
        {
            stream.Write(BitConverter.GetBytes(entity.HeaderSize), 0, 4);
            stream.Write(entity.LinkCLSID.ToByteArray(), 0, 16);
            stream.Write(entity.LinkFlags.ToByteArray(), 0, 4);
            stream.Write(entity.FileAttributes.ToByteArray(), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.CreationTime.ToFileTime()), 0, 8);
            stream.Write(BitConverter.GetBytes(entity.AccessTime.ToFileTime()), 0, 8);
            stream.Write(BitConverter.GetBytes(entity.WriteTime.ToFileTime()), 0, 8);
            stream.Write(BitConverter.GetBytes(entity.FileSize), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.IconIndex), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.ShowCommand), 0, 4);
            stream.Write(entity.HotKey.ToByteArray(), 0, 2);
            stream.Write(entity.Reserved1, 0, 2);
            stream.Write(entity.Reserved2, 0, 4);
            stream.Write(entity.Reserved3, 0, 4);
        }
    }
}
