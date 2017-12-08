using System;
using System.Collections.Generic;
using System.Linq;

namespace PolyLib.Core
{
   public class Polynomial
   {
      private readonly List<Term> terms = new List<Term>();

      public int TermsCount { get { return terms.Count; } }

      public int Degree { get { return terms.Any() ? terms.Max(t => t.Degree) : 0; } }

      private Polynomial()
      { }

      public Polynomial(params Term[] trms)
      {
         foreach (var term in trms)
         {
            if (this.terms.SingleOrDefault(t => t.SimilarTo(term)) is Term same)
            {
               this.terms.Remove(same);
               this.terms.Add(new Term(same.Coefficient + term.Coefficient, term.Variables));
            }
            else
            {
               this.terms.Add(term);
            }
         }
      }

      /// <summary>
      /// Returns an array of all terms of a given degree in this polynomial.
      /// </summary>
      public Term[] TermsOfDegree(int degree)
      {
         if (degree < 0 || degree > Degree)
            throw new DegreeOutOfRangeException();

         var ts = terms.Where(t => t.Degree == degree).ToArray();

         return ts.Any() ? ts : new[] { new Term(0, degree) };
      }

      #region Negation Operator Overload

      public static Polynomial operator -(Polynomial p) => p * -1;

      #endregion

      #region Addition Operator Overload

      public static Polynomial operator +(Polynomial p, double n) => p + new Polynomial(new Term(n, 0));
      public static Polynomial operator +(double n, Polynomial p) => p + new Polynomial(new Term(n, 0));

      public static Polynomial operator +(Term t, Polynomial p) => p + new Polynomial(t);
      public static Polynomial operator +(Polynomial p, Term t) => p + new Polynomial(t);

      public static Polynomial operator +(Polynomial p1, Polynomial p2)
      {
         return new Polynomial(
                             p1.terms
                               .Concat(p2.terms)
                               .GroupBy(t => t.Degree)
                               .Select(g => new Term(g.Sum(t => t.Coefficient), g.Key))
                               .Where(t => Math.Abs(t.Coefficient) > 0)
                               .ToArray());
      }

      #endregion

      #region Subtraction Operator Overload

      public static Polynomial operator -(Polynomial p, double n) => p + (-n);
      public static Polynomial operator -(double n, Polynomial p) => p + (-n);

      public static Polynomial operator -(Polynomial p, Term t) => p + (new Term(-t.Coefficient, t.Degree));
      public static Polynomial operator -(Term t, Polynomial p) => p + (new Term(-t.Coefficient, t.Degree));

      public static Polynomial operator -(Polynomial p1, Polynomial p2) => p1 + (-p2);

      #endregion

      #region Multiplication Operator Overload

      public static Polynomial operator *(double n, Polynomial p) => p * n;

      public static Polynomial operator *(Polynomial p, double n)
      {
         if (n == 0)
            return new Polynomial();

         return p * new Term(n, 0);
      }

      public static Polynomial operator *(Term t, Polynomial p) => p * t;

      public static Polynomial operator *(Polynomial p, Term t)
      {
         if (t.Coefficient == 0)
            return new Polynomial();

         return new Polynomial(
                           p.terms
                            .Where(pt => pt.Coefficient > 0)
                            .Select(pt => new Term(pt.Coefficient * t.Coefficient, pt.Degree + t.Degree))
                            .ToArray());
      }

      public static Polynomial operator *(Polynomial p1, Polynomial p2)
      {
         if (p1.Degree == 0 || p2.Degree == 0)
            return new Polynomial();

         var result = new Polynomial();

         foreach (var term in p1.terms)
            result += (p2 * term);

         return result;
      }

      #endregion
   }
}