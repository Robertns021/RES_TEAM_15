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
using DAKlijent;

namespace Client1
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            View newWindow = new View();
            newWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccessKlijent k = new DataAccessKlijent();
            if(textBox.Text.Trim().Equals("") || textBox1.Text.Trim().Equals("") || textBox2.Text.Trim().Equals(""))
                MessageBox.Show("Podaci nisu dobro popunjeni", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                k.Upisi(textBox2.Text,Convert.ToDateTime(textBox.Text), Convert.ToDouble(textBox1.Text));
            //todo
            //Slanje podataka
        }
    }
}
