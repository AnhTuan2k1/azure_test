using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaBlazor.Shared.Models;

namespace CinemaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionRoomsController : ControllerBase
    {
        private readonly CinemaDBContext _context;

        public ProjectionRoomsController(CinemaDBContext context)
        {
            _context = context;
        }

        // GET: api/ProjectionRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectionRoom>>> GetProjectionRooms()
        {
            return await _context.ProjectionRooms.ToListAsync();
        }

        // GET: api/ProjectionRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectionRoom>> GetProjectionRoom(int id)
        {
            var projectionRoom = await _context.ProjectionRooms.FindAsync(id);

            if (projectionRoom == null)
            {
                return NotFound();
            }

            return projectionRoom;
        }

        // PUT: api/ProjectionRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectionRoom(int id, ProjectionRoom projectionRoom)
        {
            if (id != projectionRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectionRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectionRoomExists(id))
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

        // POST: api/ProjectionRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectionRoom>> PostProjectionRoom(ProjectionRoom projectionRoom)
        {
            _context.ProjectionRooms.Add(projectionRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectionRoom", new { id = projectionRoom.Id }, projectionRoom);
        }

        // DELETE: api/ProjectionRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectionRoom(int id)
        {
            var projectionRoom = await _context.ProjectionRooms.FindAsync(id);
            if (projectionRoom == null)
            {
                return NotFound();
            }

            _context.ProjectionRooms.Remove(projectionRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectionRoomExists(int id)
        {
            return _context.ProjectionRooms.Any(e => e.Id == id);
        }
    }
}
