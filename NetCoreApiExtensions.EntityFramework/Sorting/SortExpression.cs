using System;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.EntityFramework
{
    public class SortExpression<T, TKey>
    {
        public Expression<Func<T, TKey>> KeySelector { get; set; }
        public SortDirection SortDirection { get; set; }
        
        public SortExpression()
        {

        }

        public SortExpression(Expression<Func<T, TKey>> keySelector, SortDirection sortDirection)
        {
            KeySelector = keySelector;
            SortDirection = sortDirection;
        }

    }
}