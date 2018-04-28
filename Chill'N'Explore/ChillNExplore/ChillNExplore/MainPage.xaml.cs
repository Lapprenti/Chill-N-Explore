using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChillNExplore
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        public void BtnPlay_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainMap());
            App.nameCity = NomDeLaVille.Text;
            App.typeName = TypeLieu.Text;
        }
    }
}
