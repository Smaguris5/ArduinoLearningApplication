using ArduinoLearningApplication.Pages.Exercises;
using ArduinoLearningApplication.Pages.Questionnaire;
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
    /// Interaction logic for MainHub.xaml
    /// </summary>
    public partial class MainHub : Page
    {
        public MainHub()
        {
            InitializeComponent();
            if (File.Exists("questionnaire.json"))
                TestButtonText.Text = "Knowledge\nAssessment";
            else
                TestButtonText.Text = $"Initial Knowledge\nAssessment";
        }

        private void Exercise1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExerciseBoard());
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("questionnaire.json"))
                NavigationService.Navigate(new Question1());
            else
                NavigationService.Navigate(new FirstAssessment());
        }

        private void UserStatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserStatistics());
        }
    }
}
