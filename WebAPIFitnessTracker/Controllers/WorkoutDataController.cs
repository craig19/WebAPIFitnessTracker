using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIFitnessTracker.Data;
using WebAPIFitnessTracker.Models;

namespace WebAPIFitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutDataController : ControllerBase
    {
        private readonly WebAPIFitnessTrackerContext _context;

        public WorkoutDataController(WebAPIFitnessTrackerContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutData>>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        // GET: api/WorkoutData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutData>> GetWorkoutData(int id)
        {
            var workoutData = await _context.Workouts.FindAsync(id);

            if (workoutData == null)
            {
                return NotFound();
            }

            return workoutData;
        }

        // PUT: api/WorkoutData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutData(int id, WorkoutData workoutData)
        {
            if (id != workoutData.ID)
            {
                return BadRequest();
            }

            _context.Entry(workoutData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutDataExists(id))
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

        // POST: api/WorkoutData
        [HttpPost]
        public async Task<ActionResult<WorkoutData>> PostWorkoutData(WorkoutData workoutData)
        {
            _context.Workouts.Add(workoutData);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetWorkoutData", new { id = workoutData.ID }, workoutData);
        }

        // DELETE: api/WorkoutData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkoutData>> DeleteWorkoutData(int id)
        {
            var workoutData = await _context.Workouts.FindAsync(id);
            if (workoutData == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workoutData);
            await _context.SaveChangesAsync();

            return workoutData;
        }

        private bool WorkoutDataExists(int id)
        {
            return _context.Workouts.Any(e => e.ID == id);
        }
    }
}
