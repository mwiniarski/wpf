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
           
            for(int i=0; i<28; i++)
            {
                if(Days[i].Date == d.Date)
                {
                    Days[i].Events.Add(ev);
                }
            }
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
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //public ObservableCollection<CalendarEvent>[] Events
        //{
        //    get { return _events; }
        //    set { _events = value; }
        //}

        //public DayViewModel()
        //{
        //    for (int i = 0; i < 28; i++ )
        //        _events[i] = new ObservableCollection<CalendarEvent>();

        //    _events[0].Add(new CalendarEvent { Title = "Sample event!" });
        //    _events[0].Add(new CalendarEvent { Title = "Second event!" });
        //}

        //void EditEventMethod(Object parameter)
        //{
        //    CalendarEvent a = parameter as CalendarEvent;
        //    Console.WriteLine(a.Title);
        //}

        //public ICommand EditEvent { get { return new RelayCommand(EditEventMethod); } }

        //void AddEventMethod(Object parameter)
        //{
        //    int x = Int32.Parse(parameter as String);
        //    _events[x].Add(new CalendarEvent { Title = "NEW EVENT :)" });
        //}
        //public ICommand AddEvent { get { return new RelayCommand(AddEventMethod); } }

    }
}
