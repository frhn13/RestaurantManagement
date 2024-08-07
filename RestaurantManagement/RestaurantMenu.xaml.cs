using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace RestaurantManagement
{
    public partial class RestaurantMenu : Window
    {
        public RestaurantMenu()
        {
            InitializeComponent();
        }

        private void Total_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            double foodTotal = 0;
            double drinksTotal = 0;

            total += double.Parse(cheeseburgerBox.Text) * 8;
            total += double.Parse(beefburgerBox.Text) * 10;
            total += double.Parse(steakBox.Text) * 10.5;
            total += double.Parse(sausagesBox.Text) * 8;
            total += double.Parse(chickenBurgerBox.Text) * 11;
            total += double.Parse(veggieBurgerBox.Text) * 9;
            total += double.Parse(orangeJuiceBox.Text) * 2;
            total += double.Parse(appleJuiceBox.Text) * 2;
            total += double.Parse(teaBox.Text) * 2.5;
            total += double.Parse(coffeeBox.Text) * 3;
            total += double.Parse(colaBox.Text) * 2;
            total += double.Parse(lemonadeBox.Text) * 2.5;

            foodTotal += double.Parse(cheeseburgerBox.Text) * 8;
            foodTotal += double.Parse(beefburgerBox.Text) * 10;
            foodTotal += double.Parse(steakBox.Text) * 10.5;
            foodTotal += double.Parse(sausagesBox.Text) * 8;
            foodTotal += double.Parse(chickenBurgerBox.Text) * 11;
            foodTotal += double.Parse(veggieBurgerBox.Text) * 9;

            drinksTotal += double.Parse(orangeJuiceBox.Text) * 2;
            drinksTotal += double.Parse(appleJuiceBox.Text) * 2;
            drinksTotal += double.Parse(teaBox.Text) * 2.5;
            drinksTotal += double.Parse(coffeeBox.Text) * 3;
            drinksTotal += double.Parse(colaBox.Text) * 2;
            drinksTotal += double.Parse(lemonadeBox.Text) * 2.5;

            foodCostBlock.Text = $"Cost of Food: £{Math.Round(foodTotal, 2)}";
            drinksCostBlock.Text = $"Cost of Drinks: £{Math.Round(drinksTotal, 2)}";
            beforeVatBlock.Text = $"Total before VAT: £{Math.Round(total * 0.8, 2)}";
            vatBlock.Text = $"VAT: £{Math.Round(total * 0.2, 2)}";
            afterVatBlock.Text = $"Total after VAT: £{Math.Round(total, 2)}";

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            cheeseburgerBox.Text = "0";
            chickenBurgerBox.Text = "0";
            beefburgerBox.Text = "0";
            sausagesBox.Text = "0";
            steakBox.Text = "0";
            veggieBurgerBox.Text = "0";

            appleJuiceBox.Text = "0";
            orangeJuiceBox.Text = "0";
            coffeeBox.Text = "0";
            colaBox.Text = "0";
            teaBox.Text = "0";
            lemonadeBox.Text = "0";

            foodCostBlock.Text = $"Cost of Food:";
            drinksCostBlock.Text = $"Cost of Drinks:";
            beforeVatBlock.Text = $"Total before VAT:";
            vatBlock.Text = $"VAT:";
            afterVatBlock.Text = $"Total after VAT:";
        }

        private void NumberInputValidation(object sender, TextCompositionEventArgs e) // Checks amount entered is a number
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void Box_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)  // Defaults value to 0 if box is blank upon clicking off it
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox box = (TextBox)sender;
                if (box.Text == "" || box.Text == string.Empty)
                {
                    ((TextBox)sender).Text = "0";
                }
            }
        }
    }
}