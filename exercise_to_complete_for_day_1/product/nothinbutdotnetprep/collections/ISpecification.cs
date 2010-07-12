namespace nothinbutdotnetprep.collections
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}