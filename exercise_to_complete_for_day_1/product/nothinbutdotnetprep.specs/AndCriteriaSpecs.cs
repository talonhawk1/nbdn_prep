 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetprep.utility.filtering;
using Rhino.Mocks;

namespace nothinbutdotnetprep.specs
 {   
     public class AndCriteriaSpecs
     {
         public abstract class concern : Observes<Criteria<int>,
                                             AndCriteria<int>>
         {
        
         }

         [Subject(typeof(AndCriteria<int>))]
         public class when_combined : concern
         {

             Establish c = () =>
             {
                 var left = an<Criteria<int>>();
                 left.Stub(x => x.is_satisfied_by(Arg<int>.Is.Anything)).Return(true);

                 var right = an<Criteria<int>>();
                 right.Stub(x => x.is_satisfied_by(Arg<int>.Is.Anything)).Return(true);

                 create_sut_using(() => new AndCriteria<int>(left, right));
             };

             Because b = () =>
                 result = sut.is_satisfied_by(23);


             It should_be_true_if_both_are_satisfied = () =>
                 result.ShouldBeTrue();

             static bool result;
                 
         }
     }
 }
