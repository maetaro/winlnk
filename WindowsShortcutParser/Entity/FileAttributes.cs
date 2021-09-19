using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShortcutParser.Entity
{
    public class FileAttributes
    {
        private readonly BitArray buff;
        public bool FILE_ATTRIBUTE_READONLY { get { return buff[0]; } set { buff[0] = value; } }
        public bool FILE_ATTRIBUTE_HIDDEN { get { return buff[1]; } set { buff[1] = value; } }
        public bool FILE_ATTRIBUTE_SYSTEM { get { return buff[2]; } set { buff[2] = value; } }
        public bool Reserved1 { get { return buff[3]; } set { buff[3] = value; } }
        public bool FILE_ATTRIBUTE_DIRECTORY { get { return buff[4]; } set { buff[4] = value; } }
        public bool FILE_ATTRIBUTE_ARCHIVE { get { return buff[5]; } set { buff[5] = value; } }
        public bool Reserved2 { get { return buff[6]; } set { buff[6] = value; } }
        public bool FILE_ATTRIBUTE_NORMAL { get { return buff[7]; } set { buff[7] = value; } }
        public bool FILE_ATTRIBUTE_TEMPORARY { get { return buff[8]; } set { buff[8] = value; } }
        public bool FILE_ATTRIBUTE_SPARSE_FILE { get { return buff[9]; } set { buff[9] = value; } }
        public bool FILE_ATTRIBUTE_REPARSE_POINT { get { return buff[10]; } set { buff[10] = value; } }
        public bool FILE_ATTRIBUTE_COMPRESSED { get { return buff[11]; } set { buff[11] = value; } }
        public bool FILE_ATTRIBUTE_OFFLINE { get { return buff[12]; } set { buff[12] = value; } }
        public bool FILE_ATTRIBUTE_NOT_CONTENT_INDEXED { get { return buff[13]; } set { buff[13] = value; } }
        public bool FILE_ATTRIBUTE_ENCRYPTED { get { return buff[14]; } set { buff[14] = value; } }
        private FileAttributes() : this(new byte[4])
        {
        }
        private FileAttributes(byte[] bytes)
        {
            buff = new BitArray(bytes);
        }
        public static FileAttributes FromBinary(byte[] bytes)
        {
            return new FileAttributes(bytes);
        }
    }
}
