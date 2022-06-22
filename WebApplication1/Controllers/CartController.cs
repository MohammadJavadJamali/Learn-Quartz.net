using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public IActionResult Create(Cart cart)
        {
            _dataContext.Carts.Add(cart);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
