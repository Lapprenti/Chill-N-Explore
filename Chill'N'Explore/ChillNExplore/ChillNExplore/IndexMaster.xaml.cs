﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChillNExplore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexMaster : ContentPage
    {
        public ListView ListView;

        public IndexMaster()
        {
            InitializeComponent();

            BindingContext = new IndexMasterViewModel();
            ListView = MenuItemsListView;
        }

        class IndexMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<IndexMenuItem> MenuItems { get; set; }
            
            public IndexMasterViewModel()
            {
                MenuItems = new ObservableCollection<IndexMenuItem>(new[]
                {
                    new IndexMenuItem { Id = 0, Title = "Accueil" },
                    new IndexMenuItem { Id = 1, Title = "Profil" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}