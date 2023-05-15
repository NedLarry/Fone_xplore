using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fone_Xplorer.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTextFilePage : ContentPage
    {
        public CreateTextFilePage(DirectoryInfo incomingDirectoryObject)
        {
            InitializeComponent();
            DirectoryToWorkOn = incomingDirectoryObject;
        }

        public DirectoryInfo DirectoryToWorkOn { get; set; }



        private async void backBtnClicked(object sender, EventArgs e) => await Navigation.PopModalAsync();

        protected override bool OnBackButtonPressed() => true;
    }
}