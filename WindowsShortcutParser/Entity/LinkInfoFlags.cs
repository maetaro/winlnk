using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class LinkInfoFlags
    {
        private readonly BitArray buff;
        public bool VolumeIDAndLocalBasePath
        {
            get
            {
                return buff[0];
            }
            set
            {
                buff[0] = value;
            }
        }
        public bool CommonNetworkRelativeLinkAndPathSuffix
        {
            get
            {
                return buff[1];
            }
            set
            {
                buff[1] = value;
            }
        }
        public LinkInfoFlags() : this(new byte[4])
        {
        }
        public LinkInfoFlags(byte[] bytes)
        {
            buff = new BitArray(bytes);
        }
        public static LinkInfoFlags FromBinary(byte[] bytes)
        {
            return new LinkInfoFlags(bytes);
        }

        public byte[] ToByteArray()
        {
            byte[] ret = new byte[(buff.Length - 1) / 8 + 1];
            buff.CopyTo(ret, 0);
            return ret;
        }
    }
}
