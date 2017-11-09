﻿using Calendar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class EditViewModel : INotifyPropertyChanged, IDisposable
    {
        public EditViewModel()
        {
            CloseCommand = new RelayCommand(
                new Action<object>(
                    delegate (object obj) 
                    {
                        CloseAction();
                    }
            ));
        }

        public Action CloseAction { get; set; }

        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get { return closeCommand; }
            set { closeCommand = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title)
                    return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _hour = "";
        public string Hour
        {
            get { return _hour; }
            set
            {
                if (value == _hour)
                    return;
                _hour = value;
                OnPropertyChanged("Hour");
            }
        }

        private string _minute = "";
        public string Minute
        {
            get { return _minute; }
            set
            {
                if (value == _minute)
                    return;
                _minute = value;
                OnPropertyChanged("Minute");
            }
        }
        
        public CalendarEvent MakeCalendarEvent()
        {
            var t = DateTime.Parse(string.Format("{0}:{1}", Hour, Minute));
            Console.WriteLine(t);
            return new CalendarEvent { Title = Title, Time = t };
        }

        public bool isValid()
        {
            return Title.Length != 0 && Hour.Length != 0 && Minute.Length !=0;
        }

        public void Dispose()
        {}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
