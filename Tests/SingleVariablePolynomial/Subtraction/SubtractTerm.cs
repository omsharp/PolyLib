using Core;
using Xunit;

namespace Tests.SingleVariablePolynomial
{
   public class SubtractTerm
   {
      [Fact]
      public void SubtractTerm_DegreeAlreadyExists()
      {
         var t = new Term(9, 4);

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var result = p - t;

         Assert.Equal(2, result.TermsCount);
         Assert.Equal(-7, result[4].Coefficient);
      }

      [Fact]
      public void SubtractTerm_DegreeDoesntExists()
      {
         var t = new Term(9, 3);

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var result = p - t;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(-9, result[3].Coefficient);
      }
   }
}