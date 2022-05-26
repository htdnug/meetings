using System.Collections.Generic;

namespace ClassLibraryCS.Refactored.Presentation
{
    public interface ICompanyView
    {
        IEnumerable<Company> CompanyListField { set; } 

        string NameField { get; set; }

        string PhoneNumberField { get; set; }

        string StreetLine02Field { get; set; }

        string StreetLine01Field { get; set; }

        string CityField { get; set; }

        string StateField { get; set; }

        string ZipCodeField { get; set; }
    }
}
