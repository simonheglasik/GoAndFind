using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;

namespace maptest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            map.MapType = MapType.Hybrid;
            map.MoveToRegion(new MapSpan(new Position()))

            Task.Run(() =>
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var task = locator.GetPositionAsync(new TimeSpan(0, 0, 5));
                task.Wait();

                var location = task.Result;

                Device.BeginInvokeOnMainThread(() =>
                {
                    map.Pins.Add(new Pin { 
                        Label = "Test",
                        Position = new Position(location.Latitude, location.Longitude) 
                    });
                });
            });
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var location = await locator.GetPositionAsync();
            Position position = new Position(location.Latitude, location.Longitude);
            
        }
    }
}
