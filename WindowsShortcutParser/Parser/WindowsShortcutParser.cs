using System.IO;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    /// <summary>
    /// Windows Shell Link (.LNK) Binary File Parser
    /// <see cref="https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-shllink/16cb4ca1-9339-4d0c-a68d-bf1d6cc0f943"/>
    /// </summary>
    public class WindowsShortcutParser
    {
        public static WindowsShellLinkEntity Parse(string path)
        {
            return Parse(File.OpenRead(path));
        }
        public static WindowsShellLinkEntity Parse(Stream stream)
        {
            using var reader = new BinaryReaderEx(stream);
            return Parse(reader);
        }
        public static WindowsShellLinkEntity Parse(BinaryReaderEx reader)
        {
            var entity = new WindowsShellLinkEntity();
            entity.ShellLinkHeader = ShellLinkHeaderParser.Parse(reader);
            if (entity.ShellLinkHeader.LinkFlags.HasLinkTargetIDList)
            {
                entity.LinkTargetIDList = LinkTargetIDListParser.Parse(reader);
            }
            if (entity.ShellLinkHeader.LinkFlags.HasLinkInfo)
            {
                entity.LinkInfo = LinkInfoParser.Parse(reader);
            }
            entity.StringData = StringDataParser.Parse(reader, entity.ShellLinkHeader.LinkFlags);
            return entity;
        }
    }
}
