using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class LinkTargetIDList
    {
        public ushort IDListSize { get; set; }
        public List<ItemID> IDList { get; set; } = new List<ItemID>();
    }
}
