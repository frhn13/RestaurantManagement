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
using System.Windows.Shapes;

namespace RestaurantManagement
{
    public partial class Calculator : Window
    {
        string passedUsername;
        int maxLength = 10;
        char calcMode = 'N';

        public Calculator(string username)
        {
            InitializeComponent();
            passedUsername = username;
            calcModeBox.Text = String.Empty;
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "1";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "2";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "3";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "4";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "5";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "6";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "7";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "8";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength)
                currentContents.Text += "9";
        }

        private void Button_Click_Decimal(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text.Length < maxLength - 1 && !currentContents.Text.Contains(".") && currentContents.Text != String.Empty)
                currentContents.Text += ".";
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty)
            {
                switch (calcMode)
                {
                    case '+':
                        currentContents.Text = (Double.Parse(currentContents.Text) + Double.Parse(previousContents.Text)).ToString();
                        break;
                    case '-':
                        currentContents.Text = (Double.Parse(previousContents.Text) - Double.Parse(currentContents.Text)).ToString();
                        break;
                    case '*':
                        currentContents.Text = (Double.Parse(previousContents.Text) * Double.Parse(currentContents.Text)).ToString();
                        break;
                    case '/':
                        currentContents.Text = (Double.Parse(previousContents.Text) / Double.Parse(currentContents.Text)).ToString();
                        break;
                    default:
                        break;
                }
                previousContents.Text = String.Empty;
                calcMode = 'N';
            }
        }

        private void Button_Click_AC(object sender, RoutedEventArgs e)
        {
            currentContents.Text = String.Empty;
            previousContents.Text = String.Empty;
            calcMode = 'N';
            calcModeBox.Text = String.Empty;
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty)
            {
                if (previousContents.Text == String.Empty)
                    previousContents.Text = currentContents.Text;
                else
                    Calculate();
                currentContents.Text = String.Empty;
            }
            calcMode = '*';
            calcModeBox.Text = calcMode.ToString();
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty)
            {
                if (previousContents.Text == String.Empty)
                    previousContents.Text = currentContents.Text;
                else
                    Calculate();
                currentContents.Text = String.Empty;
            }
            calcMode = '/';
            calcModeBox.Text = calcMode.ToString();
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty) 
            {
                if (previousContents.Text == String.Empty)
                    previousContents.Text = currentContents.Text;
                else
                    Calculate();
                currentContents.Text = String.Empty;
            }
            calcMode = '+';
            calcModeBox.Text = calcMode.ToString();
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty)
            {
                if (previousContents.Text == String.Empty)
                    previousContents.Text = currentContents.Text;
                else
                    Calculate();
                currentContents.Text = String.Empty;
            }
            calcMode = '-';
            calcModeBox.Text = calcMode.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RestaurantMenu restaurantMenu = new RestaurantMenu(passedUsername);
            restaurantMenu.Show();
            this.Close();
        }

        private void Calculate()
        {
            switch (calcMode)
            {
                case '+':
                    previousContents.Text = (Double.Parse(currentContents.Text) + Double.Parse(previousContents.Text)).ToString();
                    break;
                case '-':
                    previousContents.Text = (Double.Parse(previousContents.Text) - Double.Parse(currentContents.Text)).ToString();
                    break;
                case '*':
                    previousContents.Text = (Double.Parse(previousContents.Text) * Double.Parse(currentContents.Text)).ToString();
                    break;
                case '/':
                    previousContents.Text = (Double.Parse(previousContents.Text) / Double.Parse(currentContents.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (currentContents.Text != String.Empty)
                currentContents.Text = currentContents.Text.Remove(currentContents.Text.Length - 1);
        }
    }
}
