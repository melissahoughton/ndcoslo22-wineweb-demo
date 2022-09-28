using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JazzJune.Web.Data;
using System.Threading;

namespace JazzJune.Web.Api
{
    public class ProductPost
    {
        private readonly ApplicationDbContext _context;

        public ProductPost(ApplicationDbContext context)
        {
            _context = context;
        }

        [FunctionName("ProductPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "product")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP Post/Products trigger function processed a request.");

            var product = JsonConvert.DeserializeObject<Product>(await new StreamReader(req.Body).ReadToEndAsync());
            log.LogInformation(JsonConvert.SerializeObject(product));

            var entity = await _context.Products.AddAsync(product, CancellationToken.None);
            await _context.SaveChangesAsync(CancellationToken.None);

            return new OkObjectResult(entity.Entity);
        }
    }
}
