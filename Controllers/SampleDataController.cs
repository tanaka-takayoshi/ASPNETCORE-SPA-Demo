using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.SPADemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASPNETCore.SPADemo.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private ItemContext itemContext;
        private Config config;

        public SampleDataController(ItemContext itemContext, IOptions<Config> config)
        {
            this.itemContext = itemContext;
            this.config = config.Value;
        }

        [HttpGet("[action]")]
        public IEnumerable<Item> TodoItems()
        {
            return itemContext.Items.ToArray();
        }

        [HttpGet("[action]")]
        public Config Config()
        {
            return config;
        }
    }

    public class Config
    {
        public string Env { get; set; }
    }
}
