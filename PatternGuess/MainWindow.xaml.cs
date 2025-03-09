using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PatternGuess
{
    public partial class MainWindow : Window
    {
        private Pattern currentPattern;
        private int correctAnswersCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadNewQuestion()
        {
            // Создаем новый объект Pattern
            currentPattern = new Pattern();

            // Обновляем изображение для вопроса
            QuestionImage.Source = currentPattern.GetImageFromFile(currentPattern.VeryAnswer);

            // Получаем ответы (правильный + 3 неправильных)
            var answers = new List<string> { currentPattern.VeryAnswer };
            answers.AddRange(currentPattern.GetWrongAnswers(3));
            answers = Shuffle(answers); // Перемешиваем ответы

            // Обновляем текст на кнопках
            UpdateButtons(answers);
        }

        private void UpdateButtons(List<string> answers)
        {
            // Список кнопок
            var buttons = new List<Button> { AnswerButton1, AnswerButton2, AnswerButton3, AnswerButton4 };

            // Обновляем текст на кнопках
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i < answers.Count)
                {
                    buttons[i].Content = answers[i];
                    buttons[i].Visibility = Visibility.Visible; // Показываем кнопку
                }
                else
                {
                    buttons[i].Visibility = Visibility.Collapsed; // Скрываем кнопку, если ответов меньше
                }
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string selectedAnswer = button.Content.ToString();
                if (selectedAnswer == currentPattern.VeryAnswer)
                {
                    correctAnswersCount++;
                    UpdateScoreText();
                    MessageBox.Show("Правильно! 🎉");
                }
                else
                {
                    MessageBox.Show($"Неправильно. Правильный ответ: {currentPattern.VeryAnswer}");
                }

                LoadNewQuestion();
            }
        }

        private void UpdateScoreText()
        {
            ScoreTextBlock.Text = $"Правильных ответов: {correctAnswersCount}";
        }

        // Метод для перемешивания списка
        private List<string> Shuffle(List<string> list)
        {
            var random = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
            return list;
        }

            private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNewQuestion();
        }
    }
}