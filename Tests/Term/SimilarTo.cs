using Xunit;
using PolyLib.Core;

namespace Tests
{
   public class SimilarTo
   {
      [Fact]
      public void SimilarTo_SingleVariable()
      {
         var t1 = new Term(2, 3);
         var t2 = new Term(7, 3);
         Assert.True(t1.SimilarTo(t2));
      }

      [Fact]
      public void SimilarTo_MultiVariable_1()
      {
         var t1 = new Term(2, new Variable('x', 2), new Variable('y', 2));
         var t2 = new Term(2, new Variable('x', 2), new Variable('y', 2));
         Assert.True(t1.SimilarTo(t2));
      }

      [Fact]
      public void SimilarTo_MultiVariable_2()
      {
         var t1 = new Term(2, new Variable('x', 2), new Variable('y', 2));
         var t2 = new Term(2, new Variable('x', 2), new Variable('y', 3));
         Assert.False(t1.SimilarTo(t2));
      }

      [Fact]
      public void SimilarTo_MultiVariable_3()
      {
         var t1 = new Term(2, new Variable('x', 2), new Variable('y', 2));
         var t2 = new Term(2, new Variable('x', 2), new Variable('z', 2));
         Assert.False(t1.SimilarTo(t2));
      }
   }
}
