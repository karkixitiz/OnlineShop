using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductAdmin
{
    public class CreateStock
    {
        ApplicationDbContext _ctx;
        public CreateStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Response>Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                ProductId = request.ProductId
            };
          _ctx.Stock.Add(stock);
           _ctx.SaveChangesAsync();
            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty,
            };
        }
        public class Request
        {
            
            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
           
        }
        public class Response
        {

            public string Description { get; set; }
            public int Qty { get; set; }
            public int Id{ get; set; }

        }
    }
}
