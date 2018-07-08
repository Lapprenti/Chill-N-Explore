using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChillNExplore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ErrorLog : ContentPage
	{
		public ErrorLog ()
		{
			InitializeComponent ();
            AlrdAcc.GestureRecognizers.Add(new TapGestureRecognizer(AlrdAccClick));
            AddAcc.GestureRecognizers.Add(new TapGestureRecognizer(AddAccClick));
            CondUtil.GestureRecognizers.Add(new TapGestureRecognizer(CondUtilClick));

        }
        private void AlrdAccClick(View arg1, object arg2)
        {
           
            App.Current.MainPage = new NavigationPage(new MainMap());
        }
        private void AddAccClick(View arg1, object arg2)
        {

            App.Current.MainPage = new NavigationPage(new AddAcc2());
        }

        private void CondUtilClick(View arg1, object arg2)
        {
            App.Current.MainPage = new NavigationPage(new ConditionsUtilisation());
        }
    }
}