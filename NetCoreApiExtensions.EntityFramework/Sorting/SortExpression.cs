using System;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.EntityFramework
{
    public class SortExpression<T> : Tuple<Expression<Func<T, object>>, SortDirection>
    {
        public Expression<Func<T, object>> KeySelector => Item1;
        public SortDirection SortDirection => Item2;

        public SortExpression(Expression<Func<T, object>> expression, SortDirection sortDirection) : base(expression, sortDirection)
        {

        }
    }
}