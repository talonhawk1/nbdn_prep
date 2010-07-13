using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetprep.utility.filtering
{
    public interface Criteria<T>
    {
        bool is_satisfied_by(T item);
    }

    public class CombinedCriteria<T> : Criteria<T>
    {
        IList<Criteria<T>> items;

        public CombinedCriteria(IList<Criteria<T>> items)
        {
            this.items = items;
        }

        public bool is_satisfied_by(T item)
        {
            return items.All(x => x.is_satisfied_by(item));
        }
    }
}