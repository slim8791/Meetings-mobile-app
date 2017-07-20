using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMeetings
{
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(List)));
            var masterDetailItem = new List<MasterDetailItem>();
            masterDetailItem.Add(new MasterDetailItem
            {
                Title = "Carousel",
                IconSource = "icon.png",
                TargetType = typeof(Carousel)
            });
            masterDetailItem.Add(new MasterDetailItem
            {
                Title = "Tabbed",
                IconSource = "icon.png",
                TargetType = typeof(Tabbed)
            });
            masterDetailItem.Add(new MasterDetailItem
            {
                Title = "Slider",
                IconSource = "icon.png",
                TargetType = typeof(Slider)
            });
            MenuList.ItemsSource = masterDetailItem;



        }


        private void MenuList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MenuList.SelectedItem = null;
                IsPresented = false;
            }

        }
    }
}
