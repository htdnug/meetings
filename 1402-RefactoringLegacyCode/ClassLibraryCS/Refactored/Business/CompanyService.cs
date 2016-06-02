using ClassLibraryCS.Refactored.DataAccess;

namespace ClassLibraryCS.Refactored.Business
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository repository;

        public CompanyService(ICompanyRepository repositoryToUse)
        {
            this.repository = repositoryToUse;
        }

        public void Add(Company company)
        {
            // validate object for correct data here
            this.repository.Save(company);
        }
    }
}
