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
    public partial class PastReceipts : Window
    {
        public PastReceipts(string[] receipts)
        {
            InitializeComponent();

            for (int x=0; x < receipts.Length; x++)
            {
                string[] fields = receipts[x].Split(',');
                myStackPanelPastReceipts.Children.Add(new TextBlock()
                {
                    Text = $"Receipt {x + 1}",
                    FontSize = 30,  // Styled the text as well 
                    Margin = new Thickness(5, 20, 5, 5),
                    FontFamily = new FontFamily("Georgia"),
                    TextAlignment = TextAlignment.Center,
                    FontWeight = FontWeights.Bold,
                });
                myStackPanelPastReceipts.Children.Add(new TextBlock()
                {
                    Text = $"Total Cost: £{fields[0]} \n Cost of Food: £{fields[1]} \n Cost of Drinks: £{fields[2]}",
                    FontSize = 20,  // Styled the text as well 
                    Margin = new Thickness(5, 5, 5, 5),
                    FontFamily = new FontFamily("Georgia"),
                    TextAlignment = TextAlignment.Center
                });
            }
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RestaurantMenu restaurantMenu = new RestaurantMenu();
            restaurantMenu.Show();
            this.Close();
        }
    }
}
