using System;
using System.IO;
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
            entity.DriveType = (Entity.DriveType)Enum.ToObject(typeof(Entity.DriveType), (int)reader.ReadUInt32());
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
        public static void Serialize(Stream stream, VolumeID entity)
        {
            stream.Write(BitConverter.GetBytes(entity.VolumeIDSize), 0, 4);
            stream.Write(BitConverter.GetBytes((int)entity.DriveType), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.DriveSerialNumber), 0, 4);
            stream.Write(BitConverter.GetBytes(entity.VolumeLabelOffset), 0, 4);
            if (entity.VolumeLabelOffset == 0x14)
            {
                stream.Write(BitConverter.GetBytes(entity.VolumeLabelOffsetUnicode), 0, 4);
                var buff = System.Text.Encoding.Unicode.GetBytes(entity.Data);
                stream.Write(buff, 0, buff.Length);
                stream.Write(new byte[] { 0x00, 0x00 }, 0, 2);
            }
            else
            {
                var buff = System.Text.Encoding.Default.GetBytes(entity.Data);
                stream.Write(buff, 0, buff.Length);
                stream.Write(new byte[] { 0x00 }, 0, 1);
            }
        }
    }
}
