using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMeetings.Model;
using Plugin.RestClient;
using Xamarin.Forms;

namespace AppMeetings.Services
{
    public class CoffeeService
    {
        public Task<List<Coffee>> GetsCoffees()
        {

            RestClient<Coffee> restclient = new RestClient<Coffee>();
            var coffeelist = restclient.GetAsync();
            return coffeelist;
        }


    }
}
