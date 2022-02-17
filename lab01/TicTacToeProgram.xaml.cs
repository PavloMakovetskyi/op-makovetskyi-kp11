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
    /// Interaction logic for TicTacToeProgram.xaml
    /// </summary>
    public partial class TicTacToeProgram : Window
    {
        static byte[,] board_Matrix = new byte[5, 5];
        static byte sameCount = 0; static byte selectedCells = 0;
        static List<byte> mainDiagonal = new List<byte>();
        static List<byte> antiDiagonal = new List<byte>();

        public TicTacToeProgram()
        {
            InitializeComponent();
        }

        private void Cleaning()
        {
            sameCount = 0;
            selectedCells = 0;
            mainDiagonal.Clear();
            antiDiagonal.Clear();
            GenerateZeroMatrix(board_Matrix);
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Cleaning();
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
            
        }

        private void GenerateZeroMatrix(byte[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = 0;
        }

        private (byte, byte) Coordinates(ComboBox currentCell)
        {
            string cellName = currentCell.Name.Substring(1);
            var coordinates = cellName.Split("_");

            return (byte.Parse(coordinates[0]), byte.Parse(coordinates[1]));
        }

        private void isWinner(bool winCond, byte sameCount, byte lastChoice)
        {
            if (winCond && sameCount == 4 && lastChoice == 1)
            {
                WinMessage.Content = "X is a Winner!";
            }

            else if (winCond && sameCount == 4 && lastChoice == 2)
            {
                WinMessage.Content = "O is a Winner!";
            }
        }

        private void GameLogic(object sender, SelectionChangedEventArgs e)
        {
            ComboBox currCell = (ComboBox)sender;

            (byte, byte) coordinates = Coordinates(currCell);

            byte x = coordinates.Item1;
            byte y = coordinates.Item2;


            ComboBoxItem? choice = (ComboBoxItem)currCell.SelectedItem;

            currCell.IsEnabled = false;

            selectedCells++;
            
            if (choice.Content.ToString() == "X")
                board_Matrix[x, y] = 1;
            
            if (choice.Content.ToString() == "O")
                board_Matrix[x, y] = 2;

            if (x == y)
                mainDiagonal.Add(board_Matrix[x, y]);

            if (x + y == board_Matrix.GetLength(0) - 1)
            {
                antiDiagonal.Add(board_Matrix[x, y]);
            }

            bool winCond = true;


            byte lastChoice = 0;

            for (int j = 1; j < board_Matrix.GetLength(1); j++)
            {
                lastChoice = board_Matrix[x, j];

                if (!(board_Matrix[x, j] == board_Matrix[x, j - 1] && board_Matrix[x, j - 1] != 0))
                {
                    winCond = false;
                    sameCount = 0;
                }
                else
                {
                    winCond = true;
                    sameCount++;
                }
            }
            if (selectedCells == board_Matrix.GetLength(0) * board_Matrix.GetLength(1) && winCond == false)
                WinMessage.Content = "Draw!";
            else
                isWinner(winCond, sameCount, lastChoice);



            for (int i = 1; i < board_Matrix.GetLength(0); i++)
            {
                lastChoice = board_Matrix[i, y];

                if (!(board_Matrix[i, y] == board_Matrix[i - 1, y] && board_Matrix[i - 1, y] != 0))
                {
                    winCond = false;
                    sameCount = 0;
                }
                else
                {
                    winCond = true;
                    sameCount++;
                }
            }
            if (selectedCells == board_Matrix.GetLength(0) * board_Matrix.GetLength(1) && winCond == false)
                WinMessage.Content = "Draw!";
            else
                isWinner(winCond, sameCount, lastChoice);


            for (int i = 1; i < mainDiagonal.Count; i++)
            {
                lastChoice = mainDiagonal[i - 1];
                if (!((mainDiagonal[i] == 1 && mainDiagonal[i - 1] == 1) || (mainDiagonal[i] == 2 && mainDiagonal[i - 1] == 2)))
                {
                    winCond = false;
                    sameCount = 0;
                }
                else
                {
                    winCond = true;
                    sameCount++;
                }
            }
            if (selectedCells == board_Matrix.GetLength(0) * board_Matrix.GetLength(1) && winCond == false)
                WinMessage.Content = "Draw!";
            else
                isWinner(winCond, sameCount, lastChoice);

            for (int i = 1; i < antiDiagonal.Count; i++)
            {
                lastChoice = antiDiagonal[i - 1];
                if (!((antiDiagonal[i] == 1 && antiDiagonal[i - 1] == 1) || (antiDiagonal[i] == 2 && antiDiagonal[i - 1] == 2)))
                {
                    winCond = false;
                    sameCount = 0;
                }
                else
                {
                    winCond = true;
                    sameCount++;
                }
            }
            if (selectedCells == board_Matrix.GetLength(0) * board_Matrix.GetLength(1) && winCond == false)
                WinMessage.Content = "Draw!";
            else
                isWinner(winCond, sameCount, lastChoice);
        }
    }
}
