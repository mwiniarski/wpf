using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Model
{
    public class Person
    {
        public Guid PersonId { get; set; }
        [MaxLength(32), Required, Index(IsUnique = true)]
        public string UserId { get; set; }
        [MaxLength(200)]
        public string FristName { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
    }
}
