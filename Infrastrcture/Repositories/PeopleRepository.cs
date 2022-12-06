using Microsoft.EntityFrameworkCore;
using MyEFCore.Infrastrcture.Context;
using MyEFCore.Infrastrcture.Interface.Repositories;
using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Repositories
{
    public class PeopleRepository : EntityFrameworkRepository<People, MyEFCoreContext>, IPeopleRepository
    {
        private IHttpContextAccessor httpContextAccessor;
        public PeopleRepository(MyEFCoreContext myContext, IHttpContextAccessor httpContextAccessor) : base(myContext)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void SavePeople(People people)
        {
            Context.PeopleRepositories.Add(people);
            Context.SaveChanges();
        }
        public void DeletePeople(People people)
        {
            Context.PeopleRepositories.Remove(people);
            Context.SaveChanges();
        }
        public void UpdatePeople(People people)
        {
            Context.PeopleRepositories.Update(people);
            Context.SaveChanges();
        }
        public async Task<People> GetPeopleById(long id)
        {
            //return await Context.PeopleRepositories.FindAsync(id);
            return Context.PeopleRepositories?.FirstOrDefault(x => x.Id == id);
        }
    }
}
