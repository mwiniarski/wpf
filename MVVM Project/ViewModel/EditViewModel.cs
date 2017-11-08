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

        private string _title;
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

        public void Dispose()
        {
            
        }

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
