using System.Collections.Generic;

namespace ClassLibraryCS.Refactored.DataAccess
{
    public interface ICompanyRepository
    {
        void Delete(int id);

        IEnumerable<Company> SelectAll();

        void Save(Company company);

        Company SelectById(int id);
    }
}
