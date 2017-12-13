using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    class Storage
    {
        Person p;

        public void logInPerson(string login)
        {
            using (var db = new StorageContext())
                p = db.Persons.Where(b => b.UserId == login).FirstOrDefault();
            Console.WriteLine(string.Format("{0} {1} logged in.", p.FristName, p.LastName));
        }

        public List<Appointment> getAppointments()
        {
            using (var db = new StorageContext())
            {
                var q = from a in db.Appointments
                        join att in db.Attendances on a.AppointmentId equals att.Appointment.AppointmentId
                        where att.Person.PersonId == p.PersonId
                        select a;
                return new List<Appointment>(q.OrderBy(i => i.StartTime));
            }
        }

        public void addAppointment(Appointment a)
        {
            Console.WriteLine(a.StartTime);
            using (var db = new StorageContext())
            {
                a.AppointmentId = Guid.NewGuid();
                db.Appointments.Add(a);

                Attendance at = new Attendance
                {
                    AttendanceId = Guid.NewGuid(),
                    accepted = true,
                    PersonId = p.PersonId,
                    AppointmentId = a.AppointmentId
                };

                db.Attendances.Add(at);
                db.SaveChanges();
            }
        }

        //public void addPerson()
        //{
        //    Person p = new Person
        //    {
        //        PersonId = Guid.NewGuid(),
        //        UserId = "test",
        //        FristName = "Michal",
        //        LastName = "Winiarski"
        //    };

        //    using (var db = new StorageContext())
        //    {
        //        db.Persons.Add(p);
        //        db.SaveChanges();

        //    }
        //}

        public bool updateAppointment(Appointment Old, Appointment New)
        {
            using (var db = new StorageContext())
            {
                var original = db.Appointments.Find(Old.AppointmentId);
                if (original != null)
                {
                    original.StartTime = New.StartTime;
                    original.Title = New.Title;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch(DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Error while updating database! Try again.");
                        return false;
                    }                     
                }
            }
            return true;
        }

        public bool removeAppointment(Appointment Old)
        {
            using (var db = new StorageContext())
            {
                var original = db.Appointments.Find(Old.AppointmentId);
                if (original != null)
                {
                    db.Appointments.Remove(original);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Error while updating database! Try again.");
                        return false;
                    }      
                }
            }
            return true;
        }
    }
}
