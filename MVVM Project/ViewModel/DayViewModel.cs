﻿using Calendar.Model;
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
        public ObservableCollection<Day> Days
        {
            get { return days; }
            set { days = value; }
        }

        Year _year;
        public Year CurrentYear
        {
            get { return _year; }
            set { _year = value; }
        }

        public DayViewModel()
        {
            LoadFromFile();
            for(int i=0; i < 28; i++)
            {
                Days.Add(CurrentYear.Days[i + CurrentYear.Week * 7 - 6]);
            }
        }

        private void UpdateCalendar()
        {
            Days.Clear();

            for (int i = 0; i < 28; i++)
            {
                Days.Add(CurrentYear.Days[i + _year.Week * 7 - 6]);
            }
        }

        private void SaveToFile()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Year));
            TextWriter tw = new StreamWriter(@"C:\Temp\garage.xml");
            xs.Serialize(tw, CurrentYear);
        }

        private void LoadFromFile()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Year));
            try {
                var sr = new StreamReader(@"C:\Temp\garage.xml");
                CurrentYear = (Year)xs.Deserialize(sr);
                CurrentYear.InitYear(true);
                sr.Close();
            }  
            catch (Exception e)
            {
                CurrentYear = new Year();
                CurrentYear.InitYear(false);
            }
        }

        public void AddEventToDay(Day d, CalendarEvent ev)
        {
            d.Events.Add(ev);
            d.Events = new ObservableCollection<CalendarEvent>(d.Events.OrderBy(i => i.Time));
            SaveToFile();
        }

        public void EditEventOnDay(Day d, CalendarEvent Old, CalendarEvent New)
        {
            d.Events.Remove(Old);
            d.Events.Add(New);
            d.Events = new ObservableCollection<CalendarEvent>(d.Events.OrderBy(i => i.Time));
            SaveToFile();
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
            if (CurrentYear.Week == 49)
                return;
            CurrentYear.Week += 1;
            UpdateCalendar();
        }
        public ICommand NextWeek { get { return new RelayCommand(NextWeekMethod); } }

    }
}
