using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public virtual List<Attendance> Attendances { get; set; }

        public override string ToString()
        {
            return StartTime.ToString("HH:mm") + " " + Title;
        }
    }
}
