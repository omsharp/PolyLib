using System;
using System.Linq;

namespace PolyLib.Core
{
   public class Term
   {
      public double Coefficient { get; private set; }

      public Variable[] Variables { get; private set; } //? should be read only collection

      public int Degree => Variables.Sum(v => v.Exponent);

      /// <summary>
      /// Creates a  single variable Term of the form a(x^n)  |  (a = coefficient, n = degree)
      /// </summary>
      public Term(double coefficient, int degree)
      {
         if (degree < 0)
            throw new ArgumentException("degree must be a non-negative integer.");

         Coefficient = coefficient;
         Variables = new[] { new Variable('x', degree) };
      }

      /// <summary>
      /// Creates a  multi-variable Term with the given variables. 
      /// </summary>
      public Term(double coefficient, params Variable[] variables)
      {
         Coefficient = coefficient;
         Variables = variables.Where(v => v.Exponent > 0).ToArray();
      }

      /// <summary>
      /// Returns true if the passed term is similar, otherwise returns false.
      /// </summary>
      public bool SimilarTo(Term term)
      {
         if (term.Variables.Length != Variables.Length)
            return false;

         foreach (var v1 in term.Variables)
         {
            if (!Variables.Any(v2 => v2.Symbol == v1.Symbol && v2.Exponent == v1.Exponent))
               return false;
         }

         return true;
      }
   }
}