using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Login : Window
    {
        string username;
        string password;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            username = usernameBox.Text;
            password = passwordBox.Password.ToString();
            bool loggedIn = false;

            try
            {
                string[] usernames = System.IO.File.ReadAllLines(@"users.txt");
                for (int x = 0; x < usernames.Length; x++)
                {
                    string[] fields = usernames[x].Split(',');
                    if (fields[0].Equals(username) && fields[1].Equals(password))
                    {
                        loggedIn = true;
                        RestaurantMenu restaurantMenu = new RestaurantMenu(username);
                        restaurantMenu.Show();
                        this.Close();
                    }     
                }
                if (!loggedIn)
                    MessageBox.Show("Login details are invalid");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Login details are invalid");
            }
            
        }

        private void Switch_SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
}
