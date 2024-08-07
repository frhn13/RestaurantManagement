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
            int total = 0;
            int temp = 0;

            total += Int32.Parse(cheeseburgerBox.Text) * 8;


            afterVatBlock.Text = $"£{total.ToString()}";
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