using System.Collections.Generic;
using System.Linq;
using SpecificationPattern.Library.Framework;
using SpecificationPattern.Library.Specifications;

namespace SpecificationPattern.Library
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new List<Product>();
        }

        public virtual Address ShippingAddress { get; set; }
        
        public int OrderTotal { get; set; }

        public IList<Product> OrderItems { get; set; }

        public bool IsRush
        {
            get
            {
                #region Before Specificaton

                //if (this.ShippingAddress.Country == "USA"
                //    && this.OrderTotal > 100
                //    && !OrderItems.Any(item => !item.IsInStock)
                //    && !OrderItems.Any(item => item.ContainsHazardousMaterial))
                //{
                //    return true;
                //}

                //return false; 

                #endregion

                #region After Specification

                ISpecification<Order> specification = new RushOrderSpecification();
                return specification.IsSatisfiedBy(this); 
                
                #endregion
            }
        }
    }
}
