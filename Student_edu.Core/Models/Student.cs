using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Core.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public int? age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String? Address { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Gender { get; set; }
        public String? Nationality { get; set; }
    }
}
