using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Interface.Repositories
{
    public interface IPeopleRepository
    {
        void SavePeople(People people);
        void DeletePeople(People people);
        void UpdatePeople(People people);
        Task<People> GetPeopleById(long id);
    }
}
