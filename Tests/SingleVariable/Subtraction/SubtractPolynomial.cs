using PolyLib.Core;
using Xunit;

namespace Tests.SingleVariable
{
   public class SubtractPolynomial
   {
      [Fact]
      public void SubtractMonomial_DegreeAlreadyExists()
      {
         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var m = new Polynomial(new Term(9, 4));

         var result = p - m;

         Assert.Equal(2, result.TermsCount);
         Assert.Equal(-7, result.TermsOfDegree(4)[0].Coefficient);
      }

      [Fact]
      public void SubtractMonomial_DegreeDoesntExists()
      {
         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var m = new Polynomial(new Term(9, 3));

         var result = p - m;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(-9, result.TermsOfDegree(3)[0].Coefficient);
      }

      [Fact]
      public void SubtractPolynomia_WithNewDegrees()
      {
         int co0 = 4, co1 = 7, co2 = 6, co3 = 2, co4 = 9;

         var p1 = new Polynomial(new Term(co4, 4),
                                 new Term(co3, 3),
                                 new Term(co2, 2));

         var p2 = new Polynomial(new Term(co1, 1),
                                 new Term(co0, 0));

         var p3 = p1 - p2;

         Assert.Equal(5, p3.TermsCount);

         Assert.Equal(co4, p3.TermsOfDegree(4)[0].Coefficient);
         Assert.Equal(co3, p3.TermsOfDegree(3)[0].Coefficient);
         Assert.Equal(co2, p3.TermsOfDegree(2)[0].Coefficient);
         Assert.Equal(-co1, p3.TermsOfDegree(1)[0].Coefficient);
         Assert.Equal(-co0, p3.TermsOfDegree(0)[0].Coefficient);
      }

      [Fact]
      public void SubtractPolynomial_WithIntersectedDegrees()
      {
         int co0 = 4, co1 = 7, co3 = 2;
         int p1co2 = 5, p2co2 = 2;
         int p1co4 = 9, p2co4 = 7;

         var p1 = new Polynomial(new Term(p1co4, 4),
                                 new Term(p1co2, 2),
                                 new Term(co1, 1));

         var p2 = new Polynomial(new Term(p2co4, 4),
                                 new Term(co3, 3),
                                 new Term(p2co2, 2),
                                 new Term(co0, 0));

         var p3 = p1 - p2;

         Assert.Equal(5, p3.TermsCount);

         Assert.Equal(-co0, p3.TermsOfDegree(0)[0].Coefficient);
         Assert.Equal(co1, p3.TermsOfDegree(1)[0].Coefficient);
         Assert.Equal(p1co2 - p2co2, p3.TermsOfDegree(2)[0].Coefficient);
         Assert.Equal(-co3, p3.TermsOfDegree(3)[0].Coefficient);
         Assert.Equal(p1co4 - p2co4, p3.TermsOfDegree(4)[0].Coefficient);
      }
   }
}