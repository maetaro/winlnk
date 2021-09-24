using System;

namespace WindowsShortcutParser.Entity
{
    public class WindowsShellLinkEntity : EntityBase
    {
        public ShellLinkHeader ShellLinkHeader { get; internal set; }
        public LinkTargetIDList LinkTargetIDList { get; internal set; }
        public LinkInfo LinkInfo { get; internal set; }
        public StringData StringData { get; set; }
        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }
}