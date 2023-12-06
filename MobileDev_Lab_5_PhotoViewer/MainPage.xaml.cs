using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MobileDev_Lab_5_PhotoViewer
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PhotoItem> Photos = new ();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSelectPhotosClicked(object sender, EventArgs e)
        {

            var result = await FilePicker.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Please select image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                Photos.Clear();

                foreach (var file in result)
                {
                    var photo = new PhotoItem
                    {
                        Name = file.FileName,
                        ImagePath = file.FullPath
                    };
                    Photos.Add(photo);
                }
            }
        }
    }

    public class PhotoItem
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
