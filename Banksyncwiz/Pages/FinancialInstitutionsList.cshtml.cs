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

        public int countx { get; set; }
        public int institutionList { get; set; }

        public void OnGet()
        {
            Console.Out.WriteLine("In FI List Get().");
            this.countx = 2;
        }

        public record myFi
        {
            public string image { get; set; }
            public string name { get; set; }
        }

        public JsonResult OnGetInstitutions()
        {
            Console.Out.WriteLine("In OnGetInstitutionList().");

            List<myFi> fiList = new List<myFi>
            {
                new myFi
                {
                    image = "/favicon.ico",
                    name = "FI Name One"
                },
                new myFi
                {
                    image = "/favicon.ico",
                    name = "FI Name Two"
                },
                new myFi
                {
                    image = "/favicon.ico",
                    name = "FI Name Three"
                },
            };
            return new JsonResult(fiList);
        }

        public void OnPostInstitutions()
        {
            Console.Out.WriteLine("In OnPostInstitutionList().");
        }
    }
}

// Putting vuejs on this page.
// https://limelightmarketing.com/blogs/vue-asp-net-core-razor-pages/
// https://ml-software.ch/posts/using-vuejs-as-a-drop-in-component
// https://markus.oberlehner.net/blog/goodbye-webpack-building-vue-applications-without-webpack/
//
// Info on vuejs for prod.
// This is the message displayed when i'm running current Vue via script tag.
//
// You are running a development build of Vue.
// Make sure to use the production build (*.prod.js) when deploying for production.
