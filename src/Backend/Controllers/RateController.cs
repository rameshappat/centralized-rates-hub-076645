using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizedRatesHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpPost]
        [Authorize(Roles = "RatesCommittee")]
        public async Task<IActionResult> CreateRate([FromBody] RateDto rateDto)
        {
            if (rateDto == null)
            {
                return BadRequest("Rate data is required.");
            }

            try
            {
                var createdRate = await _rateService.CreateRateAsync(rateDto);
                return CreatedAtAction(nameof(GetRate), new { id = createdRate.Id }, createdRate);
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRate(int id)
        {
            var rate = await _rateService.GetRateByIdAsync(id);
            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateDto>>> GetAllRates()
        {
            var rates = await _rateService.GetAllRatesAsync();
            return Ok(rates);
        }
    }
}