﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMeetings.ViewModel;
using Xamarin.Forms;

namespace AppMeetings.View
{
    public partial class CoffeeView : ContentPage
    {
        public CoffeeView()
        {
            InitializeComponent();
            BindingContext = new CoffeeViewModel(this.Navigation);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCoffee());
        }
    }
}
