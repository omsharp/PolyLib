
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
         var xe = 2;
         var ye = 3;
         var c1 = 2;
         var c2 = 4;

         var p = new Polynomial(
            new Term[]
            {
               new Term(2, new Variable('x', xe),
                           new Variable('y', ye)),

               new Term(4, new Variable('x', xe),
                           new Variable('y', ye)),

               new Term(7, new Variable('x', 2)),
            }
         );

         Assert.Equal(2, p.TermsCount);
         Assert.Equal(c1 + c2, p[xe + ye].Coefficient);
      }
   }
}
