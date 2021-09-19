using System;
using System.IO;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Entity
{
    public class VolumeID
    {
        public uint VolumeIDSize { get; set; }
        public DriveType DriveType { get; set; }
        public uint DriveSerialNumber { get; set; }
        public uint VolumeLabelOffset { get; set; }
        public uint VolumeLabelOffsetUnicode { get; set; }
        public string Data { get; set; }
    }
}
