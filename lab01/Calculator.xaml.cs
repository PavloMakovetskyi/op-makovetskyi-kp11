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

namespace Lab01_OP
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        static double currentNumber;
        static string currentOperation;
        
        public Calculator()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            Button numBtn = (Button)sender;
            if (!(numBtn.Content == DC.Content && InputAndResult.Text == "")) 
                InputAndResult.Text += numBtn.Content.ToString();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            InputAndResult.Text = String.Empty;
            Equals.IsEnabled = false;
            OperationName.Text = String.Empty;
        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            double currentNumber = double.Parse(InputAndResult.Text);
            currentNumber = -currentNumber;
            InputAndResult.Text = currentNumber.ToString();
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            InputAndResult.Text = InputAndResult.Text.Remove(InputAndResult.Text.Length - 1);
        }

        private void OperationChoiceAndNumberSaving(object sender, RoutedEventArgs e)
        {
            Button chosenOperationButton = (Button)sender;
            currentOperation = chosenOperationButton.Content.ToString().Trim();
            OperationName.Text = chosenOperationButton.Content.ToString().Trim();
            currentNumber = double.Parse(InputAndResult.Text) * 1.0;
            InputAndResult.Text = String.Empty;
            Equals.IsEnabled = true;
        }

        private void Calculation(object sender, RoutedEventArgs e)
        {
            double SecondNumber = double.Parse(InputAndResult.Text) * 1.0;
            string operation = currentOperation;
                
            switch (operation)
                {
                    case "+":
                    {
                        InputAndResult.Text = (currentNumber + SecondNumber).ToString();
                        currentNumber = double.Parse(InputAndResult.Text);
                        break;
                    } 
                        
                    case "-":
                    {
                        InputAndResult.Text = (currentNumber - SecondNumber).ToString();
                        currentNumber = double.Parse(InputAndResult.Text);
                        break;
                    }
                    case "*":
                    {
                        InputAndResult.Text = (currentNumber * SecondNumber).ToString();
                        currentNumber = double.Parse(InputAndResult.Text);
                        break;
                    }    
                    case "/":
                    {
                        InputAndResult.Text = (currentNumber / SecondNumber).ToString();
                        currentNumber = double.Parse(InputAndResult.Text);
                        break;
                    }
                }       
            }
        }
    }
