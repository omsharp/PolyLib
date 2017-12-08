using PolyLib.Core;
using Xunit;

namespace Tests.SingleVariable
{
   public class AddingTerm
   {
      [Fact]
      public void AddTerm_DegreeAlreadyExists()
      {
         var t = new Term(9, 4);

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var result = p + t;

         Assert.Equal(2, result.TermsCount);
         Assert.Equal(11, result.TermsOfDegree(4)[0].Coefficient);
      }

      [Fact]
      public void AddTerm_DegreeDoesntExists()
      {
         var t = new Term(9, 3);

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var result = p + t;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(9, result.TermsOfDegree(3)[0].Coefficient);
      }
   }
}