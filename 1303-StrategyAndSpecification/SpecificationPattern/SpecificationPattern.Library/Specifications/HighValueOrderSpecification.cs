using SpecificationPattern.Library.Framework;

namespace SpecificationPattern.Library.Specifications
{
    public class HighValueOrderSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return candidate.OrderTotal > 100;
        }
    }
}
