namespace ElephantSanctuary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    [ApiController]
    [Route("api")]
    public class GreetingController : ControllerBase
    {
        [HttpGet("[action]")]
        public string Greeting()
        {
            return $"Hello and welcome to our sanctuary I hope your visit on {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} is an extremely fun and satisfying one!";
        }
    }
}