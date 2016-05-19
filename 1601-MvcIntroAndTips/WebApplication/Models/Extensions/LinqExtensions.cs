using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplication.Models.Extensions
{
    /// <summary>Extension methods for LINQ.</summary>
    public static class LinqExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return condition ? source.Where(predicate) : source;
        }
    }
}