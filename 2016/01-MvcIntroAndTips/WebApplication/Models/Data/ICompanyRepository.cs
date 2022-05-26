using System.Linq;
using WebApplication.Models.Entities;

namespace WebApplication.Models.Data
{
    public interface ICompanyRepository
    {
        void Add(Company company);

        void Delete(int id);

        IQueryable<Company> GetAll();

        Company GetById(int id);

        void Update(Company company);
    }
}
