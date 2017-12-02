using System;
using System.Linq;

namespace Core
{
   public class Term
   {
      public double Coefficient { get; private set; }

      public Variable[] Variables { get; private set; } //? should be read only collection

      public int Degree => Variables.Sum(v => v.Exponent);

      /// <summary>
      /// Creates a  single variable Term of the form a(x^n)  |  (a = coefficient, n = degree)
      /// </summary>
      /// <param name="coefficient">a</param>
      /// <param name="degree">n</param>
      public Term(double coefficient, int degree)
      {
         if (degree < 0)
            throw new ArgumentException("degree must be a non-negative integer.");

         Coefficient = coefficient;
         Variables = new[] { new Variable('x', degree) };
      }
   }
}