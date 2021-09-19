using System;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public class VolumeIDParser
    {
        public static VolumeID Parse(BinaryReaderEx reader)
        {
            var entity = new VolumeID();
            entity.VolumeIDSize = reader.ReadUInt32();
            entity.DriveType = (DriveType)Enum.ToObject(typeof(DriveType), (int)reader.ReadUInt32());
            entity.DriveSerialNumber = reader.ReadUInt32();
            entity.VolumeLabelOffset = reader.ReadUInt32();
            if (entity.VolumeLabelOffset == 0x14)
            {
                entity.VolumeLabelOffsetUnicode = reader.ReadUInt32();
                entity.Data = reader.ReadNullTerminatedUnicodeString();
            }
            else
            {
                entity.Data = reader.ReadNullTerminatedString();
            }
            return entity;
        }
    }
}
