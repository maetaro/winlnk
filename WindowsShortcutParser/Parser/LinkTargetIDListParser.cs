using System;
using System.Collections.Generic;
using System.IO;
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

        public static void Serialize(Stream stream, WindowsShellLinkEntity entity)
        {
            stream.Write(BitConverter.GetBytes(entity.LinkTargetIDList.IDListSize), 0, 2);
            foreach (var item in entity.LinkTargetIDList.IDList)
            {
                stream.Write(BitConverter.GetBytes(item.ItemIDSize), 0, 2);
                stream.Write(item.Data, 0, item.Data.Length);
            }
            stream.Write(new byte[] { 0x00, 0x00 }, 0, 2);
        }
    }
}
