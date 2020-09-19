using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace tiangong.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger Logger;
        public ValuesController(ILogger<ValuesController> logger)
        {
            Logger = logger;
        }

        
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            Logger.LogInformation("call index");
            return Ok(new List<string>() { "1", "2" });
        }
    }
}
