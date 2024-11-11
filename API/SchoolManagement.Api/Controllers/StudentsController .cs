using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Services;
using School.Model.Models;

namespace SchoolManagement.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid || id != student.StudentId)
                return BadRequest();

            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }


        [HttpGet("ranked")]
        public async Task<ActionResult<List<StudentRankViewModel>>> GetRankedStudents()
        {
            var students = await _studentService.GetRankedStudentsAsync();
            return Ok(students);
        }

        [HttpGet("allData")]
        public async Task<ActionResult<List<StudentRankViewModel>>> GetMarkStudents()
        {
            var students = await _studentService.GetMarkStudentsAsync();
            return Ok(students);
        }
    }


}
