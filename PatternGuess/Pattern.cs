using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        public BitmapImage GetImageFromFile(string filePath)
        {
            filePath = "src/img/" + filePath + ".png";
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл изображения не найден.", filePath);

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();

            return image;
        }
    }
}
