using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        double equal; // Zmienna przechowująca aktualny wynik
        bool operandPressed; // Flaga informująca, czy został wciśnięty operator 
        string action; //// Zmienna przechowująca ostatni wciśnięty operator
        List<string> operands; //// Lista zawierająca dostępne operatory

        public MainWindow()
        {
            InitializeComponent();
            equal = 0.0;
            operandPressed = false;
            action = "";
            operands = new List<string> { "+", "-", "*", "/", "=", "sin", "cos", "tan", "sqrt", "log", "^", "hyp", "sec", "csc", "cot",  "rand", "dms", "deg" };

        }
        private void btnSpecial_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string content = button.Content.ToString();

            switch (button.Name)
            {
                case "PiButton":
                    ekran.Text += Math.PI.ToString();
                    break;

                case "EButton":
                    ekran.Text += Math.E.ToString();
                    break;

                case "SecondPowerButton":
                    // This assumes the previous number entered will be raised to the power of 2
                    double numToSquare;
                    if (double.TryParse(ekran.Text, out numToSquare))
                    {
                        ekran.Text = (numToSquare * numToSquare).ToString();
                    }
                    break;

                case "OpenBracketButton":
                    ekran.Text += "(";
                    break;

                case "CloseBracketButton":
                    ekran.Text += ")";
                    break;

                default:
                    break;
            }
        }

        private void BracketButton_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzamy, który przycisk został naciśnięty
            var button = (Button)sender;

            // Dodajemy odpowiedni nawias do textBox
            ekran.Text += button.Content.ToString();
        }



        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ekran.Text = ""; // Czyści zawartość TextBox o nazwie "ekran", czyli ekran kalkulatora
            equal = 0.0; // Resetuje zmienną "equal" przechowującą aktualny wynik na wartość 0.0
            operandPressed = false; // Ustawia flagę "operandPressed" na false, co oznacza, że żaden operator nie został jeszcze wciśnięty
            action = ""; // Resetuje zmienną "action", która przechowuje ostatnio wciśnięty operator na pustą wartość
        }

        // dodaję nową metodę do obsługi wciśnięcia przycisku "C"
        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                btnClear_Click(sender, e);
            }
        }

        private void btnnumber_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).Content.ToString();
            if (operandPressed && !operands.Contains(data))
            {
                operandPressed = false;
                ekran.Text = data;
                return;
            }

            if (operands.Contains(data))
            {
                if (action == "=")
                {
                    equal = Convert.ToDouble(ekran.Text);
                }
                else
                {
                    switch (action)
                    {
                        case "+": equal += Convert.ToDouble(ekran.Text); break;
                        case "-": equal -= Convert.ToDouble(ekran.Text); break;
                        case "*": equal *= Convert.ToDouble(ekran.Text); break;
                        case "/": equal /= Convert.ToDouble(ekran.Text); break;
                        case "sin": equal = Math.Sin(Convert.ToDouble(ekran.Text)); break;
                        case "cos": equal = Math.Cos(Convert.ToDouble(ekran.Text)); break;
                        case "tan": equal = Math.Tan(Convert.ToDouble(ekran.Text)); break;
                        case "sqrt": equal = Math.Sqrt(Convert.ToDouble(ekran.Text)); break;
                        case "log": equal = Math.Log(Convert.ToDouble(ekran.Text)); break;
                        case "^": equal = Math.Pow(equal, Convert.ToDouble(ekran.Text)); break;
                        case "hyp": equal = Math.Sinh(Convert.ToDouble(ekran.Text)); break;
                        case "sec": equal = 1 / Math.Cos(Convert.ToDouble(ekran.Text)); break;
                        case "csc": equal = 1 / Math.Sin(Convert.ToDouble(ekran.Text)); break;
                        case "cot": equal = 1 / Math.Tan(Convert.ToDouble(ekran.Text)); break;
                        case "rand": equal = new Random().NextDouble(); break;
                        case "dms": equal = (Math.Floor(equal) + Math.Floor((equal % 1) * 60) / 100 + ((equal % 1) * 60 % 1) * 60 / 10000); break;
                        case "deg": equal = (Math.Floor(equal) + (equal % 1 * 100 / 60)); break;

                        default: equal = Convert.ToDouble(ekran.Text); break;
                    }
                }
                if (data != "=") action = data;

                ekran.Text = equal.ToString();
                operandPressed = true;
            }
            else
            {
                ekran.Text += data;
            }
        }


        private void OK_Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                ((Button)sender).Content = "WITAJ";
            }
            if (e.Key == Key.D)
            {
                ((Button)sender).Content = "ŻEGNAJ";
            }
        }

        private void etykieta1_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString();
            if (key.Length == 2 && key[0] == 'D' && char.IsDigit(key[1]))
            {
                ekran.Text += key[1];
            }
            else if (key == "Add") // +
            {
                btnnumber_Click(OK_Button_Copy8, null);
            }
            else if (key == "Subtract") // -
            {
                btnnumber_Click(OK_Button_Copy9, null);
            }
            else if (key == "Multiply") // *
            {
                btnnumber_Click(OK_Button_Copy13, null);
            }
            else if (key == "Divide") // /
            {
                btnnumber_Click(OK_Button_Copy12, null);
            }
            else if (key == "Enter" || key == "Return") // =
            {
                btnnumber_Click(OK_Button_Copy10, null);
            }
            else if (key == "S") // sin
            {
                btnnumber_Click(OK_Button_Copy14, null);
            }
            else if (key == "C") // cos
            {
                btnnumber_Click(OK_Button_Copy15, null);
            }
            else if (key == "T") // tan
            {
                btnnumber_Click(OK_Button_Copy16, null);
            }
            else if (key == "R") // sqrt
            {
                btnnumber_Click(OK_Button_Copy17, null);
            }
            else if (key == "L") // log
            {
                btnnumber_Click(OK_Button_Copy18, null);
            }
            else if (key == "P") // pow
            {
                btnnumber_Click(OK_Button_Copy19, null);
            }
        }
    }

}


