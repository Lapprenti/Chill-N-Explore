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
	public partial class AddAcc1 : ContentPage
	{
        string AddrAccount;
        string MdpAccount;
		public AddAcc1 ()
		{
			InitializeComponent ();
     
		}

        public void AddAccount_Clik(object sender, EventArgs a)
        {
            if (Addr.Text != AddrVerif.Text)
            {
                Addr.BackgroundColor = Color.Red;
                AddrVerif.BackgroundColor = Color.Red;
                if (Mdp.Text != MdpVerif.Text)
                {
                    Mdp.BackgroundColor = Color.Red;
                    MdpVerif.BackgroundColor = Color.Red;
                }
            }
            else if (Mdp.Text != MdpVerif.Text)
            {
                Mdp.BackgroundColor = Color.Red;
                MdpVerif.BackgroundColor = Color.Red;
                if (Addr.Text != AddrVerif.Text)
                {
                 
                    Addr.BackgroundColor = Color.Red;
                    AddrVerif.BackgroundColor = Color.Red;
                }
                }
            else
            {
                AddrAccount = Addr.Text;
                MdpAccount = Mdp.Text;
                App.Current.MainPage = new NavigationPage(new AddAcc2());
            }

            }

        public void ChangeAddr(object sender, EventArgs a)
        {
            Addr.BackgroundColor = Color.White;
            AddrVerif.BackgroundColor = Color.White;
        }
        public void ChangeMdp(object sender, EventArgs a)
        {
            Mdp.BackgroundColor = Color.White;
            MdpVerif.BackgroundColor = Color.White;

        }



    }
}