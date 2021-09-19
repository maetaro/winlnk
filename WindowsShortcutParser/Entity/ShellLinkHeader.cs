using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public partial class ShellLinkHeader
    {
        public bool HasLinkTargetIDList
        {
            get
            {
                return LinkFlags.HasLinkTargetIDList;
            }
        }
        public int HeaderSize { get; set; }
        public Guid LinkCLSID { get; set; }
        public LinkFlags LinkFlags { get; set; }
        public FileAttributes FileAttributes { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime AccessTime { get; set; }

        public DateTime WriteTime { get; set; }

        public uint FileSize { get; set; }

        public int IconIndex { get; set; }

        public uint ShowCommand { get; set; }
        public HotKeyFlags HotKey { get; set; }
        public byte[] Reserved1 { get; set; }
        public byte[] Reserved2 { get; set; }
        public byte[] Reserved3 { get; set; }
        public static ShellLinkHeader Parse(BinaryReader reader)
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
            entity.HotKey = ShellLinkHeader.HotKeyFlags.FromBinary(reader.ReadBytes(2));
            entity.Reserved1 = reader.ReadBytes(2);
            entity.Reserved2 = reader.ReadBytes(4);
            entity.Reserved3 = reader.ReadBytes(4);
            return entity;
        }
    }
}
