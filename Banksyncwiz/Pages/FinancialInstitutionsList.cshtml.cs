using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Banksyncwiz.Config;
using Banksyncwiz.Services;

namespace Banksyncwiz.Pages
{
    public class FinancialInstitutionsListModel : PageModel
    {
        private readonly ILogger<FinancialInstitutionsListModel> _logger;
        private readonly HttpClient _httpclient;

        public FinancialInstitutionsListModel(ILogger<FinancialInstitutionsListModel> logger)
        {
            _logger = logger;
            _httpclient = GetMyHttp.client;
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
            public string? image { get; set; }
            public string? name { get; set; }
        }

        public async Task<JsonResult> OnGetInstitutions()
        {
            Console.Out.WriteLine("In OnGetInstitutionList().");

            var result = await new GetInstitutionList().Begin("Wells", _httpclient);

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
