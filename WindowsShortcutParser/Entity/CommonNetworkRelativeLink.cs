using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Entity
{
    public class CommonNetworkRelativeLink
    {
        public uint CommonNetworkRelativeLinkSize { get; set; }
        public CommonNetworkRelativeLinkFlags CommonNetworkRelativeLinkFlags { get; set; }
        public uint NetNameOffset { get; set; }
        public uint DeviceNameOffset { get; set; }
        public NetworkProviderType NetworkProviderType { get; set; }
        public uint NetNameOffsetUnicode { get; set; }
        public uint DeviceNameOffsetUnicode { get; set; }
        public string NetName { get; set; }
        public string DeviceName { get; set; }
        public string NetNameUnicode { get; set; }
        public string DeviceNameUnicode { get; set; }
    }
}
