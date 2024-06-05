using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataReadApi;
using DataReadApi.Models;
//using EventBus.Base.Abstraction;
using DataReadApi.Models.Devices;

namespace DataWriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly WriteDbContext _context;
        private RegisterController registerController;
        //private readonly IEventBus _eventBus;

        public RegistersController(WriteDbContext context)
        {
            //_eventBus = eventBus;
            _context = context;
            registerController =new RegisterController(context);
            registerController.Initialize();
        }

        // GET: api/Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegister()
        {
            return await _context.Register.ToListAsync();
        }

        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(int id)
        {
            var register = await _context.Register.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }

        // PUT: api/Registers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(int id, Register register)
        {
            if (id != register.Id)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(List<Register> registers)
        {
            foreach (Register register in registers)
            {

                _context.Entry(register).State = EntityState.Modified;

                try
                {
                    var reg = await _context.Register.FindAsync(register.Id);
                    reg.Value = register.Value;
                    await _context.SaveChangesAsync();
                    // Register değişikliğini bir olay mesajı olarak yayınla
                    //_eventBus.Publish(new RegisterChangedIntegrationEvent(register));

                    //return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            registerController.updateRegisters(registers);
            return CreatedAtAction("GetRegister", new { id = registers[0].Id }, registers[0]);

        }

        // DELETE: api/Registers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegister(int id)
        {
            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Register.Remove(register);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.Id == id);
        }
    }
}
