using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMeetings
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClickMe(object sender, EventArgs e)
        {
            DisplayAlert("TEK-UP Summer Trainning", "Bonjour", "Cancel");
        }
    }
}
