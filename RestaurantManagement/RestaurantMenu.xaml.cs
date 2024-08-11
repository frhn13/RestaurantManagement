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
using System.Collections;

namespace RestaurantManagement
{
    public partial class RestaurantMenu : Window
    {
        List<List<string>> menuItems = new List<List<string>>();
        List<double> itemTotals = new List<double>();
        double total;
        double foodTotal;
        double drinksTotal;

        public RestaurantMenu()
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                menuItems.Add(new List<String>());  // Sets up 2d list to hold items later
                itemTotals.Add(0);
            }
        }

        private void Total_Click(object sender, RoutedEventArgs e)
        {
            total = 0;
            foodTotal = 0;
            drinksTotal = 0;

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

        private void Receipt_Click(object sender, RoutedEventArgs e)
        {
            menuItems[0].Add("Cheeseburger");
            menuItems[0].Add(cheeseburgerBox.Text);
            menuItems[1].Add("Beefburger");
            menuItems[1].Add(beefburgerBox.Text);
            menuItems[2].Add("Steak");
            menuItems[2].Add(steakBox.Text);
            menuItems[3].Add("Sausages");
            menuItems[3].Add(sausagesBox.Text);
            menuItems[4].Add("Chicken Burger");
            menuItems[4].Add(chickenBurgerBox.Text);
            menuItems[5].Add("Veggie Burger");
            menuItems[5].Add(veggieBurgerBox.Text);

            menuItems[6].Add("Orange Juice");
            menuItems[6].Add(orangeJuiceBox.Text);
            menuItems[7].Add("Apple Juice");
            menuItems[7].Add(appleJuiceBox.Text);
            menuItems[8].Add("Tea");
            menuItems[8].Add(teaBox.Text);
            menuItems[9].Add("Coffee");
            menuItems[9].Add(coffeeBox.Text);
            menuItems[10].Add("Cola");
            menuItems[10].Add(colaBox.Text);
            menuItems[11].Add("Lemonade");
            menuItems[11].Add(lemonadeBox.Text);

            itemTotals[0] = (double.Parse(cheeseburgerBox.Text) * 8);
            itemTotals[1] = (double.Parse(beefburgerBox.Text) * 10);
            itemTotals[2] = (double.Parse(steakBox.Text) * 10.5);
            itemTotals[3] = (double.Parse(sausagesBox.Text) * 8);
            itemTotals[4] = (double.Parse(chickenBurgerBox.Text) * 11);
            itemTotals[5] = (double.Parse(veggieBurgerBox.Text) * 9);
            itemTotals[6] = (double.Parse(orangeJuiceBox.Text) * 2);
            itemTotals[7] = (double.Parse(appleJuiceBox.Text) * 2);
            itemTotals[8] = (double.Parse(teaBox.Text) * 2.5);
            itemTotals[9] = (double.Parse(coffeeBox.Text) * 3);
            itemTotals[10] = (double.Parse(colaBox.Text) * 2);
            itemTotals[11] = (double.Parse(lemonadeBox.Text) * 2.5);

            Receipt receipt = new Receipt(menuItems, itemTotals, foodTotal, drinksTotal, total);
            receipt.Show();
            this.Close();
        }

        private void Sign_Out_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}