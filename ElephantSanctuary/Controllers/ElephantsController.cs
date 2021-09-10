namespace ElephantSanctuary.Controllers
{
    using ElephantSanctuary.Business;
    using ElephantSanctuary.Models.View;
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
        public IEnumerable<Elephant> AllElephants()
        {
            return this.elephantManagement.GetAllElephants();
        }

        [HttpGet("{name}")]
        public ActionResult<Elephant> GetElephantByName(string name)
        {
            var response = this.elephantManagement.GetElephantByName(name);
            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Elephant>> AddElephant(Elephant elephant)
        {
            var response = this.elephantManagement.AddElephant(elephant);
            if (response == null)
            {
                return Problem();
            }
            return Ok();
        }
    }
}