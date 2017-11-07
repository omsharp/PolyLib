using Xunit;
using Core;

namespace Tests.SingleVariablePolynomial
{
   public class QueryTerms
   {
      [Fact]
      public void GetTermOfDegree_TermIsFound()
      {
         var p = new Polynomial(new Term(2, 4),  //! 2x^4
                                new Term(7, 2));  //! 7x^2


         var t = p[2];

         Assert.Equal(7, t.Coefficient);
         Assert.Equal(2, t.Degree);
      }

      [Fact]
      public void GetTermOfDegree_CoefficientOfZero()
      {
         var p = new Polynomial(new Term(2, 4),  //! 2x^4
                                new Term(7, 2));  //! 7x^2

         var d = 3;
         var t = p[d];

         Assert.Equal(0, t.Coefficient);
         Assert.Equal(d, t.Degree);
      }

      [Fact]
      public void GetTermOfDegree_DegreeIsOutOfRange()
      {
         var p = new Polynomial(new Term(2, 3),  //! 2x^3
                                new Term(7, 2));  //! 7x^2

         Assert.Throws<DegreeOutOfRangeException>(() => p[5]);
      }
   }
}
