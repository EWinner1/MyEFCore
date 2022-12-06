using MyEFCore.Infrastrcture.Interface.Repositories;

namespace MyEFCore.Infrastrcture.Interface.UnitOfWork
{
    public interface IPeopleUnitOfWork
    {
        IPeopleRepository PeopleRepository { get; }
    }
}
