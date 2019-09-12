using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaWebApplication.Models;
using FundaWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundaWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundaController : ControllerBase
    {
        private readonly IFundaService _fundaService;

        public FundaController(IFundaService fundaService)
        {
            _fundaService = fundaService;
        }

        [HttpGet("top10")]
        public async Task<ActionResult<IEnumerable<ResultByAgencyModel>>> Get()
        {
            try
            {
                // Retrieve a list of agencies with their properties
                // Node: These agencies already come ordered by number of properties desc
                var agencies = await _fundaService.GetAgenciesWithMostPropertiesForSale("/amsterdam/");
                // Retrieve the top 10
                var top10Agencies = agencies.Take(10).ToList();
                // Return success
                return Ok(top10Agencies);
            }
            catch
            {
                // In case of any error, return 500 and inform caller about 
                return StatusCode(500, new  { error = "Unable to retrieve top 10 agents at the moment. Try again later."});
            }
        }
    }
}