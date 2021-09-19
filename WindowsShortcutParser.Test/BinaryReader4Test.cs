using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Test
{
    public class BinaryReader4Test : BinaryReaderEx
    {
        private byte[] bytes;
        public BinaryReader4Test(string path) : base(File.OpenRead(path))
        {
            bytes = File.ReadAllBytes(path);
        }
    }
}
