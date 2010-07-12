namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteria<T> : Criteria<T>
    {
        Criteria<T> to_negate;

        public NotCriteria(Criteria<T> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool is_satisfied_by(T item)
        {
            return ! to_negate.is_satisfied_by(item);
        }
    }
}