using System.Collections.Generic;
using System.Linq;
using WebApplication.Models.Criteria;
using WebApplication.Models.Data;
using WebApplication.Models.Entities;
using WebApplication.Models.Extensions;

namespace WebApplication.Models.Business
{
    public class CompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repositoryToUse)
        {
            this.repository = repositoryToUse;
        }

        public void Add(Company company)
        {
            this.repository.Add(company);
        }

        public int GetByFilterCount(CompanyCriteria criteria)
        {
            return this.BuildFilterQuery(criteria).Count();
        }

        public virtual IEnumerable<Company> GetByFilter(CompanyCriteria criteria)
        {
            var query = this.BuildFilterQuery(criteria);
            return query
                .OrderBy(x => x.Name)
                .Skip(criteria.RowsToSkip)
                .Take(criteria.MaximumRows)
                .ToArray();
        }

        public Company GetById(int id)
        {
            return this.repository.GetById(id);
        }

        private IQueryable<Company> BuildFilterQuery(CompanyCriteria criteria)
        {
            var query = this.repository.GetAll()
                .Where(x => !x.IsDeleted)
                .WhereIf(!string.IsNullOrWhiteSpace(criteria.NameSearch), x => x.Name == criteria.NameSearch);
            //if (!string.IsNullOrWhiteSpace(criteria.NameSearch))
            //{
            //    query = query.Where(x => x.Name == criteria.NameSearch);
            //}
            return query;
        }
    }
}