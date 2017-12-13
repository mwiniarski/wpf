using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace Calendar.Model
{
    class StorageContext : DbContext
    {
        public StorageContext()
            : base("Model.StorageContext") { }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
