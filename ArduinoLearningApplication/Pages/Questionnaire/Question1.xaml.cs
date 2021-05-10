using ArduinoLearningApplication.Services.Data_Management;
using System;
using System.Collections.Generic;
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

namespace ArduinoLearningApplication.Pages.Questionnaire
{
    /// <summary>
    /// Interaction logic for Question1.xaml
    /// </summary>
    public partial class Question1 : Page
    {
        private int one = 0, two = 0, three = 0, four = 0, five=0, finalAnswer=0;

        private void AnswerFive_Unchecked(object sender, RoutedEventArgs e)
        {
            AnswerOne.IsEnabled = true;
            AnswerTwo.IsEnabled = true;
            AnswerThree.IsEnabled = true;
            AnswerFour.IsEnabled = true;
        }

        private void AnswerFive_Checked(object sender, RoutedEventArgs e)
        {
            AnswerOne.IsChecked = false;
            AnswerTwo.IsChecked = false;
            AnswerThree.IsChecked = false;
            AnswerFour.IsChecked = false;

            AnswerOne.IsEnabled = false;
            AnswerTwo.IsEnabled = false;
            AnswerThree.IsEnabled = false;
            AnswerFour.IsEnabled = false;
        }

        public Question1()
        {
            InitializeComponent();
        }

        private void QuestionService()
        {
            if (AnswerOne.IsChecked == true)
                one = 1;
            if (AnswerTwo.IsChecked == true)
                two = 1;
            if (AnswerThree.IsChecked == true)
                three = 1;
            if (AnswerFour.IsChecked == true)
                four = 1;
            if (AnswerFive.IsChecked == true)
                five = 1;

            string answer = Convert.ToString(one) + Convert.ToString(two) + Convert.ToString(three) + Convert.ToString(four) + Convert.ToString(five);
            finalAnswer = Convert.ToInt32(answer);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionService();
            if (finalAnswer == 0)
            {
                MessageBox.Show("Please select an answer", "No Answer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                new QuestionWriter(1, finalAnswer, 10110);
                NavigationService.Navigate(new Question2());
            }
        }
    }
}
