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
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace TermWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            FieldData.Text = MemoryReader.ReadData(Convert.ToInt32(PIDTB.Text), Convert.ToInt32(AddressTB.Text,16), Convert.ToInt32(CountTB.Text));
            FieldMemory.Text = MemoryReader.Read(Convert.ToInt32(PIDTB.Text), Convert.ToInt32(AddressTB.Text, 16), Convert.ToInt32(CountTB.Text));
        }
    }
}
