using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public Test ProductTest { get; set; }
        public class Test
        {
            public string Id { get; set; }
        }
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
            var current_id = HttpContext.Session.GetString("id");
            HttpContext.Session.SetString("id", ProductTest.Id);
            return RedirectToPage("Index");
        }
    }
}
