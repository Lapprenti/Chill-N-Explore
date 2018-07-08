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
    public partial class IndexDetail : ContentPage
    {
        public IndexDetail()
        {
            InitializeComponent();
        }

        public async void BtnPlay_Clicked(object sender, EventArgs e)
        {
           
         await Navigation.PushAsync(new MainMap());
        }
    }
}