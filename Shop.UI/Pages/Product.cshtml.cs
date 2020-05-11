using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void OnGet(string name)
        {
            Product = new GetProduct(_ctx).Do(name.Replace("-"," "));
        }
    }
}
