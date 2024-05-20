using Microsoft.EntityFrameworkCore;
using Student_edu.Core.DTO;
using Student_edu.Core.IRepositories;
using Student_edu.Core.Mappers;
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

         async Task<GenericResponse> IStudentService.Add(AddStudentDTO student)
        {

            try
            {

                var new_student = EntityDtoMapper<Student, AddStudentDTO>.MapToEntity(student);
                var result = await _studentRepository.Add(new_student);
                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        async Task<GenericResponse> IStudentService.Delete(Guid id)
        {

            try
            {
                var obj = await _studentRepository.GetById(id);
                var result = await _studentRepository.Delete(obj);

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        async Task<IEnumerable<StudentResponseDto>> IStudentService.GetAll()
        {
            try
            {
                var students = await _studentRepository.GetAll();

                // Check if students is null and return an empty list if true
                if (students == null)
                {
                    return new List<StudentResponseDto>();
                }

                // Use the MapToDto method to map the list of entities to a list of DTOs
                var studentDtos = EntityDtoMapper<Student, StudentResponseDto>.MapToDto(students);
                return studentDtos;
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                throw new ApplicationException("An error occurred while retrieving students.", ex);
            }
        }

         async Task<GenericResponse> IStudentService.Update(UpdateStudentDTO student)
        {
           
            try
            {
                var new_student = EntityDtoMapper<Student, UpdateStudentDTO>.MapToEntity(student);
                var result = await _studentRepository.Update(new_student);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
