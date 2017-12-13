using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Attendance
    {
        public Guid AttendanceId { get; set; }
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
        public bool accepted { get; set; }
    }
}
