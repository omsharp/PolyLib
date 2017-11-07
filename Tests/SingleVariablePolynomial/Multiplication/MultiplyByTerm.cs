using Core;
using Xunit;

namespace Tests.SingleVariablePolynomial
{
   public class MultiplybyTerm
   {
      [Fact]
      public void MultiplyByTerm()
      {
         var t = new Term(3, 4);

         int deg1 = 4, deg2 = 2;
         int co1 = 2, co2 = 5;

         var p = new Polynomial(new Term(co1, deg1),
                                new Term(co2, deg2));

         var result = p * t;

         var expectedDeg1 = deg1 + t.Degree;
         var expectedDeg2 = deg2 + t.Degree;

         var expectedCo1 = co1 * t.Coefficient;
         var expectedCo2 = co2 * t.Coefficient;

         Assert.Equal(2, result.TermsCount);

         Assert.Equal(expectedCo1, result[expectedDeg1].Coefficient);
         Assert.Equal(expectedCo2, result[expectedDeg2].Coefficient);
      }

      [Fact]
      public void MultiplyByZeroTerm()
      {
         var t = new Term(0, 3);

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var result = p * t;

         Assert.Equal(0, result.TermsCount);
         Assert.Equal(0, result.Degree);
      }
   }
}