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

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        string current_str = "";
        bool isSpecialCharacter = false;
        String[] seperatorlist = new string[0] { };
      
        //just dog foo
        //This is a test
        public MainWindow()
        {
            InitializeComponent();
        }

        private void update(string current_str, string input)
        {
            this.current_str = current_str + input;
            display_output.Text = this.current_str;
            
            if (isSpecialCharacter)
            {
             
                string test = input;
                Array.Resize(ref this.seperatorlist, this.seperatorlist.Length+ 1);
                this.seperatorlist[this.seperatorlist.Length - 1] = input;
            }
        }
        private void _null_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "0");
            
        }
        private void eins_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "1");
        }

        private void zwei_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "2");
        }

        private void drei_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "3");
        }

        private void vier_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "4");
        }

        private void fünf_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "5");
        }

        private void sechs_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "6");
        }

        private void sieben_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "7");
        }

        private void acht_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "8");
        }

        private void neun_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, "9");
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.current_str = "";
            String[] empty = { };

            this.seperatorlist = empty;
            display_output.Text = this.current_str;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int text_length = this.current_str.Length - 1;
            if (text_length >= 0)
            {
                this.current_str = this.current_str.Remove(text_length);
                display_output.Text = this.current_str;
            }
            if (this.isSpecialCharacter)
            {
                this.seperatorlist = this.seperatorlist.Take(this.seperatorlist.Count() - 1).ToArray();
            }
        }

        private void komma_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = false;
            this.update(current_str, ",");
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = true;
            this.update(current_str, "-");
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = true;
            this.update(current_str, "+");
            
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            String[] seperator = { "+", "*", "/", "-" };
            Int32 max = 10;
            bool setSignbit = false;

            if (Convert.ToString(this.current_str[0]) == "-"){
                setSignbit = true;
            }
            String[] strlist = this.current_str.Split(seperator, max, StringSplitOptions.RemoveEmptyEntries);

            double erg = 0;
            int count = 0;
            string flag = "";
            foreach(String s in strlist)
            {
             
                if (this.seperatorlist.Length == 0)
                {
                    erg = Convert.ToDouble(s);
                    
                    return;
                }
                if (count == 0)
                {
                    erg = Convert.ToDouble(s);
                }
                
                
               else if (count >=1)
                {
                    
                    flag = this.seperatorlist[count-1];

                    switch (flag)
                    {
                        case "-":
                            erg =erg- Convert.ToDouble(s);
                            break;
                        case "+":
                            if (setSignbit)
                            {
                                erg -= Convert.ToDouble(s);
                            }
                            else
                                erg += Convert.ToDouble(s);
                            break;
                        case "*":
                            erg *= Convert.ToDouble(s);
                            break;
                        case "/":
                            erg /= Convert.ToDouble(s);
                            break;
                    }

                }
     
                count++;
            }
            this.current_str = Convert.ToString(erg);
            if (setSignbit)
            {
                this.current_str = this.current_str.Insert(0, "-");
            }
                
            display_output.Text = this.current_str;
            this.seperatorlist = new string[0] { };



        }
        private void mal_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = true;
            this.update(current_str, "*");
        }
        private void geteilt_Click(object sender, RoutedEventArgs e)
        {
            this.isSpecialCharacter = true;
            this.update(current_str, "/");
        }

        private void vorzeichen_Click(object sender, RoutedEventArgs e)
        {
            if (this.current_str.Substring(0, 1) != "-")
            {
                this.current_str = this.current_str.Insert(0, "-");
            }
            else if (this.current_str.Substring(0, 1) == "-")
            {
                this.current_str = this.current_str.Remove(0, 1);
            }
            display_output.Text = this.current_str;
        }

        
    }
}
