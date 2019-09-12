using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundaWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundaWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFundaService _fundaService;

        public IndexModel(IFundaService fundaService)
        {
            _fundaService = fundaService;
        }

        public async Task OnGet()
        {
            
        }
    }
}
