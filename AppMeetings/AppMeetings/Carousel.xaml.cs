﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Carousel : CarouselPage
    {
        public Carousel()
        {
            NavigationPage.SetHasBackButton(this,false);
            InitializeComponent();
        }
    }
}
