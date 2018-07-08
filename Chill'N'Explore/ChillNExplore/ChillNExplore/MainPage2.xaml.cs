using Plugin.SimpleAudioPlayer;
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
	public partial class MainPage2 : ContentPage
	{
		public MainPage2 (string Langue)
		{
			InitializeComponent ();
            if (Langue == "English")
            {
                LabelMainPage.Text = "With Chill'N'Explore, discover the town where you are!";
            }
            else if (Langue == "French")
            {
                LabelMainPage.Text = "Avec Chill'N'Explore, découvrez ou re-découvrez la ville ou vous êtes !";
            }
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            Logo.GestureRecognizers.Add(new TapGestureRecognizer(OnTap));
            ParametreLogo.GestureRecognizers.Add(new TapGestureRecognizer(ParamLang));
            
        }
        private void ParamLang(View arg1, object arg2)
        {
            App.Current.MainPage = new NavigationPage(new LangSetting());

        }
        private void OnTap(View arg1, object arg2)
        {
            App.Current.MainPage = new NavigationPage(new ErrorLog());
            var clickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            clickSound.Load("Beep.mp3");
            clickSound.Play();
        }

    }
}