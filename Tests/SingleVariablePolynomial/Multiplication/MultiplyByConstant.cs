using Core;
using Xunit;

namespace Tests.SingleVariablePolynomial
{
   public class MultiplyByConstant
   {
      [Fact]
      public void MultiplyByConstant_PolynomialHasNoConstantTerm()
      {
         int co2 = 5, co4 = 2;

         var p = new Polynomial(new Term(co4, 4),
                                new Term(co2, 2));

         var constant = 3;
         var result = p * constant;

         Assert.Equal(2, result.TermsCount);
         Assert.Equal(co4 * constant, result[4].Coefficient);
         Assert.Equal(co2 * constant, result[2].Coefficient);
      }

      [Fact]
      public void MultiplyByConstant_PolynomialHasConstantTerm()
      {
         int co0 = 3, co2 = 5, co4 = 2;

         var p = new Polynomial(new Term(co4, 4),
                                new Term(co2, 2),
                                new Term(co0, 0));

         var constant = 3;
         var result = p * constant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(co4 * constant, result[4].Coefficient);
         Assert.Equal(co2 * constant, result[2].Coefficient);
         Assert.Equal(co0 * constant, result[0].Coefficient);
      }

      [Fact]
      public void MultiplyByZero()
      {
         int co0 = 3, co2 = 5, co4 = 2;

         var p = new Polynomial(new Term(co4, 4),
                                new Term(co2, 2),
                                new Term(co0, 0));

         var constant = 0;
         var result = p * constant;

         Assert.Equal(0, result.TermsCount);
         Assert.Equal(0, result.Degree);
      }
   }
}