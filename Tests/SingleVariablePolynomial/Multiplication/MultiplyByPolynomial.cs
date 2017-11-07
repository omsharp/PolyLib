﻿using Core;
using Xunit;

namespace Tests.SingleVariablePolynomial
{
   public class MultiplyByPolynomial
   {
      [Fact]
      public void MultiplyByMonomial()
      {
         int mco = 3, mdg = 4;
         var m = new Polynomial(new Term(mco, mdg));

         int pdg1 = 4, pdg2 = 2;
         int pco1 = 2, pco2 = 5;
         var p = new Polynomial(new Term(pco1, pdg1),
                                new Term(pco2, pdg2));

         var result = p * m;

         var expectedDeg1 = pdg1 + mdg;
         var expectedDeg2 = pdg2 + mdg;

         var expectedCo1 = pco1 * mco;
         var expectedCo2 = pco2 * mco;

         Assert.Equal(2, result.TermsCount);

         Assert.Equal(expectedCo1, result[expectedDeg1].Coefficient);
         Assert.Equal(expectedCo2, result[expectedDeg2].Coefficient);
      }

      [Fact]
      public void MultiplyByPolynomial_SimplifyLikeTerms()
      {
         var p1 = new Polynomial(new Term(3, 4),
                                 new Term(8, 2));

         var p2 = new Polynomial(new Term(2, 4),
                                 new Term(5, 2));

         var result = p1 * p2;
         
         Assert.Equal(3, result.TermsCount);

         Assert.Equal(6, result[8].Coefficient);
         Assert.Equal(31, result[6].Coefficient);
         Assert.Equal(40, result[4].Coefficient);
      }

      [Fact]
      public void MultiplyByPolynomial_NoLikeTerms()
      {
         var p1 = new Polynomial(new Term(3, 2),
                                 new Term(8, 1));

         var p2 = new Polynomial(new Term(2, 1),
                                 new Term(5, 3));

         var result = p1 * p2;

         Assert.Equal(4, result.TermsCount);

         Assert.Equal(15, result[5].Coefficient);
         Assert.Equal(40, result[4].Coefficient);
         Assert.Equal(06, result[3].Coefficient);
         Assert.Equal(16, result[2].Coefficient);
      }

      [Fact]
      public void MultiplyByZeroPolynomial()
      {
         var p1 = new Polynomial(new Term(0, 5));

         var p2 = new Polynomial(new Term(2, 1),
                                 new Term(5, 3));

         var result = p1 * p2;

         Assert.Equal(0, result.TermsCount);
         Assert.Equal(0, result.Degree);
      }
   }
}