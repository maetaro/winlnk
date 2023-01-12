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
        public int HeaderSize { get; set; }
        public Guid LinkCLSID { get; set; }
        public LinkFlags LinkFlags { get; set; }
        public FileAttributes FileAttributes { get; set; }

        public long CreationTime { get; set; }

        public long AccessTime { get; set; }

        public long WriteTime { get; set; }

        public uint FileSize { get; set; }

        public int IconIndex { get; set; }

        public uint ShowCommand { get; set; }
        public HotKeyFlags HotKey { get; set; }
        public byte[] Reserved1 { get; set; }
        public byte[] Reserved2 { get; set; }
        public byte[] Reserved3 { get; set; }
    }
}
