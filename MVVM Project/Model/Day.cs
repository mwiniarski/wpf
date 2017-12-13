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
        public Day() 
        {
            Date = new DateTime();
        }

        ObservableCollection<Appointment> _events = new ObservableCollection<Appointment>();

        public ObservableCollection<Appointment> Events
        {
            get { return _events; }
            set { _events = value; RaisePropertyChanged("Events"); }
        }

        public DateTime Date { get; set; }

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
