using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Application.Products;
using Shop.Database;
using static Shop.Application.Products.GetProduct;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        public ApplicationDbContext _ctx;
        public ProductModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ProductViewModel Product { get; set; }
        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }
       
        public IActionResult OnGet(string name)
        {
            Product = new GetProduct(_ctx).Do(name.Replace("-"," "));
            if (Product == null)
                return RedirectToPage("Index");
            else
                return Page();
        }
        public IActionResult OnPost()
        {
            new AddToCart(HttpContext.Session).Do(CartViewModel);
            return RedirectToPage("Cart");
        }
    }
}
