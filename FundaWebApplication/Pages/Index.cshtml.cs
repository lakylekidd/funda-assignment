using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaWebApplication.Models;
using FundaWebApplication.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFundaService _fundaService;
        public List<ResultByAgencyModel> Agencies { get; set; }

        public IndexModel(IFundaService fundaService)
        {
            _fundaService = fundaService;
        }

        public async Task OnGet()
        {
            // Retrieve a list of all agencies including their properties
            var agencies = await _fundaService.GetAgenciesWithMostPropertiesForSale("/amsterdam/");
            Agencies = agencies.Take(10).ToList();
        }
    }
}
