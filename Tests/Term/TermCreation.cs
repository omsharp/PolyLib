using Xunit;
using Core;

namespace Tests.TermTests
{
   public class TermCreation
   {
      [Fact]
      public void CreatePositiveTerm()
      {
         var co = 5;
         var deg = 2;

         //! 5x^2
         var term = new Term(co, deg);
         Assert.Equal(co, term.Coefficient);
         Assert.Equal(deg, term.Degree);
      }


      [Fact]
      public void CreateNegativeTerm()
      {
         var co = -5;
         var deg = 2;

         //! -5x^2
         var term = new Term(co, deg);
         Assert.Equal(co, term.Coefficient);
         Assert.Equal(deg, term.Degree);
      }
   }

}
