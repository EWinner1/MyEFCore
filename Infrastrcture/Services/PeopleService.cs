using MyEFCore.Infrastrcture.Interface.Repositories;
using MyEFCore.Infrastrcture.Interface.Services;
using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        public async Task<People> GetPeopleById(long id)
        {
            return await peopleRepository.GetPeopleById(id);
        }

        public String SavePeople(People people)
        {
            try
            {
                peopleRepository.SavePeople(people);
            }
            catch (Exception ex)
            {
                return "Something went wrong..." + "\n" + ex.ToString();
            }
            return "Success";
        }
    }
}
