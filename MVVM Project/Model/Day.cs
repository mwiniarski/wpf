using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Day : INotifyPropertyChanged
    {
        ObservableCollection<CalendarEvent> _events = new ObservableCollection<CalendarEvent>();
        DateTime _date = new DateTime();

        public ObservableCollection<CalendarEvent> Events
        {
            get { return _events; }
            set { _events = value; RaisePropertyChanged("Events"); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value;  }
        }

        public String DateString
        {
            get { return String.Format("{0:MMM d}", Date); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
