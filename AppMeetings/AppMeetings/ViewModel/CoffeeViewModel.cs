using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppMeetings.Model;
using AppMeetings.Services;
using AppMeetings.View;
using Xamarin.Forms;

namespace AppMeetings.ViewModel
{
        public class CoffeeViewModel :INotifyPropertyChanged
        {
            private INavigation _navigation;
        private List<Coffee> _coffeeList;
        private Coffee _myCoffee = new Coffee();
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

            private bool _isRefresh = false;

            public bool IsRefresh
            {
            get { return _isRefresh; }
                set
                {
                    _isRefresh = value;
                    OnPropertyChanged();
                }
            }

            public ICommand Refresh
            {
                get
                {
                    return new Command(async () =>
                    {
                    IsRefresh = true;
                    GetList();
                    IsRefresh = false;
            });
                }
            }
            public Coffee MyCoffee
            {
                get { return _myCoffee; }
                set
                {
                    _myCoffee = value;
                    OnPropertyChanged();
                }
            }
            private async Task GetList()
            {
                CoffeeService services = new CoffeeService();
                CoffeeList = await services.GetsCoffees();
            }

            public CoffeeViewModel(INavigation nav)
            {
                GetList();
                _navigation = nav;
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

       public Command PostCommand
        {
            get
            {
                return new Command((() =>
                {
                    var services = new CoffeeService();
                    services.PostCoffees(MyCoffee);

                    _navigation.PushAsync(new CoffeeView());
                }));
            }

        }
    }
}
