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

        private static readonly Regex _addressPattern = new Regex("0[xX][0-9a-fA-F]+");
        private static readonly Regex _onlyNums = new Regex("[^0-9.-]+");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Field.Text = MemoryReader.Read(Convert.ToInt32(PIDTB.Text), Convert.ToInt32(AddressTB.Text), Convert.ToInt32(CountTB.Text));
        }




        
    
        private static bool IsTextAllowed(string text)
        {
            return !_onlyNums.IsMatch(text);
        }
        private static bool IsAddressAllowed(string text)
        {
            return !_addressPattern.IsMatch(text);
        }


        private void PIDTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void AddressTB_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsAddressAllowed(e.Text);
        }
    }
}
