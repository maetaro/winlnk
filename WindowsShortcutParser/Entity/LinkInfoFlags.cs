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
        }
        public bool CommonNetworkRelativeLinkAndPathSuffix
        {
            get
            {
                return buff[1];
            }
        }
        private LinkInfoFlags() : this(new byte[4])
        {
        }
        private LinkInfoFlags(byte[] bytes)
        {
            buff = new BitArray(bytes);
        }
        public static LinkInfoFlags FromBinary(byte[] bytes)
        {
            return new LinkInfoFlags(bytes);
        }
    }
}
