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

namespace WPF_First
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textKurs.Text = "1,09";
        }

        private void Dollar_Click(object sender, RoutedEventArgs e)
        {
            double kurs = Convert.ToDouble(textKurs.Text);
            if (Convert.ToDouble(textKurs.Text) <= 0)
            {
                textKurs.Text = "Please enter a valid exchangerate!";
            }
            else if (textDollar.Text != "")
            {
                double dollar = Convert.ToDouble(textDollar.Text);
                double euro = dollar / kurs;
                textEuro.Text = Convert.ToString(Math.Round(euro, 3));
            }
            else if (textDollar.Text == "")
                errorText.Text = "Please enter a value";
            
        }

        private void buttonEuro_Click(object sender, RoutedEventArgs e)
        {
            double kurs = Convert.ToDouble(textKurs.Text);
            if (Convert.ToDouble(textKurs.Text) <= 0)
            {
                textKurs.Text = "Please enter a valid exchangerate!";
            }
            else if (textEuro.Text != "")
            {
                double euro = Convert.ToDouble(textEuro.Text);
                double dollar = kurs * euro;
                textDollar.Text = Convert.ToString(Math.Round(dollar,3));
            }
            else if (textDollar.Text == "")
            {
                errorText.Text = "Please enter a value";
            }
        }
    }
}
