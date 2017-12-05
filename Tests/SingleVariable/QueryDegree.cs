using Xunit;
using PolyLib.Core;

namespace Tests.SingleVariable
{
   public class QueryDegree
   {
      [Fact]
      public void PolyWithNoTerms_ZeroDegree()
      {
         var p = new Polynomial();
         Assert.Equal(0, p.Degree);
      }

      [Fact]
      public void PolyWithOnlyConstantTerm_ZeroDegree()
      {
         var p = new Polynomial(new Term(2, 0));
         Assert.Equal(0, p.Degree);
      }

      [Fact]
      public void PolyWithTerms_NthDegree()
      {
         var n = 4;
         var p = new Polynomial(new Term(2, n),
                                new Term(5, n-1));

         Assert.Equal(n, p.Degree);
      }
   }
}
