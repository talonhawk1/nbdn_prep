using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsBetween<T> : Criteria<T> where T:IComparable<T>
    {
        T start;
        T end;

        public IsBetween(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(start) >= 0 &&
                item.CompareTo(end) <= 0;
        }
    }
}