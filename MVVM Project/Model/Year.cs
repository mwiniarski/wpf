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
        {
            Days = new ObservableCollection<Day>();
        }

        public ObservableCollection<Day> Days { get; set; }
        public int Week { get; set; }

        public void InitYear(bool serialized)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Week = dfi.Calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            if (!serialized)
            {
                DateTime dt = new DateTime(2017, 1, 1);
                for (int i = 0; i < 500; i++)
                {   
                    Days.Add(new Day { Date = dt });
                    dt = dt.AddDays(1);
                }
            }
        }
    }
}
