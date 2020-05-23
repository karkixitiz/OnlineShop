using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Database;

namespace Shop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private IHostingEnvironment _env;
        public CustomerInformationModel(IHostingEnvironment env)
        {
            _env = env;
        }
        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }
        public IActionResult OnGet()
        {
            //Get Cart
            var information = new GetCustomerInformation(HttpContext.Session).Do();
            if (information == null)
            {
                if(_env.IsDevelopment())
                {
                    CustomerInformation = new AddCustomerInformation.Request
                    {
                        FirstName = "A",
                        LastName = "A",
                        Email = "A@a.com",
                        PhoneNumber = "11",
                        Address1 = "A",
                        Address2 = "A",
                        City = "A",
                        PostCode = "A",
                    };
                }   
                return Page();
            }
            else
            {
                return RedirectToPage("Checkout/Payment");
            }
            //If cart exists go to payment
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Post Cart
            new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);
            return RedirectToPage("/Checkout/Payment");
        }
    }
}
