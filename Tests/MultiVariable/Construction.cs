
using PolyLib.Core;
using Xunit;

namespace Tests.MultiVariable
{
   public class Construction
   {
      [Fact]
      public void CreatePolynomial()
      {
         var p = new Polynomial(
            new Term(2, new Variable('x', 2), new Variable('y', 2)),
            new Term(7, new Variable('x', 2))
            );

         Assert.Equal(2, p.TermsCount);
      }

      [Fact]
      public void CreatePolynomial_Simplify()
      {
         var e1 = 2;
         var e2 = 3;

         var p = new Polynomial(
            new Term(2, new Variable('x', e1), new Variable('y', e2)),
            new Term(2, new Variable('x', e1), new Variable('y', e2)),
            new Term(7, new Variable('x', 2))
            );

         Assert.Equal(2, p.TermsCount);
      }
   }
}
