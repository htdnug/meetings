﻿namespace SpecificationPattern.Library.Framework
{
    public class NotSpecification<TEntity> : Specification<TEntity>
    {
        private readonly ISpecification<TEntity> specification;

        public NotSpecification(ISpecification<TEntity> specificationToUse)
        {
            this.specification = specificationToUse;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !this.specification.IsSatisfiedBy(candidate);
        }
    }
}
