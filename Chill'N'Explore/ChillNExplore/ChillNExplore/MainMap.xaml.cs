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
            //var laVille = App.nameCity;
            ///// calculer ses coordonnee grâce à une query sur l'api (appel de la methode 
            //string stringLatitude = "http://35.190.168.129:8080/api/ChillNExplore/" + laVille + "/GetLatForCity";
            //string stringLongitude = "http://35.190.168.129:8080/api/ChillNExplore/" + laVille + "/GetLngForCity";

            //double latitude = double.Parse(stringLatitude);
            //double longitude = double.Parse(stringLongitude);
     
            //List<Pin> pins = new List<Pin>();



            var map = new Map(MapSpan.FromCenterAndRadius(new Position(47.3212274, 5.027678899999955), Distance.FromMiles(0.3)))
            {
                //IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // AJout de la map
            stlMap.Children.Add(map);

            //"http://35.190.168.129:8080/api/ChillNExplore/" + laVille + "/GetInterestWithLocation";

            var pin = new Pin()
            {
                Position = new Position(47.3212274, 5.027678899999955),
                Label = "Jardin de l'Arquebuse"
            };

            map.Pins.Add(pin);

            pin.Clicked += (sender, e) => {
                Navigation.PushAsync(new PinPage());
            };


        }


    }
}