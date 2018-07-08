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
	public partial class LangSetting : ContentPage
	{
        string Langue = "French";
        ProfilsDataAccess dataAccess;
        Profil LeProfil;

        public string LeLanguage { get; private set; }

        public LangSetting ()
		{
			InitializeComponent ();
            this.dataAccess = new ProfilsDataAccess();
            LeProfil = this.dataAccess.GetProfil();
           
        }
        public void FrenchButt_Clicked(object sender, EventArgs e)
        {
            Langue = "French";
            LeProfil.Lang = Langue;
            dataAccess.UpdateProfil(LeProfil, LeProfil.Id);
            App.Current.MainPage = new NavigationPage(new MainPage());


        }
        public void EnglishButt_Clicked(object sender, EventArgs e)
        {
            Langue = "English";
           LeProfil.Lang = Langue;
            dataAccess.UpdateProfil(LeProfil, LeProfil.Id);
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        public class Language
        {
            public string LeLanguage { get; set; }

        }
    }
}