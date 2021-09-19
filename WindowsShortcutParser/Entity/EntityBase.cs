using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class EntityBase
    {
        public string ToJsonString()
        {
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            return JsonSerializer.Serialize(this, this.GetType(), opt);
        }
    }
}
