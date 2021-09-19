using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public class LinkTargetIDListParser
    {
        public static LinkTargetIDList Parse(BinaryReaderEx reader)
        {
            var entity = new LinkTargetIDList();
            entity.IDListSize = reader.ReadUInt16();
            ushort size = 0;
            const ushort TerminalIDLength = 2;
            while (size < entity.IDListSize - TerminalIDLength)
            {
                var itemId = new ItemID();
                itemId.ItemIDSize = reader.ReadUInt16();
                const ushort ItemIDSizeLength = 2;
                itemId.Data = reader.ReadBytes(itemId.ItemIDSize - ItemIDSizeLength);
                entity.IDList.Add(itemId);
                size += itemId.ItemIDSize;
            }
            var TerminalID = reader.ReadUInt16();
            if (TerminalID != 0)
            {
                throw new BadImageFormatException($"TerminalID is {TerminalID}, at {reader.BaseStream.Position}.");
            }
            return entity;
        }
    }
}
