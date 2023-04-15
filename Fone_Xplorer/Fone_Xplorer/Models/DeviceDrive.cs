using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fone_Xplorer.Models
{
    public class DeviceDrive
    {
        public string VolumeLabel { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string DriveType { get; set; } = string.Empty;
        public string DriveFormat { get; set; } = string.Empty;
        public string TotalSize { get; set; } = string.Empty;
        public DirectoryInfo RootDirectory { get; set; }
    }
}
