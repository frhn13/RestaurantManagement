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
        string passedUsername;
        public PastReceipts(string username, string[] receipts)
        {
            InitializeComponent();

            passedUsername = username;
            for (int x=0; x < receipts.Length; x++)
            {
                string[] fields = receipts[x].Split(',');
                if (fields[0].Equals(username))
                {
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
                        Text = $"Cost of Food: £{fields[2]} " +
                        $"\n Cost of Drinks: £{fields[3]} \n Total before VAT: £{Math.Round(Convert.ToDouble(fields[1]) * 0.8, 2)} " +
                        $"\n VAT: £{Math.Round(Convert.ToDouble(fields[1]) * 0.2, 2)} \n Total Cost: £{fields[1]}",
                        FontSize = 20,  // Styled the text as well 
                        Margin = new Thickness(5, 5, 5, 5),
                        FontFamily = new FontFamily("Georgia"),
                        TextAlignment = TextAlignment.Center
                    });
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RestaurantMenu restaurantMenu = new RestaurantMenu(passedUsername);
            restaurantMenu.Show();
            this.Close();
        }
    }
}
