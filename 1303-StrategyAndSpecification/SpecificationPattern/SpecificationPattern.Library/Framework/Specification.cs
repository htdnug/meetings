namespace SpecificationPattern.Library.Framework
{
    /// <summary>
    /// Abstraction on ISpecification that supplies And, Or and Not.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        /// <summary>
        /// Determines whether the specified candidate is satisfied by TEntity.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>True if is satisfied by the specified candidate; otherwise false.</returns>
        public abstract bool IsSatisfiedBy(TEntity candidate);

        /// <summary>
        /// Ands the specified specification.
        /// </summary>
        /// <param name="specification">The specification</param>
        /// <returns></returns>
        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        } 

        /// <summary>
        /// Nots this instance.
        /// </summary>
        /// <returns></returns>
        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        /// <summary>
        /// Ors the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }
    }
}
