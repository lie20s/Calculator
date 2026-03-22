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
using CalcLIB;
namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double currentValue = 0;
        private string currentOperator = "";
        private bool isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
            txtDisplay.Text = "0";
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (isNewEntry)
            {
                txtDisplay.Text = number;
                isNewEntry = false;
            }
            else
            {
                if (txtDisplay.Text == "0")
                    txtDisplay.Text = number;
                else
                    txtDisplay.Text += number;
            }
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string op = button.Content.ToString();

            if (!isNewEntry && currentOperator != "")
            {
                Calculate();
            }

            currentValue = double.Parse(txtDisplay.Text);
            currentOperator = op;
            isNewEntry = true;
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (currentOperator != "")
            {
                Calculate();
                currentOperator = "";
                isNewEntry = true;
            }
        }
        private void Calculate()
        {
            try
            {
                double secondNumber = double.Parse(txtDisplay.Text);
                double result = 0;
                char operation = currentOperator[0];
                result = Class1.Execute(currentValue, operation, secondNumber);

                txtDisplay.Text = result.ToString();
                currentValue = result;
            }
            catch (DivideByZeroException)
            {
                txtDisplay.Text = "Ошибка: деление на 0";
                currentValue = 0;
                currentOperator = "";
                isNewEntry = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Ошибка";
                currentValue = 0;
                currentOperator = "";
                isNewEntry = true;
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            currentOperator = "";
            isNewEntry = true;
        }
        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (isNewEntry)
            {
                txtDisplay.Text = "0,";
                isNewEntry = false;
            }
            else if (!txtDisplay.Text.Contains(","))
            {
                txtDisplay.Text += ",";
            }
        }
    }
}