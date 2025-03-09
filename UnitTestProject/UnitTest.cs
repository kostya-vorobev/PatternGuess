using System;
using System.Linq;
using Xunit;
using PatternGuess;
using System.Collections.Generic;

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

        [Fact]
        public void PatternReturnAnswer()
        {
            Pattern pattern = new Pattern();
            var validNames = new List<string> { "Singleton", "Factory", "Observer", "Decorator", "Strategy" };
            Assert.Contains(pattern.VeryAnswer, validNames);
        }

        [Fact]
        public void PatternReturnWrongAnswer()
        {
            Pattern pattern = new Pattern();
            var correctAnswer = pattern.VeryAnswer;
            var wrongAnswer = pattern.GetWrongAnswers(3);
            Assert.Equal(3, wrongAnswer.Count);

            foreach (var answer in wrongAnswer)
            {
                Assert.NotEqual(correctAnswer, answer);
            }
        }
    }
}
