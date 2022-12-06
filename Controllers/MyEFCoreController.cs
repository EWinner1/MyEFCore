using Microsoft.AspNetCore.Mvc;
using MyEFCore.Infrastrcture.Interface.Repositories;
using MyEFCore.Infrastrcture.Interface.Services;
using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class MyEFCoreController : ControllerBase
    {
        private readonly IPeopleService PeopleService;
        private readonly IPeopleRepository PeopleRepository;

        public MyEFCoreController(
            IPeopleService PeopleService,
            IPeopleRepository PeopleRepository)
        {
            this.PeopleService = PeopleService;
            this.PeopleRepository = PeopleRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(People), 200)]
        public async Task<ActionResult> GetPeopleById(long id)
        {
            return Ok(await PeopleService.GetPeopleById(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(People), 200)]
        public async Task<String> SavePeople([FromBody] People people)
        {
            var saveResult = PeopleService.SavePeople(people);
            return saveResult;
        }
    }
}