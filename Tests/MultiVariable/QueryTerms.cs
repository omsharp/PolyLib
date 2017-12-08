using PolyLib.Core;
using System.Linq;
using Xunit;

namespace Tests.MultiVariable
{
   public class QueryTerms
   {
      [Fact]
      public void QueryTerms_MultiTerms()
      {
         var xe = 2;
         var ye = 3;
         var c1 = 2;
         var c2 = 4;

         var p = new Polynomial(
            new Term[]
            {
               new Term(c1, new Variable('x', xe),
                            new Variable('y', ye)),

               new Term(c2, new Variable('x', xe),
                            new Variable('y', ye)),

               new Term(7, new Variable('x', 2)),
            }
         );

         Assert.Equal(c1 + c2, p.TermsOfDegree(xe + ye)[0].Coefficient);
         Assert.Equal(7, p.TermsOfDegree(2)[0].Coefficient);
      }

      [Fact]
      public void QueryTerms_MultipleTermsWithSameDegree()
      {
         var e1 = 2;
         var e2 = 3;
         var c1 = 2;
         var c2 = 4;

         var p = new Polynomial(
            new Term[]
            {
               new Term(c1, new Variable('x', e1),
                           new Variable('y', e2)),

               new Term(c2, new Variable('x', e2),
                           new Variable('y', e1)),
            }
         );

         var terms = p.TermsOfDegree(e1 + e2);
         Assert.True(terms.Any(t => t.Coefficient == c1));
         Assert.True(terms.Any(t => t.Coefficient == c2));
      }
   }
}
