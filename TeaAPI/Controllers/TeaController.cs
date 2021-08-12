using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "tea from tomezera", "tea from gabriel", "tea from rachel", "tea from pedrin"
        };

        [HttpGet]
        public IEnumerable<Tea> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Tea
            {
                Name = "TEA API",
                TeaType = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
