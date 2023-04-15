using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fone_Xplorer.Models
{
    public class DeviceDriveView
    {
        public DeviceDriveView(DirectoryInfo[] directoryToView, FileInfo[] fileContents)
        {
            DirectoryContents = directoryToView;
            FileContents = fileContents;

        }

        public DeviceDriveView()
        {
            
        }

        public DirectoryInfo[] DirectoryContents { get; set; }

        public FileInfo[] FileContents { get; set; }


    }
}
