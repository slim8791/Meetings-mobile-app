using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Slider : ContentPage
    {
        public Slider()
        {
            InitializeComponent();
        }

        private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            SliderLabel.Text = MySlider.Value.ToString();
        }
    }
}
