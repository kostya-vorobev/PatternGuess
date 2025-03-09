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
    }
}
