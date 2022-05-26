using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryCS.Refactored.DataAccess.InMemory
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository()
        {
            this.EntityList = new Dictionary<int, Company>();
        }

        public Dictionary<int, Company> EntityList { get; private set; }

        public void Delete(int id)
        {
            Company company = this.SelectById(id);
            if (company != null)
            {
                company.IsDeleted = true;
            }
        }

        public IEnumerable<Company> SelectAll()
        {
            return this.EntityList.Values.Where(x => !x.IsDeleted).ToList();
        }

        public void Save(Company company)
        {
            if (company.Id > 0)
            {
                this.EntityList[company.Id] = company;
            }
            else
            {
                int id = this.GetId();
                company.Id = id;
                this.EntityList.Add(id, company);
            }
        }

        public Company SelectById(int id)
        {
            return this.EntityList.ContainsKey(id) 
                ? this.EntityList[id] 
                : null;
        }

        private int GetId()
        {
            if (!this.EntityList.Any())
            {
                return 1;
            }

            int max = this.EntityList.Max(x => x.Key);
            return max + 1;
        }
    }
}
