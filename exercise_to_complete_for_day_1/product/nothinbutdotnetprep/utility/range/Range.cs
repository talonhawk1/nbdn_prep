using System;

namespace nothinbutdotnetprep.utility.range
{
    public interface Range<T> where T : IComparable<T>
    {
        bool contains(T item);
    }
}