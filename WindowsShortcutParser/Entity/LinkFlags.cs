using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class LinkFlags
    {
        private readonly BitArray buff;
        public bool HasLinkTargetIDList { get { return buff[0]; } set { buff[0] = value; } }
        public bool HasLinkInfo { get { return buff[1]; } set { buff[1] = value; } }
        public bool HasName { get { return buff[2]; } set { buff[2] = value; } }
        public bool HasRelativePath { get { return buff[3]; } set { buff[3] = value; } }
        public bool HasWorkingDir { get { return buff[4]; } set { buff[4] = value; } }
        public bool HasArguments { get { return buff[5]; } set { buff[5] = value; } }
        public bool HasIconLocation { get { return buff[6]; } set { buff[6] = value; } }
        public bool IsUnicode { get { return buff[7]; } set { buff[7] = value; } }
        public bool ForceNoLinkInfo { get { return buff[8]; } set { buff[8] = value; } }
        public bool HasExpString { get { return buff[9]; } set { buff[9] = value; } }
        public bool RunInSeparateProcess { get { return buff[10]; } set { buff[10] = value; } }
        public bool Unused1 { get { return buff[11]; } set { buff[11] = value; } }
        public bool HasDarwinID { get { return buff[12]; } set { buff[12] = value; } }
        public bool RunAsUser { get { return buff[13]; } set { buff[13] = value; } }
        public bool HasExpIcon { get { return buff[14]; } set { buff[14] = value; } }
        public bool NoPidlAlias { get { return buff[15]; } set { buff[15] = value; } }
        public bool Unused2 { get { return buff[16]; } set { buff[16] = value; } }
        public bool RunWithShimLayer { get { return buff[17]; } set { buff[17] = value; } }
        public bool ForceNoLinkTrack { get { return buff[18]; } set { buff[18] = value; } }
        public bool EnableTargetMetadata { get { return buff[19]; } set { buff[19] = value; } }
        public bool DisableLinkPathTracking { get { return buff[20]; } set { buff[20] = value; } }
        public bool DisableKnownFolderTracking { get { return buff[21]; } set { buff[21] = value; } }
        public bool DisableKnownFolderAlias { get { return buff[22]; } set { buff[22] = value; } }
        public bool AllowLinkToLink { get { return buff[23]; } set { buff[23] = value; } }
        public bool UnaliasOnSave { get { return buff[24]; } set { buff[24] = value; } }
        public bool PreferEnvironmentPath { get { return buff[25]; } set { buff[25] = value; } }
        public bool KeepLocalIDListForUNCTarget { get { return buff[26]; } set { buff[26] = value; } }

        public LinkFlags() : this(new byte[4])
        {
        }
        public LinkFlags(byte[] bytes)
        {
            buff = new BitArray(bytes);
        }
        public override bool Equals(object obj)
        {
            LinkFlags other = (LinkFlags)obj;
            if (this.HasLinkTargetIDList != other.HasLinkTargetIDList) return false;
            if (this.HasLinkInfo != other.HasLinkInfo) return false;
            if (this.HasName != other.HasName) return false;
            if (this.HasRelativePath != other.HasRelativePath) return false;
            if (this.HasWorkingDir != other.HasWorkingDir) return false;
            if (this.HasArguments != other.HasArguments) return false;
            if (this.HasIconLocation != other.HasIconLocation) return false;
            if (this.IsUnicode != other.IsUnicode) return false;
            if (this.ForceNoLinkInfo != other.ForceNoLinkInfo) return false;
            if (this.HasExpString != other.HasExpString) return false;
            if (this.RunInSeparateProcess != other.RunInSeparateProcess) return false;
            if (this.Unused1 != other.Unused1) return false;
            if (this.HasDarwinID != other.HasDarwinID) return false;
            if (this.RunAsUser != other.RunAsUser) return false;
            if (this.HasExpIcon != other.HasExpIcon) return false;
            if (this.NoPidlAlias != other.NoPidlAlias) return false;
            if (this.Unused2 != other.Unused2) return false;
            if (this.RunWithShimLayer != other.RunWithShimLayer) return false;
            if (this.ForceNoLinkTrack != other.ForceNoLinkTrack) return false;
            if (this.EnableTargetMetadata != other.EnableTargetMetadata) return false;
            if (this.DisableLinkPathTracking != other.DisableLinkPathTracking) return false;
            if (this.DisableKnownFolderTracking != other.DisableKnownFolderTracking) return false;
            if (this.DisableKnownFolderAlias != other.DisableKnownFolderAlias) return false;
            if (this.AllowLinkToLink != other.AllowLinkToLink) return false;
            if (this.UnaliasOnSave != other.UnaliasOnSave) return false;
            if (this.PreferEnvironmentPath != other.PreferEnvironmentPath) return false;
            if (this.KeepLocalIDListForUNCTarget != other.KeepLocalIDListForUNCTarget) return false;
            return true;
        }

        public static LinkFlags FromBinary(byte[] bytes)
        {
            return new LinkFlags(bytes);
        }
        public byte[] ToByteArray()
        {
            byte[] ret = new byte[(buff.Length - 1) / 8 + 1];
            buff.CopyTo(ret, 0);
            return ret;
        }

    }
}
