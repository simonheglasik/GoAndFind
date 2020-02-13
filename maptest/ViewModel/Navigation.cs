using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace maptest.ViewModel
{
    public class Navigation : INotifyPropertyChanged
    {
        private Color _color = Color.FromHex("#B1B108");
        public Color Color
        {
            get => _color;
            set
            {
                if (value == _color)
                    return;

                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Find(Position item)
        {
            var player = new Player();
            while (true)
            {
                var playerPosition =new Position(player.PlayerPositon().Result.Latitude,player.PlayerPositon().Result.Longitude);
                double time = DateTime.Now.Ticks;
                double blinktime = time + (((item.Latitude + item.Longitude) - (playerPosition.Longitude + playerPosition.Latitude)) / 100000);
                if (blinktime < 0)
                {
                    blinktime = -blinktime;
                }
                while(time <= blinktime)
                {
                    if(time == blinktime)
                    {
                        Color = Color.White;
                    }
                }
                Color = Color.FromRgba(255, 177, 177, 08);
            }
        }
    }
}
