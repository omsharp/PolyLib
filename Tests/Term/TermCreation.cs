using Xunit;
using PolyLib.Core;

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

      [Fact]
      public void CreateMultivariableTerm()
      {
         var co = 3;
         var v1 = new Variable('x', 2);
         var v2 = new Variable('y', 7);
         var dg = v1.Exponent + v2.Exponent;

         //! 3(x^2)(y^7)
         var term = new Term(co, v1, v2);
         Assert.Equal(co, term.Coefficient);
         Assert.Equal(dg, term.Degree);
      }

      [Fact]
      public void CreateMultivariableTermWithDegreeZero_EliminateZeroDegreeVariable()
      {
         var co = 3;
         var dg = 7;
         var v1 = new Variable('x', 0);
         var v2 = new Variable('y', dg);

         //! 3(x^0)(y^7) = 3y^7
         var term = new Term(co, v1, v2);
         Assert.Equal(co, term.Coefficient);
         Assert.Equal(dg, term.Degree);
      }
   }
}
