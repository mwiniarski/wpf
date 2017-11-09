using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Year
    {
        public Year() 
        {}

        ObservableCollection<Day> _days = new ObservableCollection<Day>();

        public void InitYear(bool serialized)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Week = dfi.Calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            if (!serialized)
            {
                DateTime dt = new DateTime(2017, 1, 1);
                for (int i = 0; i < 365; i++)
                {
                    Days.Add(new Day { Date = dt });
                    dt = dt.AddDays(1);
                }
            }
        }

        public ObservableCollection<Day> Days
        {
            get { return _days; }
            set { _days = value; }
        }

        int _week;
        public int Week
        {
            get { return _week; }
            set { _week = value; }
        }
    }
}
