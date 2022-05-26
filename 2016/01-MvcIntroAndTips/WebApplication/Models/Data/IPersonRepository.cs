using System.Collections.Generic;
using WebApplication.Models.Entities;

namespace WebApplication.Models.Data
{
    public interface IPersonRepository
    {
        void Add(Person person);

        void Delete(int id);

        IEnumerable<Person> GetAll();

        IEnumerable<Person> GetByCompanyId(int companyId);

        Person GetById(int id);

        void Update(Person person);
    }
}
