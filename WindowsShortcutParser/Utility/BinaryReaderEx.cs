using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Utility
{
    public class BinaryReaderEx : BinaryReader
    {
        public long Position
        {
            get
            {
                return BaseStream.Position;
            }
        }
        public BinaryReaderEx(Stream input) : base(input)
        {
        }
        public BinaryReaderEx(Stream input, Encoding encoding) : base(input, encoding)
        {
        }
        public BinaryReaderEx(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }
        public string ReadNullTerminatedString()
        {
            var bytes = new List<byte>();
            while (true)
            {
                var buff = ReadByte();
                if (buff == 0x00)
                {
                    break;
                }
                bytes.Add(buff);
            }
            var s_default = System.Text.Encoding.Default.GetString(bytes.ToArray());
            var b_default = System.Text.Encoding.Default.GetBytes(s_default);
            if (bytes.SequenceEqual(b_default))
            {
                return s_default;
            }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var s_sjis = System.Text.Encoding.GetEncoding("shift_jis").GetString(bytes.ToArray());
            var b_sjis = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(s_sjis);
            if (bytes.SequenceEqual(b_sjis))
            {
                return s_sjis;
            }
            return System.Text.Encoding.UTF8.GetString(bytes.ToArray());
        }

        public void Seek(long offset)
        {
            this.BaseStream.Seek(offset, SeekOrigin.Begin);
        }

        public string ReadNullTerminatedUnicodeString()
        {
            var bytes = new List<byte>();
            while (true)
            {
                var buff1 = ReadByte();
                var buff2 = ReadByte();
                if (buff1 == 0x00 && buff2 == 0x00)
                {
                    break;
                }
                bytes.Add(buff1);
                bytes.Add(buff2);
            }
            return System.Text.Encoding.Unicode.GetString(bytes.ToArray());
        }
    }
}
