using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class CalendarEvent
    {
        string _title;
        DateTime _time = new DateTime();

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public override string ToString()
        {
            return Time.ToString("HH:mm") + " " + _title;
        }
    }
}
