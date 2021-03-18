using System;
using System.Linq.Expressions;
using NetCoreApiExtensions.Shared;
using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.EntityFramework
{
    public class SortExpression<T, TKey>: IListItem<Expression<Func<T, TKey>>, SortDirection>
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

        Expression<Func<T, TKey>> IListItem<Expression<Func<T, TKey>>, SortDirection>.Key => KeySelector;

        SortDirection IListItem<Expression<Func<T, TKey>>, SortDirection>.Value => SortDirection;
    }
}