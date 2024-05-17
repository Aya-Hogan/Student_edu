using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Core.DTO
{
    public  class GenericResponse // change to ginrec response
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
