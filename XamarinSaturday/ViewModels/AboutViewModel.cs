using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

using Xamarin.Forms;

namespace XamarinSaturday.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string longitude;
        public string Longitude
        {
            get { return longitude; }
            set { SetProperty(ref longitude, value); }
        }

        private string latitude;
        public string Latitude
        {
            get { return latitude; }
            set { SetProperty(ref latitude, value); }
        }

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

            GetLocation = new Command(async () =>
            {
                try
                {
                    var result = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                    Latitude = result.Latitude.ToString();
                    Longitude = result.Longitude.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
        }

        public ICommand OpenWebCommand { get; }

        public ICommand GetLocation { get; }
    }
}