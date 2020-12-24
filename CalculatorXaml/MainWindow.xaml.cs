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
                    default:
                        break;
                }
            }

            resultLbl.Content = result.ToString();
        }

        private void PercentageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLbl.Content = lastNumber.ToString();
            }
        }

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLbl.Content = lastNumber.ToString();
            }
        }
        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLbl.Content = "0";
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLbl.Content.ToString(), out lastNumber))
            {
                resultLbl.Content = "0";
            }

            if (sender == multiplicationBtn)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionBtn)
                selectedOperator = SelectedOperator.Division;
            if (sender == additionBtn)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractionBtn)
                selectedOperator = SelectedOperator.Subtraction;
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLbl.Content.ToString() == "0")
                resultLbl.Content = $"{selectedValue}";
            else
                resultLbl.Content = $"{resultLbl.Content}{selectedValue}";
        }

    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2) => n1 + n2;
        public static double Subtract(double n1, double n2) => n1 - n2;
        public static double Multiply(double n1, double n2) => n1 * n2;
        public static double Divide(double n1, double n2) => n1 / n2;
    }
}
