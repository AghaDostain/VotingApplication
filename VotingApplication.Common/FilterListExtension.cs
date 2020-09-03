using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VotingApplication.Common
{
    public static class FilterListExtension
    {
        public static Expression<Func<K, bool>> BuildFiltersLambda<K>(this IEnumerable<FilterInfo> items)
        {
            var expression = Expression.Parameter(typeof(K), "x");
            if (items != null)
            {
                items = items.Where(item => item != null);
                if (items.Any())
                {
                    var body = items.Select(item => TypeHelper.MakePredicate(expression, item.Field, item.Op, item.Value)).Aggregate(Expression.AndAlso);
                    return Expression.Lambda<Func<K, bool>>(body, expression);
                }
            }
            return null;
        }
    }
}
