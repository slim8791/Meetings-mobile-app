using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Messaging;
using Xamarin.Forms;
using System.Net.Http;

namespace AppMeetings
{
    public partial class PhotoPage : ContentPage
    {
        private MediaFile _mediaFile;
        public PhotoPage()
        {
            InitializeComponent();
        }

        private async void TakePhoto_OnClicked(object sender, EventArgs e)
        {
            CrossMedia.Current.Initialize();
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "image.jpg"
            });
            if(_mediaFile == null)
                return;
            DisplayAlert("File location ", _mediaFile.Path, "ok");
            image.Source = ImageSource.FromStream(
                ()=> { return _mediaFile.GetStream(); });

        }

        private async void PickPhoto_OnClicked(object sender, EventArgs e)
        {
            CrossMedia.Current.Initialize();
            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile == null)
                return;
            DisplayAlert("File location ", _mediaFile.Path, "ok");
            image.Source = ImageSource.FromStream(
                () => { return _mediaFile.GetStream(); });
        }

        private async void UploadPhoto_OnClicked(object sender, EventArgs e)
        {
             
        var content = new MultipartFormDataContent();
            content.Add(new StreamContent(_mediaFile.GetStream()), "\"file\"", $"\"{_mediaFile.Path}\"");
            var httpClient = new HttpClient();
            var uploadAdress = "http://192.168.1.165/meetings/api/Files/Upload/dossier";
            var httpResponse = await httpClient.PostAsync(uploadAdress, content);
            RemotePath.Text = await httpResponse.Content.ReadAsStringAsync();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {

            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                var email = new EmailMessageBuilder()
                   .To("slim.hammami@tek-up.tn")
                   .Subject("Test mail")
                   .Body("Hi")
                   .WithAttachment(_mediaFile.Path, "jpeg")
                   .Build();
                emailMessenger.SendEmail(email);
            }
               
        }
    }
}
