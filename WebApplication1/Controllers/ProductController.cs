using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            
            return Ok();
        }
    }
}
