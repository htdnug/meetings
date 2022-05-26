using System.ComponentModel.DataAnnotations;
using WebApplication.Models.Criteria;
using WebApplication.Models.Entities;

namespace WebApplication.ViewModels.Companies
{
    public class CompanyListViewModel : PagedListViewModelBase<Company>
    {
        public CompanyListViewModel()
        {
        }

        public CompanyListViewModel(CompanyCriteria criteria)
        {
            this.NameSearch = criteria.NameSearch;
        }

        [Display(Name = "Name")]
        public string NameSearch { get; set; }
    }
}