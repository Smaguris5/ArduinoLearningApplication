using ArduinoLearningApplication.Services.Data_Management;
using MaterialDesignColors.Recommended;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArduinoLearningApplication.Pages
{
    /// <summary>
    /// Interaction logic for UserStatistics.xaml
    /// </summary>
    public partial class UserStatistics : Page
    {
        private List<Question> questions = new List<Question>();
        private int TestsTaken = 0;
        private List<int> correctAnswers;
        private List<double> correctAnswersPercent;

        public UserStatistics()
        {
            InitializeComponent();
            correctAnswers = new List<int>();
            correctAnswersPercent = new List<double>();
            if (File.Exists("exercise1.json"))
            {
                ExerciseCompletion.Text = "Exercise 1: Complete";
                ExerciseCompletion.Foreground = new SolidColorBrush(Colors.Green);
            }
            if (File.Exists("questionnaire.json"))
            {
                questions = JsonConvert.DeserializeObject<List<Question>>(File.ReadAllText("questionnaire.json"));
                TestsTaken = questions.Count / 9;
                


                if (TestsTaken > 0)
                {
                    GetStats();

                    InitTestScore.Text = $"Score: {correctAnswers[0]}/9";
                    InitTestPercent.Text = $"Score(%): {correctAnswersPercent[0]}%";

                    if (TestsTaken > 1)
                    {
                        int x = correctAnswers.Count - 1;
                        GetStats();

                        LastTestScore.Text = $"Score: {correctAnswers[x]}/9";
                        LastTestPercent.Text = $"Score(%): {correctAnswersPercent[x]}%";

                        if (correctAnswers[x] == 9)
                        {
                            ImprovementText.Text = $"You have achieved a perfect score, awesome!";
                            ImprovementText.Foreground = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            double improvement = Convert.ToDouble(correctAnswers[x]) / Convert.ToDouble(correctAnswers[0]) * 100 - 100;
                            if (improvement < 1)
                            {
                                ImprovementText.Text = "You have not yet made an improvement. Keep practicing!";
                                ImprovementText.Foreground = new SolidColorBrush(Colors.Red);
                            }
                            else if (improvement < 50)
                            {
                                ImprovementText.Text = $"You have made an improvement of {improvement}%, but you can do better!";
                                ImprovementText.Foreground = new SolidColorBrush(Colors.Orange);
                            }
                            else
                            {
                                ImprovementText.Text = $"You have made an improvement of {improvement}%, great job!";
                                ImprovementText.Foreground = new SolidColorBrush(Colors.Green);
                            }
                        }
                    }
                }
            }
        }

        private void GetStats()
        {
            int questionIndicator = 0;
            for(int i=0; i < TestsTaken; i++)
            {
                int tempCorrectAnswers=0;
                double tempPercent = 0;
                for(int x = 0; x < 9; x++)
                {
                    if(questions[questionIndicator + x].Selection==questions[questionIndicator + x].CorrectAnswer) 
                        tempCorrectAnswers++;
                }
                correctAnswers.Add(tempCorrectAnswers);
                tempPercent = tempCorrectAnswers;
                correctAnswersPercent.Add(Math.Round(tempPercent / 9 * 100, 0));
                questionIndicator =+ 9;
            }
        }

        private void ResetProgressButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("All of the progress will be reset", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                if (File.Exists("questionnaire.json"))
                    File.Delete("questionnaire.json");
                if (File.Exists("exercise1.json"))
                    File.Delete("exercise1.json");
                NavigationService.Navigate(new UserStatistics());
            }
        }

        private void WipeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("All of the progress and the profile will be reset", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                if (File.Exists("exercise1.json"))
                    File.Delete("exercise1.json");
                if (File.Exists("user.json"))
                    File.Delete("user.json");
                if (File.Exists("questionnaire.json"))
                    File.Delete("questionnaire.json");
                NavigationService.Navigate(new WelcomePage());
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainHub());
        }
    }
}
