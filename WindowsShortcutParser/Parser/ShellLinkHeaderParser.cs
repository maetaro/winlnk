using System;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public static class ShellLinkHeaderParser
    {
        public static ShellLinkHeader Parse(BinaryReaderEx reader)
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
    }
}
