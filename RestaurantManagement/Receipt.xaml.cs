﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
    public partial class Receipt : Window
    {
        double savedTotal;
        double savedFoodTotal;
        double savedDrinksTotal;
        string passedUsername;

        public Receipt(string username, List<List<string>> menuItems, List<double> itemTotals, double foodTotal, double drinksTotal, double total)
        {
            InitializeComponent();
            savedTotal = total;
            savedFoodTotal = foodTotal;
            savedDrinksTotal = drinksTotal;
            passedUsername = username;
            for (int x=0; x < menuItems.Count; x++)
            {
                myStackPanel.Children.Add(new TextBlock()
                {
                    Text = $"{menuItems[x][0]}: {menuItems[x][1]} - £{itemTotals[x]}",  // Text blocks made in the C# code
                    FontSize = 20,  // Styled the text as well 
                    Margin = new Thickness(5, 5, 5, 5),
                    FontFamily = new FontFamily("Georgia"),
                    TextAlignment = TextAlignment.Center
                }); ; 
            }
            myStackPanel.Children.Add(new TextBlock()
            {
                Text = $"Total before VAT: £{Math.Round(total * 0.8, 2)}",  // Text blocks made in the C# code
                FontSize = 20,
                Margin = new Thickness(5, 5, 5, 5),
                FontFamily = new FontFamily("Georgia"),
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            });
            myStackPanel.Children.Add(new TextBlock()
            {
                Text = $"VAT: £{Math.Round(total * 0.2, 2)}",  // Text blocks made in the C# code
                FontSize = 20,
                Margin = new Thickness(5, 5, 5, 5),
                FontFamily = new FontFamily("Georgia"),
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            });
            myStackPanel.Children.Add(new TextBlock()
            {
                Text = $"Total after VAT: £{Math.Round(total, 2)}",  // Text blocks made in the C# code
                FontSize = 20,
                Margin = new Thickness(5, 5, 5, 5),
                FontFamily = new FontFamily("Georgia"),
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"receipts.txt", true))
                {
                    file.WriteLine(passedUsername + "," + savedTotal + "," + savedFoodTotal + "," + savedDrinksTotal);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ApplicationException("Oopsies!");
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
