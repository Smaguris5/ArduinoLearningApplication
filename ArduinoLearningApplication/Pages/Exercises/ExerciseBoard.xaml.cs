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

namespace ArduinoLearningApplication.Pages.Exercises
{
    /// <summary>
    /// Interaction logic for ExerciseBoard.xaml
    /// </summary>
    public partial class ExerciseBoard : Page
    {
        private int tries;
        private string ResetButtonComboT="Reset Switch";
        private string UsbConnectorComboT= "USB Connector";
        private string UsbInterfaceComboT= "USB Interface Chip";
        private string CrystalOscillatorComboT = "Crystal Oscillator";
        private string VoltageRegulatorComboT = "Voltage Regulator";
        private string PowerPortComboT="Power Port";
        private string DigitalPinsComboT="Digital Pins";
        private string PowerLedIndicatorComboT="Power Led Indicator";
        private string MicrocontrollerComboT="Microcontroller";
        private string AnalogInputPinsComboT="Analog Input Pins";

        private int[] correctarray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

        public ExerciseBoard()
        {
            InitializeComponent();
            tries = 0;
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswers();

            if(correctarray[0]==1&&correctarray[1]==1&&correctarray[2]==1&&correctarray[3]==1&&correctarray[4]==1&&correctarray[5]==1&&correctarray[6]==1&&correctarray[7]==1&&correctarray[8]==1&&correctarray[9]==1)
            {
                if (tries == 1)
                {
                    MessageBox.Show("Congratulations, you did it first try! Good job!");
                    MarkComplete();
                    NavigationService.Navigate(new MainHub());
                }
                else
                {
                    MessageBox.Show($"Good job, you did it! It took you {tries} tries to do it, but you completed it correctly.");
                    MarkComplete();
                    NavigationService.Navigate(new MainHub());
                }
                    
            }
            else
            {
                
                if(ResetButtonCombo.Text.ToString()=="" || UsbConnectorCombo.Text.ToString()=="" || UsbInterfaceCombo.Text.ToString()=="" || CrystalOscillatorCombo.Text.ToString()=="" ||
                    VoltageRegulatorCombo.Text.ToString() =="" || PowerPortCombo.Text.ToString() =="" || DigitalPinsCombo.Text.ToString() =="" || PowerLedIndicatorCombo.Text.ToString() =="" ||
                    MicrocontrollerCombo.Text.ToString() ==""|| AnalogInputPinsCombo.Text.ToString() =="")
                {
                    tries--;
                    MessageBox.Show("Make sure you complete a selection for each component.");
                }
                else
                {
                    int mistakes = 0;
                    foreach (int i in correctarray)
                    {
                        if (i == 0)
                            mistakes++;
                    }
                    FeedbackText.Text = $"There are {mistakes} mistakes. Keep trying!";
                    FeedbackText.Visibility = Visibility.Visible;
                }
            }
        }

        private void MarkComplete()
        {
            string complete = "complete";
            string JSONresult = JsonConvert.SerializeObject(complete, Formatting.Indented);
            string path = "exercise1.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }
        private void CheckAnswers()
        {
            tries++;
            if (ResetButtonCombo.Text.ToString() == ResetButtonComboT)
                correctarray[0] = 1;
            if (UsbConnectorCombo.Text.ToString() == UsbConnectorComboT)
                correctarray[1] = 1;
            if (UsbInterfaceCombo.Text.ToString() == UsbInterfaceComboT)
                correctarray[2] = 1;
            if (CrystalOscillatorCombo.Text.ToString() == CrystalOscillatorComboT)
                correctarray[3] = 1;
            if (VoltageRegulatorCombo.Text.ToString() == VoltageRegulatorComboT)
                correctarray[4] = 1;
            if (PowerPortCombo.Text.ToString() == PowerPortComboT)
                correctarray[5] = 1;
            if (DigitalPinsCombo.Text.ToString() == DigitalPinsComboT)
                correctarray[6] = 1;
            if (PowerLedIndicatorCombo.Text.ToString() == PowerLedIndicatorComboT)
                correctarray[7] = 1;
            if (MicrocontrollerCombo.Text.ToString() == MicrocontrollerComboT)
                correctarray[8] = 1;
            if (AnalogInputPinsCombo.Text.ToString() == AnalogInputPinsComboT)
                correctarray[9] = 1;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainHub());
        }
    }
}
