using Fone_Xplorer.Models;
using Fone_Xplorer.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fone_Xplorer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            homeListView.ItemsSource = GetDrivesOnDevice();

            
            
        }

        async void homeListView_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var selectedItem = e.SelectedItem as DeviceDrive;

            await Navigation.PushAsync(new DeviceDriveViewPage(selectedItem.RootDirectory));

            homeListView.SelectedItem = null;
        }

        //Helper methods
        private List<DeviceDrive> GetDrivesOnDevice()
        {
            List<DeviceDrive> drives = new List<DeviceDrive>();

            foreach(var drive in DriveInfo.GetDrives())
            {
                //if (drive.DriveType != DriveType.Ram) continue;

                if (drive.VolumeLabel.Contains("emulated")) continue;

                if (drive.IsReady)
                {
                    

                    drives.Add(new DeviceDrive
                    {
                        VolumeLabel = drive.Name,
                        TotalSize = $@"{(drive.TotalSize * 0.001)}KB",
                        DriveFormat = drive.DriveFormat,
                        DriveType = drive.DriveType.ToString(),
                        RootDirectory = drive.RootDirectory
                    });
                }
            }

            return drives;
        }
    }
}
