using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ChillNExplore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMap : ContentPage
	{
		public MainMap ()
		{
			InitializeComponent ();

            List<Pin> pins = new List<Pin>();



            var map = new Map(MapSpan.FromCenterAndRadius(new Position(47.3214132, 5.0418964000000415), Distance.FromMiles(0.3)))
            {
                //IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stlMap.Children.Add(map);

            var pin = new Pin()
            {
                Position = new Position(47.3214132, 5.0418964000000415),
                Label = "Palais des Ducs de Bourgogne"
            };

            map.Pins.Add(pin);

            pin.Clicked += (sender, e) => {
                Navigation.PushAsync(new PinPage());
            };


        }

        
	}
}