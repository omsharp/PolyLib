using PolyLib.Core;
using Xunit;

namespace Tests.MultiVariable
{
   public class QueryTerms
   {
      [Fact]
      public void QueryTerms_MultipleTermsWithSameDegree()
      {
         var e1 = 2;
         var e2 = 3;
         
         var p = new Polynomial(
            new Term[]
            {
               new Term(2, new Variable('x', e1),
                           new Variable('y', e2)),

               new Term(4, new Variable('x', e2),
                           new Variable('y', e1)),

               new Term(7, new Variable('x', 2)),
            }
         );

         var terms = p.TermsOfDegree(e1 + e2);
         Assert.Equal(2, terms.Length);
      }
   }
}
