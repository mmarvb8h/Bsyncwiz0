using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Banksyncwiz.Pages
{
    public class AttachExistingAccountModel : PageModel
    {
        private readonly ILogger<AttachExistingAccountModel> _logger;

        public AttachExistingAccountModel(ILogger<AttachExistingAccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
