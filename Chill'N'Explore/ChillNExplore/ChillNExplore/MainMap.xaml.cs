using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ChillNExplore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMap : ContentPage
	{
		public MainMap ()
		{
			InitializeComponent ();
            /// Récupérer la ville entrée dans la textbox
            var laVille = App.nameCity;
            var leType = App.typeName;
            /// calculer ses coordonnee grâce à une query sur l'api (appel de la methode 
            string urlLatitude = "http://35.190.168.129/api/ChillNExplore/" + laVille + "/GetLatForCity";
            string urlLongitude = "http://35.190.168.129/api/ChillNExplore/" + laVille + "/GetLngForCity";

            string latitude = "";
            string longitude = "";
            try
            {
                HttpClient proxy = new HttpClient();
                //on recupere un http reponse
                var responseLat = proxy.GetAsync(urlLatitude).Result;
                latitude = responseLat.Content.ReadAsStringAsync().Result;
                var responseLng = proxy.GetAsync(urlLongitude).Result;
                longitude = responseLng.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            //double latitude = double.Parse(stringLatitude);
            //double longitude = double.Parse(stringLongitude);

            List<Pin> pins = new List<Pin>();

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(double.Parse(latitude), double.Parse(longitude)), Distance.FromMiles(0.3)))
            {
                //IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // AJout de la map
            stlMap.Children.Add(map);

            var jsonResultPlacesNamesWithCoordinates = "http://35.190.168.129:8080/api/ChillNExplore/" + laVille + "/" + leType + "GetInterestWithLocation";

            JArray result = JArray.Parse(jsonResultPlacesNamesWithCoordinates.ToString());
            //var placesNames = result.SelectToken("$.name");

            for (int i = 0; i < result.Count; i++)
            {
                var name = result[i].SelectToken("$.name");
                var lat = result[i].SelectToken("$.lat");
                var lng = result[i].SelectToken("$.lng");
                var pin = new Pin()
                {
                    Label = name.ToString(),
                    Position = new Position((double)lat,(double)lng)
                };

                map.Pins.Add(pin);
            }

            foreach (var pin in map.Pins)
            {
                pin.Clicked += (sender, e) => {
                    Navigation.PushAsync(new PinPage());
                };
            }

        }


    }
}