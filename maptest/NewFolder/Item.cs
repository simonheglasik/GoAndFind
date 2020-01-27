using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace maptest.NewFolder
{
    class Item
    {
        public Position ItemSpawn(Position playerposition)
        {
            var rnd = new Random();
            double rlon = rnd.Next(-100, 100);
            double lon = rlon / 30000;
            double rlan = rnd.Next(-100, 100);
            double lan = rlan / 30000;
            return new Position(playerposition.Longitude + lan, playerposition.Latitude);
        }
    }
}
