using ClassLibraryCS.Refactored.Business;
using ClassLibraryCS.Refactored.DataAccess;
using ClassLibraryCS.Refactored.DataAccess.SqlCe;

namespace ClassLibraryCS.Refactored.Presentation
{
    public class CompanyPresenter
    {
        private readonly ICompanyView view;

        private readonly ICompanyRepository repository;

        public CompanyPresenter(ICompanyView viewToUse)
        {
            this.view = viewToUse;
            this.repository = new CompanyRepository();
        }

        public void Add()
        {
            var company = new Company
            {
                Name = this.view.NameField,
                PhoneNumber = this.view.PhoneNumberField,
                StreetLine1 = this.view.StreetLine01Field,
                StreetLine2 = this.view.StreetLine02Field,
                City = this.view.CityField,
                State = this.view.StateField,
                ZipCode = this.view.ZipCodeField
            };

            ICompanyService service = new CompanyService(this.repository);
            service.Add(company);

            this.Clear();
            this.List();
        }

        public void Clear()
        {
            this.view.NameField = string.Empty;
            this.view.PhoneNumberField = string.Empty;
            this.view.StreetLine01Field = string.Empty;
            this.view.StreetLine02Field = string.Empty;
            this.view.CityField = string.Empty;
            this.view.StateField = string.Empty;
            this.view.ZipCodeField = string.Empty;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
            this.Clear();
            this.List();
        }

        public void List()
        {
            this.view.CompanyListField = this.repository.SelectAll();
        }

        public void Select(int id)
        {
            Company company = this.repository.SelectById(id);

            this.view.NameField = company.Name;
            this.view.PhoneNumberField = company.PhoneNumber;
            this.view.StreetLine01Field = company.StreetLine1;
            this.view.StreetLine02Field = company.StreetLine2;
            this.view.CityField = company.City;
            this.view.StateField = company.State;
            this.view.ZipCodeField = company.ZipCode;
        }

        public void Update(int id)
        {
            Company company = this.repository.SelectById(id);

            company.Name = this.view.NameField;
            company.PhoneNumber = this.view.PhoneNumberField;
            company.StreetLine1 = this.view.StreetLine01Field;
            company.StreetLine2 = this.view.StreetLine02Field;
            company.City = this.view.CityField;
            company.State = this.view.StateField;
            company.ZipCode = this.view.ZipCodeField;

            this.repository.Save(company);
            this.List();
            this.Clear();
        }
    }
}
