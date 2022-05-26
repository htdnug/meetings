using SpecificationPattern.Library.Framework;

namespace SpecificationPattern.Library.Specifications
{
    public class RushOrderSpecification : Specification<Order>
    {
        private readonly DomesticOrderSpecification domesticOrderSpecification;

        private readonly HighValueOrderSpecification highValueSpecification;

        private readonly HazardousMaterialSpecification hazardousSpecification;

        private readonly IsInStockSpecification inStockSpecification;

        public RushOrderSpecification()
        {
            this.domesticOrderSpecification = new DomesticOrderSpecification();
            this.highValueSpecification = new HighValueOrderSpecification();
            this.hazardousSpecification = new HazardousMaterialSpecification();
            this.inStockSpecification = new IsInStockSpecification();
        }

        public override bool IsSatisfiedBy(Order candidate)
        {
            return this.domesticOrderSpecification
                .And(this.highValueSpecification)
                .And(this.inStockSpecification)
                .And(this.hazardousSpecification.Not())
                .IsSatisfiedBy(candidate);
        }
    }
}
