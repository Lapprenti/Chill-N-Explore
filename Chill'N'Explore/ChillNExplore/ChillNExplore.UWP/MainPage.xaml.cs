﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ChillNExplore.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ChillNExplore.App());
            /// Mise en place de la clef permettant d'acceder a la map bing
            Xamarin.FormsMaps.Init("AlTbw0TeyxoiLwkHf7srnEFoazimb10XUE19PsRON9EWnUkbvmS7AYcSrYLwCeQL");
        }
    }
}
