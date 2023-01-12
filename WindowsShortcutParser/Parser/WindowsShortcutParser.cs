using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
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
        public static WindowsShellLinkEntity Parse(BinaryReaderEx reader)
        {
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
        public static WindowsShellLinkEntity FromJsonFile(string path)
        {
            string jsonString = File.ReadAllText(path);
            using var doc = JsonDocument.Parse(jsonString);
            var entity = new WindowsShellLinkEntity();
            var ShellLinkHeader = doc.RootElement.GetProperty("ShellLinkHeader");
            entity.ShellLinkHeader = new();
            entity.ShellLinkHeader.HeaderSize = ShellLinkHeader.GetProperty("HeaderSize").GetInt32();
            entity.ShellLinkHeader.LinkCLSID = new Guid(ShellLinkHeader.GetProperty("LinkCLSID").GetString());
            entity.ShellLinkHeader.LinkFlags = new();
            entity.ShellLinkHeader.LinkFlags.HasLinkTargetIDList = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasLinkTargetIDList").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasLinkInfo = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasLinkInfo").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasName = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasName").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasRelativePath = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasRelativePath").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasWorkingDir = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasWorkingDir").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasArguments = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasArguments").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasIconLocation = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasIconLocation").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.IsUnicode = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("IsUnicode").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.ForceNoLinkInfo = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("ForceNoLinkInfo").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasExpString = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasExpString").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.RunInSeparateProcess = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("RunInSeparateProcess").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.Unused1 = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("Unused1").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasDarwinID = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasDarwinID").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.RunAsUser = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("RunAsUser").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.HasExpIcon = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("HasExpIcon").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.NoPidlAlias = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("NoPidlAlias").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.Unused2 = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("Unused2").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.RunWithShimLayer = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("RunWithShimLayer").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.ForceNoLinkTrack = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("ForceNoLinkTrack").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.EnableTargetMetadata = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("EnableTargetMetadata").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.DisableLinkPathTracking = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("DisableLinkPathTracking").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.DisableKnownFolderTracking = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("DisableKnownFolderTracking").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.DisableKnownFolderAlias = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("DisableKnownFolderAlias").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.AllowLinkToLink = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("AllowLinkToLink").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.UnaliasOnSave = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("UnaliasOnSave").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.PreferEnvironmentPath = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("PreferEnvironmentPath").GetBoolean();
            entity.ShellLinkHeader.LinkFlags.KeepLocalIDListForUNCTarget = ShellLinkHeader.GetProperty("LinkFlags").GetProperty("KeepLocalIDListForUNCTarget").GetBoolean();
            entity.ShellLinkHeader.FileAttributes = new();
            var fa = ShellLinkHeader.GetProperty("FileAttributes");
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_READONLY           = fa.GetProperty("FILE_ATTRIBUTE_READONLY").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_HIDDEN             = fa.GetProperty("FILE_ATTRIBUTE_HIDDEN").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_SYSTEM             = fa.GetProperty("FILE_ATTRIBUTE_SYSTEM").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.Reserved1                         = fa.GetProperty("Reserved1").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_DIRECTORY          = fa.GetProperty("FILE_ATTRIBUTE_DIRECTORY").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_ARCHIVE            = fa.GetProperty("FILE_ATTRIBUTE_ARCHIVE").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.Reserved2                         = fa.GetProperty("Reserved2").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_NORMAL             = fa.GetProperty("FILE_ATTRIBUTE_NORMAL").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_TEMPORARY          = fa.GetProperty("FILE_ATTRIBUTE_TEMPORARY").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_SPARSE_FILE        = fa.GetProperty("FILE_ATTRIBUTE_SPARSE_FILE").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_REPARSE_POINT      = fa.GetProperty("FILE_ATTRIBUTE_REPARSE_POINT").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_COMPRESSED         = fa.GetProperty("FILE_ATTRIBUTE_COMPRESSED").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_OFFLINE            = fa.GetProperty("FILE_ATTRIBUTE_OFFLINE").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_NOT_CONTENT_INDEXED= fa.GetProperty("FILE_ATTRIBUTE_NOT_CONTENT_INDEXED").GetBoolean();
            entity.ShellLinkHeader.FileAttributes.FILE_ATTRIBUTE_ENCRYPTED          = fa.GetProperty("FILE_ATTRIBUTE_ENCRYPTED").GetBoolean();

            entity.ShellLinkHeader.CreationTime = ShellLinkHeader.GetProperty("CreationTime").GetInt64();
            entity.ShellLinkHeader.AccessTime = ShellLinkHeader.GetProperty("AccessTime").GetInt64();
            entity.ShellLinkHeader.WriteTime = ShellLinkHeader.GetProperty("WriteTime").GetInt64();
            entity.ShellLinkHeader.FileSize = ShellLinkHeader.GetProperty("FileSize").GetUInt32();
            entity.ShellLinkHeader.IconIndex = ShellLinkHeader.GetProperty("IconIndex").GetInt32();
            entity.ShellLinkHeader.ShowCommand = ShellLinkHeader.GetProperty("ShowCommand").GetUInt32();
            entity.ShellLinkHeader.HotKey = new();
            entity.ShellLinkHeader.HotKey.LowByte = ShellLinkHeader.GetProperty("HotKey").GetProperty("LowByte").GetByte();
            entity.ShellLinkHeader.HotKey.HighByte = ShellLinkHeader.GetProperty("HotKey").GetProperty("HighByte").GetByte();
            entity.ShellLinkHeader.Reserved1 = ShellLinkHeader.GetProperty("Reserved1").GetBytesFromBase64();
            entity.ShellLinkHeader.Reserved2 = ShellLinkHeader.GetProperty("Reserved2").GetBytesFromBase64();
            entity.ShellLinkHeader.Reserved3 = ShellLinkHeader.GetProperty("Reserved3").GetBytesFromBase64();

            return entity;
        }
    }
}
