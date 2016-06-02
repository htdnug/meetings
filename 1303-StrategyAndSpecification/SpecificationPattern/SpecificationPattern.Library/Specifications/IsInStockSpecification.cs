using System.Linq;
using SpecificationPattern.Library.Framework;

namespace SpecificationPattern.Library.Specifications
{
    public class IsInStockSpecification : Specification<Order>
    {
        public override bool IsSatisfiedBy(Order candidate)
        {
            return !candidate.OrderItems.Any(item => !item.IsInStock);
        }
    }
}
