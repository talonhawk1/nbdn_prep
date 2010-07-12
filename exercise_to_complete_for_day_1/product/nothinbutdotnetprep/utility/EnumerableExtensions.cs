using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Predicate<T> criteria)
        {
            foreach (var item in items) if (criteria(item))  yield return item;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,Criteria<T> criteria)
        {
            return all_items_matching(items, criteria.is_satisfied_by);
        }
    }
}