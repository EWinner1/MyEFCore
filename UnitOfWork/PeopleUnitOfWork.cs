using Microsoft.EntityFrameworkCore;
using MyEFCore.Infrastrcture.Context;
using MyEFCore.Infrastrcture.Interface.Repositories;
using MyEFCore.Infrastrcture.Interface.UnitOfWork;

namespace MyEFCore.UnitOfWork
{
    public class PeopleUnitOfWork : MyEFCoreUnitOfWork<MyEFCoreContext>, IPeopleUnitOfWork
    {
        public IPeopleUnitOfWork peopleUnitOfWork;
        public PeopleUnitOfWork(MyEFCoreContext myContext, IPeopleUnitOfWork peopleUnitOfWork) : base(myContext)
        {
            this.peopleUnitOfWork = peopleUnitOfWork;
        }

        public IPeopleRepository PeopleRepository
        {
            get; internal set;
        }
    }
}
