using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Entity
{
    public class LinkInfo
    {
        public uint LinkInfoSize { get; set; }
        public uint LinkInfoHeaderSize { get; set; }
        public LinkInfoFlags LinkInfoFlags { get; set; }
        public uint VolumeIDOffset { get; set; }
        public uint LocalBasePathOffset { get; set; }
        public uint CommonNetworkRelativeLinkOffset { get; set; }
        public uint CommonPathSuffixOffset { get; set; }
        public uint LocalBasePathOffsetUnicode { get; set; }
        public uint CommonPathSuffixOffsetUnicode { get; set; }
        public VolumeID VolumeID { get; set; }
        public string LocalBasePath { get; set; }
        public CommonNetworkRelativeLink CommonNetworkRelativeLink { get; set; }
        public string CommonPathSuffix { get; set; }
        public string LocalBasePathUnicode { get; set; }
        public string CommonPathSuffixUnicode { get; set; }
    }
}
