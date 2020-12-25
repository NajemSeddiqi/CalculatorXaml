using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            ACBtn.Click += ACBtn_Click;
            negativeBtn.Click += NegativeBtn_Click;
            percentageBtn.Click += PercentageBtn_Click;
            equalsBtn.Click += EqualsBtn_Click;
            dotBtn.Click += DotBtn_Click;
        }

        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLbl.Content.ToString().Contains("."))
                resultLbl.Content = $"{resultLbl.Content}.";
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out double newNum))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNum);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNum);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNum);
                        break;
                }
            }

            resultLbl.Content = result.ToString();
        }

        private void PercentageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out double tempNum))
            {
                tempNum /= 100;
                if (lastNumber != 0)
                    tempNum *= lastNumber;
                resultLbl.Content = tempNum.ToString();
            }
        }

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLbl.Content = lastNumber.ToString();
            }
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLbl.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out lastNumber))
                resultLbl.Content = "0";

            selectedOperator = GetOperator(sender);
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLbl.Content.ToString() == "0")
                resultLbl.Content = $"{selectedValue}";
            else
                resultLbl.Content = $"{resultLbl.Content}{selectedValue}";
        }

        private SelectedOperator GetOperator(object sender)
        {
            var btn = (Button)sender;

            return btn.Name switch
            {
                "multiplicationBtn" => SelectedOperator.Multiplication,
                "divisionBtn" => SelectedOperator.Division,
                "additionBtn" => SelectedOperator.Addition,
                "subtractionBtn" => SelectedOperator.Subtraction,
                _ => SelectedOperator.Addition,
            };
        }


        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        public static class SimpleMath
        {
            public static double Add(double n1, double n2) => n1 + n2;
            public static double Subtract(double n1, double n2) => n1 - n2;
            public static double Multiply(double n1, double n2) => n1 * n2;
            public static double Divide(double n1, double n2)
            {
                if (n2 == 0)
                {
                    MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }

                return n1 / n2;
            }
        }

    }
}
