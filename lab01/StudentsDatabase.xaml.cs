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

namespace Lab01_OP
{
    /// <summary>
    /// Interaction logic for StudentsDatabase.xaml
    /// </summary>
    public partial class StudentsDatabase : Window
    {
        static Dictionary<int, StudentDatabaseClass> keyValuePairs = new Dictionary<int, StudentDatabaseClass>();
        static List<string> stringData = new List<string>();

        public StudentsDatabase()
        {
            InitializeComponent();
        }

        private void Adding(object sender, RoutedEventArgs e)
        {
            StudentDatabaseClass student = new StudentDatabaseClass(int.Parse(IDBox.Text), SNP_Box.Text, Number_Box.Text);
            StreamWriter streamWriter = new StreamWriter(@"studentsdata.txt");

            string entry = student.AnEntry(student.getID(), student.getName(), student.getPhoneNumber());
            stringData.Add(entry);

            if (!keyValuePairs.ContainsKey(int.Parse(IDBox.Text)))
            {
                keyValuePairs.Add(int.Parse(IDBox.Text), student);
                using (streamWriter)
                {
                    foreach(string key in stringData)
                        streamWriter.WriteLine(key);
                }
            }
            streamWriter.Close();
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Close();
            mw.Show();
        }

        private void Removing(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (KeyValuePair<int, StudentDatabaseClass> pair in keyValuePairs)
            {
                if (pair.Key.ToString() == IDBox.Text)
                {
                    stringData.RemoveAt(i);
                    keyValuePairs.Remove(pair.Key);
                    i = 0;
                }
                    
                i++;
            }
            
            StreamWriter streamWriter = new StreamWriter(@"studentsdata.txt");
            foreach (string key in stringData)
                streamWriter.WriteLine(key);

            streamWriter.Close();
        }
    }
}