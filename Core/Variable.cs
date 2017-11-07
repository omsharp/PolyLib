﻿using System;

namespace Core
{
   public class Variable
   {
      public char Symbol { get; private set; }
      public int Exponent { get; private set; }

      public Variable(char symbol, int exponent)
      {
         if (exponent < 0)
            throw new ArgumentException("exponent must be a non-negative integer.");

         if (symbol == ' ')
            throw new ArgumentException("symbol can't be empty.");

         Symbol = symbol;
         Exponent = exponent;
      }
   }
}