using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Core.DTO
{
    public class StudentResponse: GenericResponse
    {
        public string FullName  { get; set; }
        public string Email { get; set; }
    }
}
