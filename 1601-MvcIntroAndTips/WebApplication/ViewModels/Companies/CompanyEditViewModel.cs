using WebApplication.Models.Entities;

namespace WebApplication.ViewModels.Companies
{
    public class CompanyEditViewModel
    {
        public CompanyEditViewModel()
            : this(new Company())
        {
        }

        public CompanyEditViewModel(Company entity)
        {
            this.Entity = entity;
        }

        public Company Entity { get; set; }
    }
}