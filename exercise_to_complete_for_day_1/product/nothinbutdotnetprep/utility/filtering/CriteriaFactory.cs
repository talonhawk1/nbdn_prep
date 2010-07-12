using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => accessor(item).Equals(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}