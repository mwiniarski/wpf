using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calendar.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Model.Calendar calendarInstance;

        public MainWindowViewModel()
		{
            this.calendarInstance = new Model.Calendar();
		}

		public Model.Calendar Calendar
		{
			get
			{
				return calendarInstance;
			}
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

        void DoSomething()
        {
            Console.WriteLine("HEHEHE");
        }

		public ICommand ButtonCommandProperty { get { return  new RelayCommand(DoSomething); } }

    }
}
