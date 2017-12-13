using Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Calendar.ViewModel
{
    public class DayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<String> W { get; set; }
        public ObservableCollection<Day> Days { get; set; }

        Year CurrentYear { get; set; }
        Storage Db;
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DayViewModel()
        {
            Db = new Storage();
            W = new ObservableCollection<String>();
            Days = new ObservableCollection<Day>();
            Db.logInPerson(Environment.GetCommandLineArgs()[1]);
            CurrentYear = new Year();
            CurrentYear.InitYear(false);
            LoadFromDb();

            for (int i = 0; i < 28; i++)
            {
                Days.Add(CurrentYear.Days[i + CurrentYear.Week * 7 - 6]);
            }

            for (int i = 0; i < 4; i++)
            {
                if (CurrentYear.Week + i > 52)
                    W.Add(String.Format("W{0} 2018", CurrentYear.Week + i - 52));
                else
                    W.Add(String.Format("W{0} 2017", CurrentYear.Week + i));
            }
        }

        private void LoadFromDb()
        {
            var appointments = Db.getAppointments();
            foreach(var ap in appointments)
            {
                if(ap.StartTime.Year == 2017)
                    CurrentYear.Days[ap.StartTime.DayOfYear - 1].Events.Add(ap);
                else
                    CurrentYear.Days[ap.StartTime.DayOfYear + 364].Events.Add(ap);
            }
        }

        private void UpdateCalendar()
        {
            Days.Clear();

            for (int i = 0; i < 28; i++)
            {
                Days.Add(CurrentYear.Days[i + CurrentYear.Week * 7 - 6]);
            }

            W.Clear();
            for (int i = 0; i < 4; i++)
            {
                if (CurrentYear.Week + i > 52)
                    W.Add(String.Format("W{0} 2018", CurrentYear.Week + i - 52));
                else
                    W.Add(String.Format("W{0} 2017", CurrentYear.Week + i));
            }
        }

        public void AddEventToDay(Day d, Appointment New)
        {
            New.StartTime = new DateTime(d.Date.Year, d.Date.Month, d.Date.Day, New.StartTime.Hour, New.StartTime.Minute, 0);
            d.Events.Add(New);
            d.Events = new ObservableCollection<Appointment>(d.Events.OrderBy(i => i.StartTime));
            Db.addAppointment(New);
        }

        public void EditEventOnDay(Day d, Appointment Old, Appointment New)
        {
            New.StartTime = new DateTime(d.Date.Year, d.Date.Month, d.Date.Day, New.StartTime.Hour, New.StartTime.Minute, 0);
            if (Db.updateAppointment(Old, New))
            {
                d.Events.Remove(Old);
                d.Events.Add(New);
                d.Events = new ObservableCollection<Appointment>(d.Events.OrderBy(i => i.StartTime));
            }
        }

        public void RemoveEventFromDay(Day d, Appointment Old)
        {
            if (Db.removeAppointment(Old))
            {
                d.Events.Remove(Old);
            }
        }

        void PreviousWeekMethod(Object parameter)
        {
            if (CurrentYear.Week == 1)
                return;
            CurrentYear.Week -= 1;
            UpdateCalendar();
        }

        public ICommand PrevWeek { get { return new RelayCommand(PreviousWeekMethod); } }

        void NextWeekMethod(Object parameter)
        {
            if (CurrentYear.Week == 65)
                return;
            CurrentYear.Week += 1;
            UpdateCalendar();
        }
        public ICommand NextWeek { get { return new RelayCommand(NextWeekMethod); } }

    }
}
