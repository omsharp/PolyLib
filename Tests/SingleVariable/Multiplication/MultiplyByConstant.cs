﻿using PolyLib.Core;
using Xunit;

namespace Tests.SingleVariable
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
         Assert.Equal(co4 * constant, result.TermsOfDegree(4)[0].Coefficient);
         Assert.Equal(co2 * constant, result.TermsOfDegree(2)[0].Coefficient);
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
         Assert.Equal(co4 * constant, result.TermsOfDegree(4)[0].Coefficient);
         Assert.Equal(co2 * constant, result.TermsOfDegree(2)[0].Coefficient);
         Assert.Equal(co0 * constant, result.TermsOfDegree(0)[0].Coefficient);
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