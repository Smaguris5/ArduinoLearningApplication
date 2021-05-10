using ArduinoLearningApplication.Services.Data_Management;
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
using System.Windows.Shapes;

namespace ArduinoLearningApplication.Pages
{
    /// <summary>
    /// Interaction logic for StartupScreen.xaml
    /// </summary>
    public partial class StartupScreen : Window
    {
        public StartupScreen()
        {
            InitializeComponent();

            Loaded += LoadWindow;
        }

        private void LoadWindow(object sender, RoutedEventArgs e)
        {
            if (File.Exists("user.json"))
                ContentFrame.NavigationService.Navigate(new MainHub());
            else
                ContentFrame.NavigationService.Navigate(new WelcomePage());

        }
    }
}
