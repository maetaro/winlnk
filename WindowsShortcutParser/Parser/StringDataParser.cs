using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public class StringDataParser
    {
        public static StringData Parse(BinaryReaderEx reader, LinkFlags linkFlags)
        {
            var entity = new StringData();
            if (linkFlags.HasName)
            {
                ushort CountCharacters = reader.ReadUInt16();
                var bytes = reader.ReadBytes(CountCharacters * 2);
                entity.NAME_STRING = System.Text.Encoding.Unicode.GetString(bytes);
            }
            if (linkFlags.HasRelativePath)
            {
                ushort CountCharacters = reader.ReadUInt16();
                var bytes = reader.ReadBytes(CountCharacters * 2);
                entity.RELATIVE_PATH = System.Text.Encoding.Unicode.GetString(bytes);
            }
            if (linkFlags.HasWorkingDir)
            {
                ushort CountCharacters = reader.ReadUInt16();
                var bytes = reader.ReadBytes(CountCharacters * 2);
                entity.WORKING_DIR = System.Text.Encoding.Unicode.GetString(bytes);
            }
            if (linkFlags.HasArguments)
            {
                ushort CountCharacters = reader.ReadUInt16();
                var bytes = reader.ReadBytes(CountCharacters * 2);
                entity.COMMAND_LINE_ARGUMENTS = System.Text.Encoding.Unicode.GetString(bytes);
            }
            if (linkFlags.HasIconLocation)
            {
                ushort CountCharacters = reader.ReadUInt16();
                var bytes = reader.ReadBytes(CountCharacters * 2);
                entity.ICON_LOCATION = System.Text.Encoding.Unicode.GetString(bytes);
            }
            return entity;
        }
    }
}
