using System;

namespace WindowsShortcutParser.Entity
{
    public class HotKeyFlags
    {
        public byte LowByte { get; set; }
        public byte HighByte { get; set; }
        public static HotKeyFlags FromBinary(byte[] bytes)
        {
            return new HotKeyFlags()
            {
                LowByte = bytes[0],
                HighByte = bytes[1],
            };
        }
    }
}
