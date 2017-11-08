using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    class Day
    {
        ObservableCollection<CalendarEvent> _events = new ObservableCollection<CalendarEvent>();
        string _date;

        public ObservableCollection<CalendarEvent> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
