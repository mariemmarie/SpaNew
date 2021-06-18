using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Models;
using SPA.Services;

namespace SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantsService _consultantService;

        public ConsultantsController(IConsultantsService consultantService)
        {
            _consultantService = consultantService;
        }

        // GET: api/Consultants
        [HttpGet]
        public async Task<IEnumerable<Consultant>> Get()
        {
            return await _consultantService.GetConsultantsList();
        }

        // GET: api/Consultants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultant>> Get(int id)
        {
            var consultant = await _consultantService.GetConsultantById(id);

            if (consultant == null)
            {
                return NotFound();
            }

            return Ok(consultant);
        }

        // POST: api/Consultants
        [HttpPost]
        public async Task<ActionResult<Consultant>> Post(Consultant consultant)
        {
            await _consultantService.CreateConsultant(consultant);

            return CreatedAtAction("Post", new { id = consultant.Id }, consultant);
        }

        // PUT: api/Consultants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Consultant consultant)
        {
            if (id != consultant.Id)
            {
                return BadRequest("Not a valid consultant id");
            }

            await _consultantService.UpdateConsultant(consultant);

            return NoContent();
        }

        // DELETE: api/Consultants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid consultant id");

            var consultant = await _consultantService.GetConsultantById(id);
            if (consultant == null)
            {
                return NotFound();
            }

            await _consultantService.DeleteConsultant(consultant);

            return NoContent();
        }
    }
}
