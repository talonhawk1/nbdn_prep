namespace nothinbutdotnetprep.utility.filtering
{
    public class OrCriteria<T> : BinaryCriteria<T>
    {
        public OrCriteria(Criteria<T> left_side, Criteria<T> right_side) : base(left_side, right_side)
        {
        }

        public override bool is_satisfied_by(T item)
        {
            return left_side.is_satisfied_by(item) || right_side.is_satisfied_by(item);
        }
    }
}