using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Services;
using School.Model.Models;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly ImarkService _markService;

        public MarksController(ImarkService markService)
        {
            _markService = markService;
        }

        // GET: api/Marks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetMarks()
        {
            var marks = await _markService.GetAllMarksAsync();
            return Ok(marks);
        }

        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMark(int id)
        {
            var mark = await _markService.GetMarkByIdAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

        // POST: api/Marks
        [HttpPost]
        public async Task<ActionResult> PostMark(Mark mark)
        {
            if (mark == null)
            {
                return BadRequest("Mark is null.");
            }

            await _markService.AddMarkAsync(mark);
            return CreatedAtAction(nameof(GetMark), new { id = mark.MarkId }, mark);
        }

        // PUT: api/Marks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark(int id, Mark mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest("Mark ID mismatch.");
            }

            await _markService.UpdateMarkAsync(mark);
            return NoContent();
        }

        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            var mark = await _markService.GetMarkByIdAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            await _markService.DeleteMarkAsync(id);
            return NoContent();
        }

       
    }

}
