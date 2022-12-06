using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Interface.Services
{
    public interface IPeopleService
    {
        String SavePeople(People people);
        Task<People> GetPeopleById(long id);
    }
}
