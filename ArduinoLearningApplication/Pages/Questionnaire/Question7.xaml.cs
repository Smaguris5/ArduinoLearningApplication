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
    /// Interaction logic for Question7.xaml
    /// </summary>
    public partial class Question7 : Page
    {
        public Question7()
        {
            InitializeComponent();
        }

        private int answer = 0;
        private void QuestionService()
        {
            if (AnswerOne.IsChecked == true)
                answer = 1;
            else if (AnswerTwo.IsChecked == true)
                answer = 2;
            else if (AnswerThree.IsChecked == true)
                answer = 3;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            QuestionService();
            if (answer == 0)
            {
                MessageBox.Show("Please select an answer", "No Answer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                new QuestionWriter(7, answer, 1);
                NavigationService.Navigate(new Question8());
            }
        }
    }
}
