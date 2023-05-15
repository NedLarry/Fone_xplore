using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fone_Xplorer.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateFolderPage : ContentPage
    {

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public CreateFolderPage(DirectoryInfo incomingDirectoryObject)
        {
            InitializeComponent();

            DirectoryToWorkOn = incomingDirectoryObject;

            DirectoryToWorkOn.Attributes = FileAttributes.Normal | FileAttributes.Directory;
        }

        public DirectoryInfo DirectoryToWorkOn { get; set; }


        private async void btnCreateClicked (object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(folderName.Text))
            {
                await DisplayAlert("Error", "Folder name cannot be empty", "OK");
                return;
            }

            if (DirectoryToWorkOn.GetDirectories().Any(folder => folder.Name.Equals(folderName.Text)))
            {
                await DisplayAlert("Error", "Folder already exists", "OK");
                return;
            }

            var fullPath = Path.Combine(DirectoryToWorkOn.FullName, folderName.Text);

            var newDir = new DirectoryInfo(fullPath);

            newDir.Attributes = FileAttributes.Directory;

            newDir.Create();

            //Directory.CreateDirectory(fullPath);

            await DisplayAlert("Success", "Folder Created", "OK");

            folderName.Text = string.Empty;

            await Navigation.PopModalAsync();
        }

        private async void backBtnClicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        protected override bool OnBackButtonPressed() => true;

        

    }
}