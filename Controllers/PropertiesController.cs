using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pisofinderapi.Data;
using pisofinderapi.Models;

namespace pisofinderapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController(PisoFinderContext context) : ControllerBase
    {
        private readonly PisoFinderContext _context = context;

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties
                                 .Include(p => p.Agent)
                                 .Include(p => p.PropertyType)
                                 .Include(p => p.Images)
                                 .Include(p => p.Address)
                                 .ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _context.Properties
                                         .Include(p => p.Agent)
                                         .Include(p => p.PropertyType)
                                         .Include(p => p.Images)
                                         .Include(p => p.Address)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            return property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _context.Entry(property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Check if the agent already exists in the database
                var existingAgent = await _context.Agents
                                                  .FirstOrDefaultAsync(a => a.Id == property.Agent.Id);

                if (existingAgent != null)
                {
                    // If the agent exists, link the existing agent to the property
                    property.AgentId = existingAgent.Id;
                    property.Agent = existingAgent;
                }
                else
                {
                    // If the agent does not exist, add the new agent to the context
                    _context.Agents.Add(property.Agent);
                    await _context.SaveChangesAsync(); // Save to get the new AgentId
                }

                // Add the property to the context
                _context.Properties.Add(property);
                await _context.SaveChangesAsync();

                // // Now, the PropertyId is set, so associate it with each image
                // foreach (var image in property.Images)
                // {
                //     image.PropertyId = property.Id;
                //     _context.PropertyImages.Add(image);
                // }

                // // Save all images
                // await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}