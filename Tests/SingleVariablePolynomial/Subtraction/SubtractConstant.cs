using Core;
using Xunit;

namespace Tests.SingleVariablePolynomial
{
   public class SubtractConstant
   {
      [Fact]
      public void SubtractConstant_PolynomialHasNoConstantTerm()
      {
         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var constant = 21;
         var expected = -1 * constant;

         var result = p - constant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(expected, result[0].Coefficient);
      }

      [Fact]
      public void SubtractConstant_PolynomialHasGreaterConstant()
      {
         var oldConstant = 18;

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2),
                                new Term(oldConstant, 0));

         var newConstant = 4;
         var result = p - newConstant;

         var expectedCo = oldConstant - newConstant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(expectedCo, result[0].Coefficient);
      }

      [Fact]
      public void SubtractConstant_PolynomialHasLesserConstant()
      {
         var oldConstant = 2;

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2),
                                new Term(oldConstant, 0));

         var newConstant = 4;
         var result = p - newConstant;

         var expectedCo = oldConstant - newConstant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(expectedCo, result[0].Coefficient);
      }

      [Fact]
      public void SubtractConstant_PolynomialHasEqualConstant()
      {
         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2),
                                new Term(4, 0));

         var newConstant = 4;
         var result = p - newConstant;

         Assert.Equal(2, result.TermsCount);
         Assert.Equal(0, result[0].Coefficient);
      }
   }
}