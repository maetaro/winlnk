using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class CommonNetworkRelativeLinkFlags
    {
        private readonly BitArray buff;
        public bool ValidDevice
        {
            get
            {
                return buff[0];
            }
        }
        public bool ValidNetType
        {
            get
            {
                return buff[1];
            }
        }
        private CommonNetworkRelativeLinkFlags() : this(new byte[4])
        {
        }
        private CommonNetworkRelativeLinkFlags(byte[] bytes)
        {
            buff = new BitArray(bytes);
        }
        public static CommonNetworkRelativeLinkFlags FromBinary(byte[] bytes)
        {
            return new CommonNetworkRelativeLinkFlags(bytes);
        }
    }
}
