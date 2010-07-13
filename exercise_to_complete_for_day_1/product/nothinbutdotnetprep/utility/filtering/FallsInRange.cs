using System;
using nothinbutdotnetprep.utility.range;

namespace nothinbutdotnetprep.utility.filtering
{
    public class FallsInRange<T> : Criteria<T> where T : IComparable<T>
    {
        Range<T> range;

        public FallsInRange(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}