using BookStoresWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoresWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        [HttpGet(Name = "GetAuthors")]
        public IEnumerable<Author> Get()
        {
            BookStoresDbContext context = new();
            return context.Authors.ToList();
        }
    }
}