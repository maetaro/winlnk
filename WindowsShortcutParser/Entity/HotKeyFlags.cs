using System;
using System.Collections;

namespace WindowsShortcutParser.Entity
{
    public class HotKeyFlags
    {
        private byte[] buff;
        public byte LowByte { get { return buff[0]; } set { buff[0] = value; } }
        public byte HighByte { get { return buff[1]; } set { buff[1] = value; } }
        public HotKeyFlags() : this(new byte[2])
        {
        }
        public HotKeyFlags(byte[] bytes)
        {
            buff = bytes;
        }
        public static HotKeyFlags FromBinary(byte[] bytes)
        {
            return new HotKeyFlags()
            {
                LowByte = bytes[0],
                HighByte = bytes[1],
            };
        }
        public byte[] ToByteArray()
        {
            return buff;
        }
    }
}
