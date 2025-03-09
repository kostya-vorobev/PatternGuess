using System;
using System.Linq;
using Xunit;
using PatternGuess;

namespace UnitTestProject
{
    public class UnitTest
    {
        [Fact]
        public void PatternClass()
        {
            Pattern pattern = new Pattern();
            Assert.NotNull(pattern);
        }
    }
}
