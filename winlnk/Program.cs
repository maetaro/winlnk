using System;
using System.IO;

namespace winlnk
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 2)
                {
                    return;
                }
                if (args.Length == 1)
                {
                    string path = args[0];
                    Show(path);
                    return;
                }
                else
                {
                    string pathJson = args[0];
                    string pathLnk = args[1];
                    var entity = WindowsShortcutParser.Parser.WindowsShortcutParser.FromJsonFile(pathJson);
                    File.WriteAllBytes(pathLnk, entity.ToByteArray());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void Show(string path)
        {
            //var entity = WindowsShortcutParser.Parser.WindowsShortcutParser.Parse(path);
            //Console.WriteLine(entity.ToJsonString());
        }
    }
}
