using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataWebApi;
using DataWebApi.Models;

namespace DataWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCentersController : ControllerBase
    {
        private TestCenterController _testCenterController;
        private readonly TestCenterDbContext _context;

        public TestCentersController(TestCenterDbContext context)
        {
            _context = context;
            _testCenterController = new TestCenterController(context);
        }

        // GET: api/TestCenters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestCenter>>> GetTestCenter()
        {
            //_testCenterController.GetValues();
            return await _context.TestCenter.ToListAsync();
        }


        // GET: api/TestCenters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCenter>> GetTestCenter(int id)
        {
            var testCenter = await _context.TestCenter.FindAsync(id);

            if (testCenter == null)
            {
                return NotFound();
            }

            return testCenter;
        }

        // PUT: api/TestCenters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCenter(int id, TestCenter testCenter)
        {
            if (id != testCenter.Id)
            {
                return BadRequest();
            }

            _context.Entry(testCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCenterExists(id))
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

        // POST: api/TestCenters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestCenter>> PostTestCenter(TestCenter testCenter)
        {
            _context.TestCenter.Add(testCenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestCenter", new { id = testCenter.Id }, testCenter);
        }

        // DELETE: api/TestCenters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestCenter(int id)
        {
            var testCenter = await _context.TestCenter.FindAsync(id);
            if (testCenter == null)
            {
                return NotFound();
            }

            _context.TestCenter.Remove(testCenter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestCenterExists(int id)
        {
            return _context.TestCenter.Any(e => e.Id == id);
        }
    }
}
