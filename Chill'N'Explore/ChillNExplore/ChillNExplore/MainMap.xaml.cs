using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
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
            /// Récupérer la ville entrée dans la textbox
            /// calculer ses coordonnee grâce à une query sur l'api (appel de la methode 
            /// 

            
           
            

            ///
            var map = new Map(MapSpan.FromCenterAndRadius(new Position(47.3301533, 5.017527200000018), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // AJout de la map
            stlMap.Children.Add(map);

            //    var pin = new Pin()
            //    {
            //        Position = new Position(47.3301533, 5.017527200000018),
            //        Label = "Vous êtes ici !"
            //    };

            //    map.Pins.Add(pin);
        }


        private async void GetRequestAccessAsync()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

        }


    }
}