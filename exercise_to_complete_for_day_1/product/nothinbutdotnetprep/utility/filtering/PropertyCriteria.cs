using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class PropertyCriteria<ItemToFilter,PropertyType> : Criteria<ItemToFilter>
    {
        Func<ItemToFilter, PropertyType> accessor;
        Criteria<PropertyType> raw_criteria;

        public PropertyCriteria(Func<ItemToFilter, PropertyType> accessor, Criteria<PropertyType> raw_criteria)
        {
            this.accessor = accessor;
            this.raw_criteria = raw_criteria;
        }

        public bool is_satisfied_by(ItemToFilter item)
        {
            return raw_criteria.is_satisfied_by(accessor(item));
        }
    }
}