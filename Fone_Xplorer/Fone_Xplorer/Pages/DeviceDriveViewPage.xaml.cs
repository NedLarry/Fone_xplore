using Fone_Xplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Fone_Xplorer.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeviceDriveViewPage : ContentPage
	{
		public DeviceDriveViewPage (DirectoryInfo directoryToView)
		{
			InitializeComponent ();

			DirectoryToView = directoryToView;

			driveView.ItemsSource = GetViewFiles();
		}

        public DirectoryInfo DirectoryToView { get; set; }

		private void driveView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var itemSelected = e.SelectedItem as FileFolderView;

			itemSelected = null;
		}

		private async void toolBarClicked (object sender, EventArgs e)
		{
			var response = await DisplayActionSheet("New", "Cancel", null, "Create Folder", "Create Text File");

			switch (response)
			{
				case "Create Folder":
					CreateNewFolder(DirectoryToView);
				break;

                case "Create Text File":
                    CreateNewTextFile(DirectoryToView);
				break;

            }
		}


        //Helper methods
        List<FileFolderView> GetViewFiles()
		{

			List<FileFolderView> directoryContents = new List<FileFolderView> ();

			var FoldersInDirectory = DirectoryToView.GetDirectories ();

			var FilesInDirectory = DirectoryToView.GetFiles();

			FoldersInDirectory.ForEach(folder =>
			{

				folder.Attributes = FileAttributes.Normal | FileAttributes.Directory;

				directoryContents.Add(new FileFolderView
				{


					Name = folder.Name,
					isFolder = true,
					SubDirectories = folder.GetDirectories(),
					Files = folder.GetFiles(),
					FileSize = $@"{(folder.GetFiles().ToList().Sum<FileInfo>(f => f.Length) * 0.001)}KB"


				}); ;
			});

			FilesInDirectory.ForEach(file =>
			{
				directoryContents.Add(new FileFolderView
				{
					Name = file.Name,
					isFile = true,
					FileSize = $@"{(file.Length * 0.001)}KB"
				});
			});

			return directoryContents;
		}

		async void CreateNewFolder(DirectoryInfo currentDirectory)
		{
			await Navigation.PushModalAsync(new CreateFolderPage(currentDirectory));
		}

        async void CreateNewTextFile(DirectoryInfo currentDirectory)
        {
			await Navigation.PushModalAsync(new CreateTextFilePage(currentDirectory));
        }
    }
}