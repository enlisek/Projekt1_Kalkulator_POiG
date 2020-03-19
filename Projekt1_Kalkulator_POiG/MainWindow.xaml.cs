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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double number1 = 0;
        double number2 = 0;
        string operation = "";
        int sgn = 0;
        int point = 0;
        string ef = "";
        decimal wynik = 0;
        decimal n1dec = 0;
        decimal n2dec = 0;



        public MainWindow()
        {
            InitializeComponent();
        }


        private void meth(int number)
        {
            if (operation == "" && (Math.Floor(number1)).ToString().Length + point < 14)
            {
                if (point == 0)
                {
                    if (number1 != 0)
                    {
                        sgn = Math.Sign(number1);
                    }
                    else
                    {
                        sgn = 1;
                    }
                    number1 = sgn * (Math.Abs(number1) * 10 + number);
                    TextBox1.Text = number1.ToString();
                }
                else
                {
                    if (number1 != 0)
                    {
                        sgn = Math.Sign(number1);
                    }
                    else
                    {
                        sgn = 1;
                    }
                    number1 = sgn * (Math.Abs(number1) + number / (Math.Pow(10, point)));

                    ef = "F" + point.ToString();
                    TextBox1.Text = number1.ToString(ef);
                    point += 1;


                }


            }
            else if (operation != "" && (Math.Floor(number2)).ToString().Length + point < 14)
            {
                if (point == 0)
                {
                    if (number2 != 0)
                    {
                        sgn = Math.Sign(number2);
                    }
                    else
                    {
                        sgn = 1;
                    }
                    number2 = sgn * (Math.Abs(number2) * 10 + number);
                    TextBox1.Text = (number2).ToString();
                }
                else
                {
                    if (number2 != 0)
                    {
                        sgn = Math.Sign(number2);
                    }
                    else
                    {
                        sgn = 1;
                    }
                    number2 = sgn * (Math.Abs(number2) + number / (Math.Pow(10, point)));

                    ef = "F" + point.ToString();
                    TextBox1.Text = number2.ToString(ef);
                    point += 1;
                }
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            meth(7);
        }
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            meth(8);
        }
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            meth(9);
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            meth(4);
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            meth(5);
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            meth(6);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            meth(1);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            meth(2);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            meth(3);
        }
        private void button0_Click(object sender, RoutedEventArgs e)
        {
            meth(0);
        }

        private void buttonPl_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operation = "+";
                TextBox1.Text = "0";
                point = 0;
            }
            else
            {
                if (number2 != 0)
                {
                    buttonEq_Click(sender, e);
                    operation = "+";
                    TextBox1.Text = "0";
                    point = 0;
                }

            }
        }

        private void buttonSub_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operation = "-";
                TextBox1.Text = "0";
                point = 0;
            }
            else
            {
                if (number2 != 0)
                {
                    buttonEq_Click(sender, e);
                    operation = "-";
                    TextBox1.Text = "0";
                    point = 0;
                }

            }
        }

        private void buttonMul_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operation = "*";
                TextBox1.Text = "0";
                point = 0;
            }
            else
            {

                buttonEq_Click(sender, e);
                operation = "*";
                TextBox1.Text = "0";
                point = 0;
            }
        }

        private void buttonDiv_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operation = "/";
                TextBox1.Text = "0";
                point = 0;
            }
            else
            {
                if (number2 != 0)
                {
                    buttonEq_Click(sender, e);
                    operation = "/";
                    TextBox1.Text = "0";
                    point = 0;
                }

            }
        }

        private void buttonEq_Click(object sender, RoutedEventArgs e)
        {
            if (operation != "")
            {
                n1dec = Convert.ToDecimal(number1);
                n2dec = Convert.ToDecimal(number2);

                switch (operation)
                {
                    case "+":
                        wynik = n1dec + n2dec;

                        number1 = Convert.ToDouble(wynik);
                        wynik = Convert.ToDecimal(number1);
                        TextBox1.Text = wynik.ToString();
                        break;
                    case "-":
                        wynik = n1dec - n2dec;
                        number1 = Convert.ToDouble(wynik);
                        wynik = Convert.ToDecimal(number1);
                        TextBox1.Text = wynik.ToString();

                        break;
                    case "*":
                        wynik = n1dec * n2dec;
                        number1 = Convert.ToDouble(wynik);
                        wynik = Convert.ToDecimal(number1);
                        TextBox1.Text = wynik.ToString();

                        break;
                    case "/":
                        if (n2dec != 0)
                        {
                            wynik = n1dec / n2dec;
                            number1 = Convert.ToDouble(wynik);
                            wynik = Convert.ToDecimal(number1);
                            TextBox1.Text = wynik.ToString();

                            break;
                        }
                        else
                        {
                            TextBox1.Text = "Error";
                            number1 = 0;
                            break;
                        }

                }
                if (number1.ToString().Length > 14)
                {
                    if (Math.Abs(number1) < 100000000000000)
                    {
                        number1 = Convert.ToDouble(Convert.ToDecimal(number1).ToString().Substring(0, 14));
                    }
                    else
                    {
                        number1 = 0;
                    }

                }

                number2 = 0;
                point = 0;
                while (number1 * Math.Pow(10, point) != Math.Floor(number1 * Math.Pow(10, point)))
                    point++;
                if (point > 0)
                {
                    point += 1;
                }
                operation = "";
            }
        }

        private void buttonPM_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= -1;
                TextBox1.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                TextBox1.Text = number2.ToString();
            }
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            point = 0;
            TextBox1.Text = "0";
        }

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }
            point = 0;
            TextBox1.Text = "0";

        }

        private void buttonDEL_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                if (number1 != 0)
                {
                    sgn = Math.Sign(number1);
                }
                else
                    sgn = 1;

                if (point == 0)
                {

                    number1 = sgn * (Math.Floor(Math.Abs(number1) / 10));
                    TextBox1.Text = number1.ToString();
                }
                else if (point == 1)
                {
                    point = 0;
                }
                else
                {

                    point -= 1;


                    number1 = sgn * (Math.Floor(Math.Abs(number1) * Math.Pow(10, point - 1)) / Math.Pow(10, point - 1));
                    // precision = 0;
                    //while (number1*Math.Pow(10, precision) !=Math.Floor(number1 * Math.Pow(10, precision)))
                    //    precision++;
                    // number1 = Math.Floor(number1 * Math.Pow(10, precision-1)) / Math.Pow(10, precision-1);
                    // point -= 1;
                    ef = "F" + (point - 1).ToString();
                    TextBox1.Text = number1.ToString(ef);
                    if (point == 1)
                    {
                        point = 0;
                    }

                }

            }
            else
            {
                if (number2 != 0)
                {
                    sgn = Math.Sign(number2);
                }
                else
                    sgn = 1;

                if (point == 0)
                {
                    number2 = sgn * (Math.Floor(Math.Abs(number2) / 10));

                    TextBox1.Text = number2.ToString();
                }
                else if (point == 1)
                {
                    point = 0;
                }
                else
                {

                    point -= 1;


                    number2 = sgn * (Math.Floor(Math.Abs(number2) * Math.Pow(10, point - 1)) / Math.Pow(10, point - 1));
                    ef = "F" + (point - 1).ToString();
                    TextBox1.Text = number2.ToString(ef);
                    if (point == 1)
                    {
                        point = 0;
                    }



                }
            }
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            if (point == 0)
            {
                point = 1;
            }
            if (operation == "" && point == 1)
            {
                ef = "F" + point.ToString();
                TextBox1.Text = number1.ToString(ef);
            }
            if (operation != "" && point == 1)
            {
                ef = "F" + point.ToString();
                TextBox1.Text = number2.ToString(ef);
            }

        }



    }
}
