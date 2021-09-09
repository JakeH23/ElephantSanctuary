namespace ElephantSanctuary.Controllers
{
    using ElephantSanctuary.Business;
    using ElephantSanctuary.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/elephants")]
    public class ElephantsController : ControllerBase
    {
        private readonly IElephantManagement elephantManagement;

        public ElephantsController(IElephantManagement elephantManagement)
        {
            this.elephantManagement = elephantManagement;
        }

        [HttpGet]
        public IEnumerable<Elephant> All()
        {
            return this.elephantManagement.GetAllElephants();
        }

        [HttpGet("{name}")]
        public ActionResult<Elephant> ElephantByName(string name)
        {
            var response = this.elephantManagement.GetElephantByName(name);
            if (response == null)
            {
                return NotFound();
            }

            return response;
        }
    }
}