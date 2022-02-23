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
    /// Interaction logic for AuthMode.xaml
    /// </summary>
    public partial class AuthMode : Window
    {

        static List<double> rawIntervals = new List<double>();

        static List<double> etalonIntervals = new List<double>();

        static List<double> rawIntervalsPart = new List<double>();

        static int successTry = 0; static int FailTry = 0;

        static StreamReader sr = new StreamReader(@"NumberOfInputs.txt");

        int numOfInputs = int.Parse(sr.ReadLine().Trim());

        static List<double> etalonIntervalsPart = new List<double>();

        Stopwatch stopwatch = new Stopwatch();

        static double STUDENT;
        static double FISHER;

        public AuthMode()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader(@"Key_Word.txt"))
            {
                KeyWordLB.Content = sr.ReadToEnd().Trim();
            }

            using (StreamReader sr = new StreamReader(@"LearningIntervals.txt"))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine() != null && sr.ReadLine() != " " && sr.ReadLine() != String.Empty)
                    {
                        etalonIntervals.Add(double.Parse(sr.ReadLine().Trim()));
                    }
                }
            }

            for (int i = 0; i < numOfInputs; i++)
            {
                etalonIntervalsPart.Add(etalonIntervals[i]);
            }
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mn = new MainMenu();
            Close();
            mn.Show();
        }


        private void CountConfirmation_Click(object sender, RoutedEventArgs e)
        {
            NumberOfInputsTextBox.IsEnabled = false; CountConfirmation.IsEnabled = false;
            AlphaBox.IsEnabled = true; Alpha_Confirmation_Button.IsEnabled = true;
        }


        private void Alpha_Confirmation_Button_Click(object sender, RoutedEventArgs e)
        {
            Alpha_Confirmation_Button.IsEnabled = false;
            AlphaBox.IsEnabled = false;

            Student_Box.IsEnabled = true;
            Student_Box_Confirmation_Button.IsEnabled = true;


        }

        private void Student_Box_Confirmation_Button_Click(object sender, RoutedEventArgs e)
        {
            STUDENT = double.Parse(Student_Box.Text);

            Student_Box.IsEnabled = false;
            Student_Box_Confirmation_Button.IsEnabled = false;

            Fisher_Box.IsEnabled = true;
            Fisher_Box_Confirmation_Button.IsEnabled = true;
        }

        private void Fisher_Box_Confirmation_Button_Click(object sender, RoutedEventArgs e)
        {
            FISHER = double.Parse(Fisher_Box.Text);

            Fisher_Box.IsEnabled = false;
            Fisher_Box_Confirmation_Button.IsEnabled = false;

            EnterCurrentWordInstanceTextBox.IsEnabled = true;

            SymbolCountLB.Content = "0"; RepeatCountLB.Content = "0";

            stopwatch.Start();

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NumberOfInputsTextBox.IsEnabled = true; NumberOfInputsTextBox.Clear();
            CountConfirmation.IsEnabled = true;

            EnterCurrentWordInstanceTextBox.IsEnabled = false;
            SymbolCountLB.Content = ""; RepeatCountLB.Content = "";

            EnterCurrentWordInstanceTextBox.Clear();

            AlphaBox.Text = "";
            AlphaBox.IsEnabled = false;
            Student_Box.Text = "";
            Student_Box.IsEnabled = false;
            Fisher_Box.Text = "";
            Fisher_Box.IsEnabled = false;

            etalonIntervals.Clear();

            VarianceIs.Content = "";
            P_Is.Content = "";
            First_Error.Content = "";
            Second_Error.Content = "";



        }

        double ExpectedValue(List<double> currentIntervalSet)
        {
            double SetSum = 0;

            foreach (double interval in currentIntervalSet)
            {
                SetSum += interval;
            }

            return SetSum / (currentIntervalSet.Count - 1);
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

        double VariancePart(List<double> currentIntervalSet, double expVal)
        {
            double VarSum = 0;

            foreach (double interval in currentIntervalSet)
            {
                VarSum += Math.Pow(interval - expVal, 2);
            }

            VarSum /= (rawIntervals.Count - 1);

            return VarSum;
        }


        private void EnterCurrentWordInstanceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string watchIter = stopwatch.Elapsed.ToString().Substring(7);


            if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.LeftShift && e.Key != Key.RightShift)
            {
                rawIntervals.Add(double.Parse(watchIter));
                rawIntervalsPart.Add(double.Parse(watchIter));
            }
                
            


            stopwatch.Restart();

            if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.LeftShift && e.Key != Key.RightShift)
                SymbolCountLB.Content = int.Parse(SymbolCountLB.Content.ToString()) + 1;
            if (e.Key == Key.Back)
            {
                SymbolCountLB.Content = int.Parse(SymbolCountLB.Content.ToString()) - 1;
            }

            if (int.Parse(SymbolCountLB.Content.ToString()) == KeyWordLB.Content.ToString().Length)
            {
                RepeatCountLB.Content = int.Parse(RepeatCountLB.Content.ToString()) + 1;
                SymbolCountLB.Content = "0";
                EnterCurrentWordInstanceTextBox.Clear();


                double authVarPart = Variance(rawIntervalsPart, ExpectedValue(rawIntervalsPart));
                
                double etalonPartVar = VariancePart(etalonIntervalsPart, ExpectedValue(etalonIntervalsPart));

                double S = Math.Sqrt(((etalonPartVar * etalonPartVar + authVarPart * authVarPart) * (rawIntervalsPart.Count - 1)
                    ) / (2 * rawIntervalsPart.Count - 1));

                double T = Math.Abs(ExpectedValue(etalonIntervalsPart) - ExpectedValue(rawIntervalsPart)) / (S * Math.Sqrt(
                    2 / (rawIntervalsPart.Count - 1)));

                if (T > STUDENT)
                {
                    FailTry++;
                }
                else
                {
                    successTry++;
                }

                rawIntervalsPart.Clear();

            }
            if (RepeatCountLB.Content.ToString() == NumberOfInputsTextBox.Text)
            {
                EnterCurrentWordInstanceTextBox.IsEnabled = false;

                rawIntervals.RemoveAt(0);

                double etalonVar;
                using (StreamReader sr = new StreamReader(@"EtalonVariance.txt"))
                {
                    etalonVar = double.Parse(sr.ReadLine().Trim());
                }

                double authVar = Variance(rawIntervals, ExpectedValue(rawIntervals));

                double currFisher = Math.Max(etalonVar, authVar) / Math.Min(etalonVar, authVar);

                if (currFisher > FISHER)
                {
                    VarianceIs.Content = "Неодн.";
                }
                else
                {
                    VarianceIs.Content = "Одн.";
                }

                Student_Box.IsEnabled = false;

                RepeatCountLB.Content = "0";

                stopwatch.Stop();

                P_Is.Content = ((successTry * 1.0) / numOfInputs).ToString();

                First_Error.Content = ((double.Parse(NumberOfInputsTextBox.Text) * 1.0) / successTry).ToString();
                Second_Error.Content = ((double.Parse(NumberOfInputsTextBox.Text) * 1.0) / FailTry).ToString();


            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mn = new MainMenu();
            Close();
            mn.Show();
        }
    }
}

        