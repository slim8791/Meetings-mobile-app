using System;
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

namespace AppMeetings.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.FormsMaps.Init("ArXCxPzo0-PK4x3Z9DIqAr0uU5AuhDIA3fH3tzPN0NbSVfgt6RqP8H3VomWyos6W");
            LoadApplication(new AppMeetings.App());
        }
    }
}
