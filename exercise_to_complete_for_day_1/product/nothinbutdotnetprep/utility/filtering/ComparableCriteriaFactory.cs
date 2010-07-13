using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> basic_factory;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor) : this(accessor,
                                                                                           new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor))
        {
        }

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> basic_factory)
        {
            this.accessor = accessor;
            this.basic_factory = basic_factory;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new GreaterThan<PropertyType>(value));
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return basic_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return basic_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return basic_factory.not_equal_to(value);
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new IsBetween<PropertyType>(start, end));
        }
    }
}