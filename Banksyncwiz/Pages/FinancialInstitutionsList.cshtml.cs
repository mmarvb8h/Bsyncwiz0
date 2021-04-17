using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Banksyncwiz.Pages
{
    public class FinancialInstitutionsListModel : PageModel
    {
        private readonly ILogger<FinancialInstitutionsListModel> _logger;

        public FinancialInstitutionsListModel(ILogger<FinancialInstitutionsListModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}

