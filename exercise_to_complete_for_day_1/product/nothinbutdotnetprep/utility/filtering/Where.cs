using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{

    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter,PropertyType> has_a<PropertyType>(Func<ItemToFilter,PropertyType> accessor)
        {
            throw new NotImplementedException();
        }
    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public Criteria<ItemToFilter> equal_to(ProductionStudio pixar)
        {
            throw new NotImplementedException();
        }
    }
}