using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;



namespace ChillNExplore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAcc2 : ContentPage
    {
        private ProfilsDataAccess dataAccess;
        Profil LeProfil;
        public AddAcc2()
        {
            InitializeComponent();
            this.dataAccess = new ProfilsDataAccess();
        }
            public void Play_Clicked(object sender, EventArgs e)
        {
            this.dataAccess.AddNewProfil(PseudoEntry.Text);
            this.dataAccess.SaveAllProfils();
            
             App.Current.MainPage = new NavigationPage(new MainMap());

        }



    }
}