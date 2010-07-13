using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToFilter>
    {
        public static DefaultCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> accessor)
        {
            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor);        
        }

        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            Func<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor);        
        }
    }
}