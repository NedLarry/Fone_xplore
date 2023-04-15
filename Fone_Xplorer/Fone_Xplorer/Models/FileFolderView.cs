using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fone_Xplorer.Models
{
    public class FileFolderView
    {

        public string Name { get; set; } = string.Empty;

        public string FileSize { get; set; } = string.Empty;

        public bool isFolder { get; set; }

        public bool isFile { get; set; }

        public DirectoryInfo ParentDirectory { get; set; }


        public DirectoryInfo[] SubDirectories { get; set; }

        public FileInfo[] Files { get; set; }
    }
}
