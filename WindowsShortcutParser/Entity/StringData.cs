using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class StringData
    {
        public string NAME_STRING { get; set; }
        public string RELATIVE_PATH { get; set; }
        public string WORKING_DIR { get; set; }
        public string COMMAND_LINE_ARGUMENTS { get; set; }
        public string ICON_LOCATION { get; set; }
    }
}
