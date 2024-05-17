using Microsoft.EntityFrameworkCore;
using Student_edu.Core.DTO;
using Student_edu.Core.IRepositories;
using Student_edu.Core.Models;
using Student_edu.Infrastructure.DBConnection;
using Student_edu.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_edu.Services.Services
{
    public  class StudentService:IStudentService
    {
        private IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> repository)
        {
            _studentRepository = repository;
        }

        public async Task<GenericResponse> Add(AddStudentDTO student)
        {
            var new_student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = student.Name,
                Address = student.Address,
                age = student.age,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                Gender = student.Gender,
                Nationality = student.Nationality,
                DateOfBirth = student.DateOfBirth
            };

            var result = await _studentRepository.Add(new_student); 
            return result;

        }

        public async Task<GenericResponse> Delete(Guid id)
        {
            var result =  await _studentRepository.Delete(id);
            return result;
        }

        public async Task <List<StudentResponseDto>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<GenericResponse> Update(UpdateStudentDTO student)
        {
            try
            {
                var Dbstudent = await _dbContext.Students.FindAsync(student.Id);
                if (Dbstudent == null)
                {
                    return false;
                }

                Dbstudent.Name = student.Name;
                Dbstudent.Email = student.Email;
                Dbstudent.Address = student.Address;
                Dbstudent.PhoneNumber = student.PhoneNumber;
                Dbstudent.DateOfBirth = student.DateOfBirth;
                Dbstudent.Nationality = student.Nationality;
                Dbstudent.Gender = student.Gender;
                Dbstudent.age = student.age;
                _dbContext.Students.Update(Dbstudent);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       


}
}
