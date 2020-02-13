﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using maptest.NewFolder;
using maptest.ViewModel;

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
            map.MapType = MapType.Street;
            map.IsShowingUser = true;

            GetPosition();

            
        }

        private async void GetPosition()
        {
            var navigation = new Navigation();

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 5;

            var task = await locator.GetPositionAsync(new TimeSpan(0, 0, 1));

            var location = task;

            MapSpan mapSpan = MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);


            var item = new Item();


            var itemloc = new Position(item.ItemSpawn(location).Longitude, item.ItemSpawn(location).Latitude);


            Device.BeginInvokeOnMainThread(() =>
            {
                map.Pins.Add(new Pin
                {

                    Label = "Item",
                    Position = itemloc
                }); ;
            });
            /*
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    navigation.Find(itemloc);
                });
                return true; // runs again, or false to stop
            });*/
        }
    }
}
