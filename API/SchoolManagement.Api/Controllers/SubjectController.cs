using Microsoft.AspNetCore.Mvc;
using School.Model.Models;
using School.DataAccess.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // GET: api/subject/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // POST: api/subject
        [HttpPost]
        public async Task<ActionResult<Subject>> CreateSubject(Subject subject)
        {
            await _subjectService.AddSubjectAsync(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.SubjectId }, subject);
        }

        // PUT: api/subject/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            await _subjectService.UpdateSubjectAsync(subject);
            return NoContent();
        }

        // DELETE: api/subject/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            await _subjectService.DeleteSubjectAsync(id);
            return NoContent();
        }
    }
}
