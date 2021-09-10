namespace ElephantSanctuary.Controllers
{
    using ElephantSanctuary.Business;
    using ElephantSanctuary.Models.View;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/dogs")]
    public class DogsController : ControllerBase
    {
        private readonly IDogManagement dogManagement;

        public DogsController(IDogManagement dogManagement)
        {
            this.dogManagement = dogManagement;
        }

        [HttpGet]
        public IEnumerable<Dog> AllDogs()
        {
            return this.dogManagement.GetAllDogs();
        }

        [HttpGet("{name}")]
        public ActionResult<Dog> GetDogByName(string name)
        {
            var response = this.dogManagement.GetDogByName(name);
            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Dog>> AddDog(Dog dog)
        {
            var response = this.dogManagement.AddDog(dog);
            if (response == null)
            {
                return Problem();
            }
            return Ok();
        }
    }
}