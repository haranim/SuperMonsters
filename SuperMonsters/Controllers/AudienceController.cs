using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMonsters.IServices;
using SuperMonsters.Models;

namespace SuperMonsters.Controllers
{
    [Route("supermonsters/audience")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IAudienceService _audienceService;

        public AudienceController(IAudienceService audienceService)
        {
            _audienceService = audienceService;
        }

        [HttpGet]
        public ActionResult<List<Audience>> Get()
        {
            return _audienceService.Get();
        }

        [HttpGet("{id}", Name = "GetbyId")]
        public ActionResult<Audience> Get(string id)
        {
            var audience = _audienceService.Get(id);

            if (audience == null)
            {
                return NotFound();
            }

            return audience;
        }

        [HttpPost]
        public ActionResult<Audience> Post([FromBody] Audience audience)
        {
            _audienceService.Create(audience);

            return CreatedAtRoute("GetAudience", new { id = audience.Id.ToString() }, audience);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Audience audienceIn)
        {
            var audience = _audienceService.Get(id);

            if (audience == null)
            {
                return NotFound();
            }

            _audienceService.Update(id, audienceIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var audience = _audienceService.Get(id);

            if (audience == null)
            {
                return NotFound();
            }

            _audienceService.Remove(audience.Id);

            return NoContent();
        }
    }
}
