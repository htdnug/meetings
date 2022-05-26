using System;
using System.Collections.Generic;

namespace ClassLibraryCS.Refactored.DataAccess.EntityFramework
{
    public class CompanyRepository : ICompanyRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> SelectAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Company company)
        {
            throw new NotImplementedException();
        }

        public Company SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
