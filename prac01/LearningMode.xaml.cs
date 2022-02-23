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
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace KeyboardWriting
{
    /// <summary>
    /// Interaction logic for LearningMode.xaml
    /// </summary>
    public partial class LearningMode : Window
    {
        
        static List<double> rawIntervals = new List<double>();

        static List<double> filteredIntervals = new List<double>();
     
        
        Stopwatch stopwatch = new Stopwatch();

        static double STUDENT;

        public LearningMode()
        {
            InitializeComponent();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mn = new MainMenu();
            Close();
            mn.Show();
        }

        private void Confirmation_Click(object sender, RoutedEventArgs e)
        {
            
            KeyWordTextBox.IsEnabled = false; Confirmation.IsEnabled = false;
            NumberOfInputsTextBox.IsEnabled = true; CountConfirmation.IsEnabled = true;
            
            StreamWriter sww = new StreamWriter(@"Key_Word.txt");
            sww.Write(KeyWordTextBox.Text);
            sww.Close();
        }

        private void CountConfirmation_Click(object sender, RoutedEventArgs e)
        {
            NumberOfInputsTextBox.IsEnabled = false; CountConfirmation.IsEnabled = false;
            STUDENT_Box.IsEnabled = true; STUDENT_Confirmation_Button.IsEnabled = true;

            using (StreamWriter sr = new StreamWriter(@"NumberOfInputs.txt"))
            {
                sr.WriteLine(NumberOfInputsTextBox.Text);
            };
        }

        private void STUDENT_Confirmation_Button_Click(object sender, RoutedEventArgs e)
        {
            Alpha_Confirmation_Button.IsEnabled = true;
            AlphaBox.IsEnabled = true;

            STUDENT = double.Parse(STUDENT_Box.Text);

            STUDENT_Box.IsEnabled = false;
            STUDENT_Confirmation_Button.IsEnabled = false;
        }

        private void Alpha_Confirmation_Button_Click(object sender, RoutedEventArgs e)
        {
            Alpha_Confirmation_Button.IsEnabled = false;
            AlphaBox.IsEnabled = false;

            EnterCurrentWordInstanceTextBox.IsEnabled = true;

            SymbolCountLB.Content = "0"; RepeatCountLB.Content = "0";

            stopwatch.Start();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            KeyWordTextBox.IsEnabled = true; KeyWordTextBox.Clear();
            Confirmation.IsEnabled = true;

            NumberOfInputsTextBox.IsEnabled = false; NumberOfInputsTextBox.Clear();
            CountConfirmation.IsEnabled = false;

            EnterCurrentWordInstanceTextBox.IsEnabled = false;
            SymbolCountLB.Content = ""; RepeatCountLB.Content = "";

            EnterCurrentWordInstanceTextBox.Clear();

            InputsFinishedLB.Content = "";

            File.WriteAllText(@"LearningIntervals.txt", "");
            File.WriteAllText(@"Key_Word.txt", "");
            File.WriteAllText(@"EtalonVariance.txt", "");


            rawIntervals.Clear();
            filteredIntervals.Clear();

            STUDENT_Box.Text = "";

        }

        double ExpectedValue(List<double> currentIntervalSet)
        {
            double SetSum = 0;

            foreach (double interval in currentIntervalSet)
            {
                SetSum += interval;
            }

            return SetSum / currentIntervalSet.Count;
        }

        double Variance(List<double> currentIntervalSet, double expVal)
        {
            double VarSum = 0;

            foreach (double interval in currentIntervalSet)
            {
                VarSum += Math.Pow(interval - expVal, 2);
            }

            VarSum /= (currentIntervalSet.Count - 1);

            return VarSum;
        }


        private void FormingStatisticsData(List<double> TimeIntervals)
        {
      
           double subtractedElemValue; double currTdist;
            
            for (int i = 1; i < TimeIntervals.Count; i++)
            {
                subtractedElemValue = TimeIntervals[i];

                TimeIntervals.Remove(subtractedElemValue);

                double expVal = ExpectedValue(TimeIntervals);
                double variance = Variance(TimeIntervals, expVal);

                currTdist = Math.Abs((subtractedElemValue - ExpectedValue(TimeIntervals)) / (Math.Sqrt(variance) / Math.Sqrt(TimeIntervals.Count)));


                if (!(currTdist > STUDENT))
                {
                    filteredIntervals.Add(subtractedElemValue);
                }


                TimeIntervals.Insert(i, subtractedElemValue);
            }
        }

        private void EnterCurrentWordInstanceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string watchIter = stopwatch.Elapsed.ToString().Substring(7);
            
            
            if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.LeftShift && e.Key != Key.RightShift)
                rawIntervals.Add(double.Parse(watchIter));


            stopwatch.Restart();

            if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.LeftShift && e.Key != Key.RightShift)
                SymbolCountLB.Content = int.Parse(SymbolCountLB.Content.ToString()) + 1;
            if (e.Key == Key.Back)
            {
                SymbolCountLB.Content = int.Parse(SymbolCountLB.Content.ToString()) - 1;
            }

            if (int.Parse(SymbolCountLB.Content.ToString()) == KeyWordTextBox.Text.Length)
            {
                RepeatCountLB.Content = int.Parse(RepeatCountLB.Content.ToString()) + 1;
                SymbolCountLB.Content = "0";
                EnterCurrentWordInstanceTextBox.Clear();

                FormingStatisticsData(rawIntervals);


                using (StreamWriter sw = new StreamWriter(@"LearningIntervals.txt", true))
                {
                    foreach (var interval in filteredIntervals)
                    {
                        sw.WriteLine(interval);
                    }
                };

                using (StreamWriter sw = new StreamWriter(@"EtalonVariance.txt", true))
                {
                    sw.WriteLine(Variance(filteredIntervals, ExpectedValue(filteredIntervals)));
                };

                filteredIntervals.Clear();
                rawIntervals.Clear();

            }
            if (RepeatCountLB.Content.ToString() == NumberOfInputsTextBox.Text)
            {
                EnterCurrentWordInstanceTextBox.IsEnabled = false;

                STUDENT_Box.IsEnabled = false;

                RepeatCountLB.Content = "0";
                InputsFinishedLB.Content = "Введення завершено!";
                
                stopwatch.Stop();
            }
        }

        
    }
}
