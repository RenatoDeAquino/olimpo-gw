using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Coffe from Tomezera", "Coffee from pedrin", "Coffe from rachel","Coffee from gabriel"
        };

        [HttpGet]
        public IEnumerable<Coffee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Coffee
            {
                Name = "API COFFEE",
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
