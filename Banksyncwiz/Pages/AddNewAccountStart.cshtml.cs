using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Banksyncwiz.Pages
{
    public class AddNewAccountStartModel : PageModel
    {
        private readonly ILogger<AddNewAccountStartModel> _logger;

        public AddNewAccountStartModel(ILogger<AddNewAccountStartModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}

// 04-16-2021. Saving html i used to locate radio buttons. Went another way. Took me so long
// to come up with the below i wanted to save it.

// < div class= "text-center" >

//     < label class= "makeblock" style = "width:30%" >< input type = "radio" name = "radgroup1" value = "A" > Add Synced Accounts</label>
//     <label class= "makeblock" style = "width:30%" >< input type = "radio" name = "radgroup1" value = "B" > Add A Manual(non-syned) Account </ label >

//</ div >

// 04-16-2021. The real way i did it... But now i'm using links instead of radio buttons.
//< div class= "text-left" style = "margin:auto; width:26%; min-width:300px;" >

//      < label class= "makeblock" >< input type = "radio" name = "radgroup" value = "A" > Add Synced Accounts</label>
//                  <label class= "makeblock" >< input type = "radio" name = "radgroup" value = "B" > Add A Manual(non-synced) Account </ label >

//                            < label class= "makeblock" >< a asp - area = "" asp - page = "/Index" > Add Synced Accounts</a></label>
//    <label class= "makeblock" >< a asp - area = "" asp - page = "/Index" > Add A Manual(non-synced) Account </ a ></ label >

//</ div >

