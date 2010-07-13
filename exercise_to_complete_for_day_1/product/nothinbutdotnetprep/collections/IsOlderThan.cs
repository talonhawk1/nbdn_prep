using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class IsOlderThan : Criteria<Person>
    {
        int age;

        public IsOlderThan(int age)
        {
            this.age = age;
        }

        public bool is_satisfied_by(Person item)
        {
            return item.age > age;
        }
    }
}