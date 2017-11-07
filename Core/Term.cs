using System;
using System.Linq;

namespace Core
{

   public class Term
   {
      public double Coefficient { get; private set; }

      public Variable[] Variables { get; private set; }

      public int Degree => Variables.Sum(v => v.Exponent);

      /// <summary>
      /// Creates a Term of the form a(x^n)
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