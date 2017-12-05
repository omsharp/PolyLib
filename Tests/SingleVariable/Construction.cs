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
   }
}
