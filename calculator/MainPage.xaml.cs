using System;
using Microsoft.Maui.Controls;

namespace calculator
{
    public partial class MainPage : ContentPage
    {
        private string currentEntry = "";
        private string operatorUsed = "";
        private double firstNumber = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentEntry += button.Text;
            ResultLabel.Text = currentEntry;
        }

        void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (!string.IsNullOrEmpty(currentEntry))
            {
                firstNumber = Convert.ToDouble(currentEntry);
                operatorUsed = button.Text;
                HistoryLabel.Text += $"{firstNumber} {operatorUsed} ";
                currentEntry = "";
            }
        }

        void OnClearClicked(object sender, EventArgs e)
        {
            currentEntry = "";
            firstNumber = 0;
            operatorUsed = "";
            ResultLabel.Text = "0";
            HistoryLabel.Text = ""; 
        }

        void OnEqualsClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentEntry) && !string.IsNullOrEmpty(operatorUsed))
            {
                double secondNumber = Convert.ToDouble(currentEntry);
                double result = 0;

                switch (operatorUsed)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "×":
                        result = firstNumber * secondNumber;
                        break;
                    case "÷":
                        result = (secondNumber != 0) ? firstNumber / secondNumber : 0;
                        break;
                    default:
                        ResultLabel.Text = "Hata";
                        return;
                }

                HistoryLabel.Text += $"{secondNumber} = {result}\n";


                ResultLabel.Text = result.ToString();
                currentEntry = result.ToString();
                firstNumber = result;
                operatorUsed = "";
            }
        }
    }
}
