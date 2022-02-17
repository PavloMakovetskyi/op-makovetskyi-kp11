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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToTicTacToe_Click(object sender, RoutedEventArgs e)
        {
            TicTacToeProgram tct = new TicTacToeProgram();
            Hide();
            tct.Show();
        }

        private void ToCalculator_Click(object sender, RoutedEventArgs e)
        {
            Calculator calc = new Calculator();
            Hide();
            calc.Show();
        }
        private void ToDatabase_Click(object sender, RoutedEventArgs e)
        {
            StudentsDatabase stdb = new StudentsDatabase();
            Hide();
            stdb.Show();
        }

        private void ToCredits_Click(object sender, RoutedEventArgs e)
        {
            Credits crd = new Credits();
            Hide();
            crd.Show();
        }
    }
}
