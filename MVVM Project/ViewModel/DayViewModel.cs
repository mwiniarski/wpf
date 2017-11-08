using Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class DayViewModel : INotifyPropertyChanged
    {
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

        ObservableCollection<Day> days = new ObservableCollection<Day>();

        public DayViewModel()
        {
            for(int i=0; i < 28; i++)
            {
                ObservableCollection<CalendarEvent> ev = new ObservableCollection<CalendarEvent>();
                ev.Add(new CalendarEvent{ Title = "Nowiutki event!"});
                Day day = new Day{ Date = string.Format("Nov {0}", i), Events = ev};
                days.Add(day);
            }
        }

        public ObservableCollection<Day> Days
        {
            get { return days; }
            set { days = value; }
        }

        public void AddEventToDay(Day d, CalendarEvent ev)
        {
            d.Events.Add(ev);
            d.Events = new ObservableCollection<CalendarEvent>(d.Events.OrderBy(i => i.Title));
        }

        public void EditEventOnDay(Day d, CalendarEvent ev)
        {
            d.Events.Remove(ev);
            ev.Title = "HEHEHE";
            d.Events.Add(ev);
            d.Events = new ObservableCollection<CalendarEvent>(d.Events.OrderBy(i => i.Title));
        }

        void AddEventMethod(Object parameter)
        {
            Day day = parameter as Day;
            Console.WriteLine(day.Date);
        }
        public ICommand AddEvent { get { return new RelayCommand(AddEventMethod); } }

        void EditEventMethod(Object parameter)
        {
            CalendarEvent ev = parameter as CalendarEvent;
            Console.WriteLine(ev.Title);

        }
        public ICommand EditEvent { get { return new RelayCommand(EditEventMethod); } }

    }
}
