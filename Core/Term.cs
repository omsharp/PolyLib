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
      /// <param name="coefficient">a</param>
      /// <param name="degree">n</param>
      public Term(double coefficient, int degree)
      {
         if (degree < 0)
            throw new ArgumentException("degree must be a non-negative integer.");

         Coefficient = coefficient;
         Variables = new[] { new Variable('x', degree) };
      }

      /// <summary>
      /// Creates a  multi-variable Term. 
      /// </summary>
      /// <param name="coefficient">Coefficient of the terms.</param>
      /// <param name="variables">A list of variables.</param>
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
         if (term.Variables.Count() != Variables.Count())
            return false;

         foreach (var variable in term.Variables)
         {
            var s = variable.Symbol;
            var e = variable.Exponent;
            if (!Variables.Any(v => v.Symbol == s && v.Exponent == e))
               return false;
         }

         return true;
      }
   }
}