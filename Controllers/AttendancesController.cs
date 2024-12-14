using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MamunTutorial.Data;
using MamunTutorial.Models;

namespace MamunTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AttendancesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendence()
        {
            return await _context.Attendence.ToListAsync();
        }

        // GET: api/Attendances/id
        [HttpGet("id")]
        public async Task<ActionResult<Attendance>> GetAttendance([FromQuery] Guid id)
        {
            var attendance = await _context.Attendence.FindAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpGet("allAttendances")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
        {
            return await _context.Attendence.ToListAsync();
        }


        // PUT: api/Attendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(Guid id, Attendance attendance)
        {
            if (id != attendance.AttendenceId)
            {
                return BadRequest();
            }

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Attendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            _context.Attendence.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendenceId }, attendance);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(Guid id)
        {
            var attendance = await _context.Attendence.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendence.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceExists(Guid id)
        {
            return _context.Attendence.Any(e => e.AttendenceId == id);
        }
    }
}
