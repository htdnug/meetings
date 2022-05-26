namespace SpecificationPattern.Library.Framework
{
    public interface ISpecification<TEntity>
    {
        ISpecification<TEntity> And(ISpecification<TEntity> specification);

        bool IsSatisfiedBy(TEntity candidate);

        ISpecification<TEntity> Not();

        ISpecification<TEntity> Or(ISpecification<TEntity> specification);
    }
}
