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

namespace Temperaturrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int type = 1;

        public MainWindow()
        {
            InitializeComponent();

        }

        private bool Check_temp_input(string input)
        {
            if (input != "")
            {
                return true;
            }
            else
            {
                text_legend1.Text = "Bitte geben Sie zunächst eine Temperatur ein!";
                return false;
            }
                
        }

        private void buttonCelsius_Checked(object sender, RoutedEventArgs e)
        {
            type = 1;
            this.update();
        }

        private void buttonFahrenheit_Checked(object sender, RoutedEventArgs e)
        {
            type = 2;
            this.update();
        }

        private void buttonKelvin_Checked(object sender, RoutedEventArgs e)
        {
            type = 3;
            this.update();
        }

        private void update()
        {
            string input;
            try
            {
               input = inp_temp.Text;
            }
            catch (System.NullReferenceException)
            {
                return;
            }


            if (!this.Check_temp_input(input))
            {
                return;
            }
            
            
            if (type == 1)
            {
 
                double celsius = 0;
                double fahrenheit = 0;
                double kelvin = 0;

                celsius = Convert.ToDouble(input);
                unit.Text = "°C";
                //(0 °C × 9/5) + 32 = 32 °F
                fahrenheit = celsius * (9 / 5) + 32;
                kelvin = celsius + 273.15;

                text_legend1.Text = "Calculated Temperatures: ";
                unity1.Text = Convert.ToString(Math.Round(fahrenheit, 4)) + " °F";
                unity2.Text = Convert.ToString(Math.Round(kelvin, 4)) + " K"; 
            }
            else if (type == 2)
            {
              
                double celsius = 0;
                double fahrenheit = 0;
                double kelvin = 0;

                celsius = Convert.ToDouble(input);
                unit.Text = "°F";
                //(32 °F − 32) × 5 / 9 = 0 °C
                
                celsius = (fahrenheit-32)*5 / 9;
                kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;

                text_legend1.Text = "Calculated Temperatures: ";
                unity1.Text = Convert.ToString(Math.Round(kelvin, 4)) + " K";
                unity2.Text = Convert.ToString(Math.Round(celsius, 4)) + " °C";  
            
            }
            else if (type == 3)
            {
                double celsius = 0;
                double fahrenheit = 0;
                double kelvin = 0;

                celsius = Convert.ToDouble(input);
                unit.Text = "K";
                //(0 K − 273,15) × 9/5 + 32 = -459,7 °F
                fahrenheit = (kelvin - 273.15) * 9 / 5 + 32;
                celsius = kelvin - 273.15;

                text_legend1.Text = "Calculated Temperatures: ";
                unity1.Text = Convert.ToString(Math.Round(fahrenheit, 4)) + " °F";
                unity2.Text = Convert.ToString(Math.Round(celsius, 4)) + " °C";

                
            }
        }
        private void inp_temp_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.update();
        }
    }
}
