using Student_edu.Core.Models;
using Student_edu.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Services.IService
{
    public interface IStudentService
    {
        public Task <List<StudentResponseDto>> GetAll();
        public Task  <GenericResponse> Delete(Guid id);
        public Task <GenericResponse> Update(UpdateStudentDTO student);
        public Task <GenericResponse> Add(AddStudentDTO student);

    }
}
