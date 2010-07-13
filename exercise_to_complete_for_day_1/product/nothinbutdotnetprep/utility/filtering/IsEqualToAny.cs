using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsEqualToAny<T> : Criteria<T>
    {
        IList<T> values;

        public IsEqualToAny(params T[] items)
        {
            this.values = new List<T>(items);
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}