using Calendar.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class DayViewModel
    {
        ObservableCollection<CalendarEvent>[] _events = new ObservableCollection<CalendarEvent>[28];
        
        public ObservableCollection<CalendarEvent>[] Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public DayViewModel()
        {
            for (int i = 0; i < 28; i++ )
                _events[i] = new ObservableCollection<CalendarEvent>();

            _events[0].Add(new CalendarEvent { Title = "Sample event!" });
            _events[0].Add(new CalendarEvent { Title = "Second event!" });
        }

        void EditEventMethod()
        {
            Console.WriteLine("Edit");
        }

        public ICommand EditEvent { get { return new RelayCommand(EditEventMethod); } }

        void AddEventMethod()
        {
            Console.WriteLine("Add");
        }
        public ICommand AddEvent { get { return new RelayCommand(AddEventMethod); } }

    }
}
