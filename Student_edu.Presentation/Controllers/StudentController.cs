using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_edu.Core.Models;
using Student_edu.Core.DTO;
using Student_edu.Services.IService;
using Student_edu.Services.Services;

namespace Student_edu.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent(AddStudentDTO student)
        {
            var result = await _studentService.Add(student);
            if (result.Success)
                return Ok(result);
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Deletestudent(Guid id)
        {
            var result = await _studentService.Delete(id);
            if (result.Success)
                return Ok(result);
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> getall()
        {
            var result = await _studentService.GetAll();
            if (result != null)
                return Ok(result);
            else { return BadRequest("nodata"); }

        }

        [HttpPut]
        [Route("update")]

        public async Task<IActionResult> update(UpdateStudentDTO student)
        {
            var result = await _studentService.Update(student);
            if (result.Success) return Ok();
            else
            {
                return BadRequest("no data");
            }
        }

    }
}
