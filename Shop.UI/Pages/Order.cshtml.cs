using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Orders;

namespace Shop.UI.Pages
{
    public class OrderModel : PageModel
    {
        public GetOrder.Response Order { get; set; }

        public void OnGet(
            string reference,
            [FromServices] GetOrder getOrder)
        {
            Order = getOrder.Do(reference);
        }
    }
}
