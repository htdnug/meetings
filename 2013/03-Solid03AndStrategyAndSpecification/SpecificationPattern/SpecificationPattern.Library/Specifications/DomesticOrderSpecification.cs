using SpecificationPattern.Library.Framework;

namespace SpecificationPattern.Library.Specifications
{
    public class DomesticOrderSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return candidate.ShippingAddress.Country == "USA";
        }
    }
}
