namespace ElephantSanctuary.Controllers
{
    using ElephantSanctuary.Business;
    using ElephantSanctuary.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("api")]
    public class ElephantsController : ControllerBase
    {
        private readonly IElephantManagement elephantManagement;

        public ElephantsController(IElephantManagement elephantManagement)
        {
            this.elephantManagement = elephantManagement;
        }

        [HttpGet("[action]")]
        public IEnumerable<Elephant> All()
        {
            return this.elephantManagement.GetAllElephants();
        }
    }
}