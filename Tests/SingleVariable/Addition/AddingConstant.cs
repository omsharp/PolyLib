﻿using PolyLib.Core;
using Xunit;

namespace Tests.SingleVariable
{
   public class AddingConstant
   {
      [Fact]
      public void AddPositiveConstant_PolynomialHasNoConstantTerm()
      {
         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2));

         var constant = 21;
         var result = p + constant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(constant, result.TermsOfDegree(0)[0].Coefficient);
      }

      [Fact]
      public void AddPositiveConstant_PolynomialHasConstantTerm()
      {
         var oldConstant = 18;

         var p = new Polynomial(new Term(2, 4),
                                new Term(5, 2),
                                new Term(oldConstant, 0));

         var newConstant = 4;
         var result = p + newConstant;
         var expectedCo = oldConstant + newConstant;

         Assert.Equal(3, result.TermsCount);
         Assert.Equal(expectedCo, result.TermsOfDegree(0)[0].Coefficient);
      }
   }
}