using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Calendar : ContentPage
    {
        public Calendar()
        {
            InitializeComponent();
            calendar.FirstDayofWeek = 1;
            DateTime blackOutDate = new DateTime(2017,7,23);
            List<DateTime> blackOutList = new List<DateTime>();
            blackOutList.Add(blackOutDate);
            calendar.BlackoutDates = blackOutList;

            CalendarInlineEvent events = new CalendarInlineEvent();

            events.StartTime = new DateTime(2017,8,1);

            events.EndTime = new DateTime(2017, 8, 2);

            events.Subject = "First tuesday";

            events.Color = Color.Aqua;

            CalendarEventCollection collection = new CalendarEventCollection();
            collection.Add(events);

            calendar.DataSource = collection;

            calendar.Locale = new System.Globalization.CultureInfo("fr-FR");
        }
        
    }
}
