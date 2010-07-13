using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class GreaterThan<T> : Criteria<T> where T : IComparable<T>
    {
        T start;

        public GreaterThan(T start)
        {
            this.start = start;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}