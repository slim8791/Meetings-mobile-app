using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMeetings.ViewModel;
using Xamarin.Forms;

namespace AppMeetings.View
{
    public partial class AddCoffee : ContentPage
    {
        public AddCoffee()
        {
            InitializeComponent();
            BindingContext = new CoffeeViewModel(this.Navigation);
        }
    }
}
