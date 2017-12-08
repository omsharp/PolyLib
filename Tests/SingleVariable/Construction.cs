using PolyLib.Core;
using Xunit;

namespace Tests.SingleVariable
{
   public class Construction
   {
      [Fact]
      public void CreatePolynomial()
      {
         var p = new Polynomial(new Term(2, 4),    //! 2x^4
                                new Term(7, 2),    //! 7x^2
                                new Term(23, 1),   //! 23x
                                new Term(-8, 0));  //! -8;

         Assert.Equal(4, p.TermsCount);
      }

      [Fact]
      public void CreatePolynomial_Simplify()
      {
         var c1 = 2;
         var c2 = 7;
         var p = new Polynomial(new Term(c1, 2),    //! 2x^2
                                new Term(c2, 2),    //! 7x^2
                                new Term(23, 1),   //! 23x
                                new Term(-8, 0));  //! -8;

         Assert.Equal(3, p.TermsCount);
         Assert.Equal(c1 + c2, p.TermsOfDegree(2)[0].Coefficient);
      }
   }
}
