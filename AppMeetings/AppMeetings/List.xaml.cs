using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMeetings
{
    public partial class List : ContentPage
    {

        private List<Personne> personnes = new List<Personne>();
        public List()
        {
            
         InitializeComponent();
        personnes.Add(
                new Personne
                {
                    Nom = "Hammami",
                    Prenom = "Slim"
                }
                );
            personnes.Add(new Personne
            {
                Nom = "Mhamdi",
                Prenom = "Semah"
            });
            MyList.ItemsSource = personnes;
        }

        private void SearchName(object sender, TextChangedEventArgs e)
        {
            string keyWord = MySearchBar.Text;
            List<Personne> pers =
                personnes.Where(personne => personne.Nom.ToUpper().Contains(keyWord.ToUpper())).ToList();

            MyList.ItemsSource = pers;
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var m = ((MenuItem) sender);
            var personne = m.CommandParameter as Personne;
            if (personne != null)
            {
                DisplayAlert("Summer Trainning", "Hello " + personne.Nom + " " + personne.Prenom, "Cancel", "OK");
            }

        }
    }
}
