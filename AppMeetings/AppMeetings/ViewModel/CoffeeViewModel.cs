using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppMeetings.Model;
using AppMeetings.Services;

namespace AppMeetings.ViewModel
{
        public class CoffeeViewModel :INotifyPropertyChanged
    {

        private List<Coffee> _coffeeList;

        public List<Coffee> CoffeeList
            {
            get
            {
                return _coffeeList;
            }
              set
               {
                  _coffeeList = value;
                  OnPropertyChanged();
                }
        }

            private async Task GetList()
            {
                CoffeeService services = new CoffeeService();
                CoffeeList = await services.GetsCoffees();
            }

            public CoffeeViewModel()
            {
                GetList();
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}
