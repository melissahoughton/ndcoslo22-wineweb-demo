using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using JazzJune.Web.Data;
using System.Collections.Generic;

namespace JazzJune.Web.Api
{
    public class ProductsGet
    {
        private readonly ApplicationDbContext _context;

        public ProductsGet(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [FunctionName("ProductsGet")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP Get/Products trigger function processed a request.");

            List<Product> products = _context.Products.ToList();

            return new OkObjectResult(products);
        }
    }
}
