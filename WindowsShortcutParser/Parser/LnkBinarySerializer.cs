using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WindowsShortcutParser.Entity;
using WindowsShortcutParser.Utility;

namespace WindowsShortcutParser.Parser
{
    public class LnkBinarySerializer : IFormatter
    {
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Deserialize(Stream serializationStream)
        {
            using var reader = new BinaryReaderEx(serializationStream);
            var entity = new WindowsShellLinkEntity();
            entity.ShellLinkHeader = ShellLinkHeaderParser.Deserialize(reader);
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

        public void Serialize(Stream serializationStream, object graph)
        {
            var entity = (WindowsShellLinkEntity)graph;
            ShellLinkHeaderParser.Serialize(serializationStream, entity.ShellLinkHeader);
            if (entity.ShellLinkHeader.LinkFlags.HasLinkTargetIDList)
            {
                LinkTargetIDListParser.Serialize(serializationStream, entity);
            }
            if (entity.ShellLinkHeader.LinkFlags.HasLinkInfo)
            {
                LinkInfoParser.Serialize(serializationStream, entity.LinkInfo); ;
            }
            //StringDataParser.Serialize(serializationStream, entity); ;
        }
    }
}
