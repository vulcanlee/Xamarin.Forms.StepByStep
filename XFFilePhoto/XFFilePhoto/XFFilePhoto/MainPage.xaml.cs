using PCLStorage;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFilePhoto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnbuttonImage1(object sender, EventArgs e)
        {
            await 拍照(ImageLocation.Location1);
        }

        async void OnbuttonImage2(object sender, EventArgs e)
        {
            await 拍照(ImageLocation.Location2);
        }

        async void OnbuttonImage3(object sender, EventArgs e)
        {
            await 拍照(ImageLocation.Location3);
        }

        async void OnbuttonImage4(object sender, EventArgs e)
        {
            await 拍照(ImageLocation.Location4);
        }

        async void OnbuttonFile(object sender, EventArgs e)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await FileSystem.Current.LocalStorage.CreateFolderAsync("MyDatas", CreationCollisionOption.ReplaceExisting);
            IFile sourceFile = await sourceFolder.CreateFileAsync("MyFile.dat", CreationCollisionOption.ReplaceExisting);

            await sourceFile.WriteAllTextAsync("這是我自己寫入檔案的內容");
            var fooContent = await sourceFile.ReadAllTextAsync();
            await DisplayAlert("讀出檔案的內容", fooContent, "OK");
        }

        public async Task 拍照(ImageLocation fooImageLocation = ImageLocation.Location1)
        {
            string fooImageFilename = $"{fooImageLocation.ToString()}.jpg";
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = fooImageFilename
            });

            if (file == null)
                return;

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await FileSystem.Current.GetFolderFromPathAsync(file.Path.Replace(fooImageFilename, ""));
            IFile sourceFile = await FileSystem.Current.GetFileFromPathAsync(file.Path);

            IFolder TargetFolder = await rootFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);

            await sourceFile.MoveAsync($"{TargetFolder.Path}/{fooImageFilename}");
            IFile fileX = await TargetFolder.GetFileAsync(fooImageFilename);

            var s = await fileX.OpenAsync(FileAccess.Read);
            switch (fooImageLocation)
            {
                case ImageLocation.Location1:
                    image1.Source = ImageSource.FromStream(() => s);
                    break;
                case ImageLocation.Location2:
                    image2.Source = ImageSource.FromStream(() => s);
                    break;
                case ImageLocation.Location3:
                    image3.Source = ImageSource.FromStream(() => s);
                    break;
                case ImageLocation.Location4:
                    image4.Source = ImageSource.FromStream(() => s);
                    break;
                default:
                    break;
            }
        }
    }

    public enum ImageLocation
    {
        Location1,
        Location2,
        Location3,
        Location4,

    }
}
