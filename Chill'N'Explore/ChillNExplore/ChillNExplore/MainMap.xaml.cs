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

            var map = new Map(MapSpan.FromCenterAndRadius(new Position(47.3301533, 5.017527200000018), Distance.FromMiles(0.3)))
            {
                //IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stlMap.Children.Add(map);
        }

        
	}
}