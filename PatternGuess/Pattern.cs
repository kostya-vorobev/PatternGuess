using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGuess
{
    public class Pattern
    {
        string veryAnswer;
        private readonly Random random = new Random();

        private readonly List<string> patternNames = new List<string>
        {
            "Singleton",
            "Factory",
            "Observer",
            "Decorator",
            "Strategy"
        };

        public Pattern()
        {
            this.VeryAnswer = patternNames[random.Next(patternNames.Count())];
        }

        public string VeryAnswer { get => veryAnswer; set => veryAnswer = value; }

        public List<string> GetWrongAnswers(int count)
        {
            string correctAnswer = veryAnswer;
            var wrongAnswers = new List<string>();

            var availableNames = patternNames.Where(name => name != correctAnswer).ToList();

            for (int i = 0; i < count; i++)
            {
                if (availableNames.Count == 0)
                    break;

                int index = random.Next(availableNames.Count);
                wrongAnswers.Add(availableNames[index]);
                availableNames.RemoveAt(index);
            }

            return wrongAnswers;
        }
    }
}
