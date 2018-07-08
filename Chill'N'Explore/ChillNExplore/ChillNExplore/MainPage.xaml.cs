using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;


namespace ChillNExplore
{
	public partial class MainPage : ContentPage
	{
        ProfilsDataAccess dataAccess;
        Profil LeProfil;
        public MainPage()
		{
			InitializeComponent();
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            Logo.GestureRecognizers.Add(new TapGestureRecognizer(OnTap));
            ParametreLogo.GestureRecognizers.Add(new TapGestureRecognizer(ParamLang));
            player.Load("Music1.mp3");
            player.Play();

            this.dataAccess = new ProfilsDataAccess();
            LeProfil = this.dataAccess.GetProfil();

            if (LeProfil == null)
            {
                LabelMainPage.Text = "Avec Chill'N'Explore, découvrez ou re-découvrez la ville ou vous êtes !";
            }
            else
            {
                if (LeProfil.Lang == "French")
                {
                    LabelMainPage.Text = "Avec Chill'N'Explore, découvrez ou re-découvrez la ville ou vous êtes !";

                }

                else
                {
                    LabelMainPage.Text = "With Chill'N'Explore, discover the town where you are!";

                }

            }


        }
        public interface IDatabaseConnection
        {
            SQLite.SQLiteConnection DbConnection();

        }

        private void ParamLang(View arg1, object arg2)
        {
            //si aucun profil n'est ajouté il faut d'abord en créer un pour changer de langue
            if (LeProfil == null)
            {

                // Affiche le message d'erreur

                ErrorLang.Opacity = 100 ;
                //ErrorButt.Opacity = 100;


            }
            else
            {
                App.Current.MainPage = new NavigationPage(new LangSetting());
            }

        }
        private void OnTap(View arg1, object arg2)
        {

            // Erreur aucun profil trouvé
            if (LeProfil == null)
            {
                App.Current.MainPage = new NavigationPage(new ErrorLog());

            }
            // Si un profil est détécté alors se rend sur la page Map
            else
            {
                App.Current.MainPage = new NavigationPage(new MainMap());
            }


            var clickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            clickSound.Load("Beep.mp3");
            clickSound.Play();
        }

        public void BtnErr_Clicked(object sender, EventArgs e)
        {
            ErrorLang.Opacity = 0;
          //  ErrorButt.Opacity = 0;
            App.Current.MainPage = new NavigationPage(new ErrorLog());

        }
    }
}
