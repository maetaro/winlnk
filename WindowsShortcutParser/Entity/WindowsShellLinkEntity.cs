namespace WindowsShortcutParser.Entity
{
    public class WindowsShellLinkEntity : EntityBase
    {
        public ShellLinkHeader ShellLinkHeader { get; internal set; } = new();
        public LinkTargetIDList LinkTargetIDList { get; internal set; } = new();
        public LinkInfo LinkInfo { get; internal set; } = new();
        public StringData StringData { get; set; } = new();
    }
}