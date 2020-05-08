using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.ProductAdmin
{
    public class GetProducts
    {
        private ApplicationDbContext _ctx;
        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<ProductViewModel> Do() =>

            _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Value = x.Value,
                Description=x.Description
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
            public string Description { get; set; }

        }
    }
}
