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
    public partial class SignUp : Window
    {
        string username;
        string password;
        string repeatPassword;

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            username = usernameBox.Text;
            password = passwordBox.Password.ToString();
            repeatPassword = repeatPasswordBox.Password.ToString();
            bool alreadyUsed = false;

            string[] usernames = System.IO.File.ReadAllLines(@"users.txt");
            for (int x = 0; x < usernames.Length; x++)
            {
                string[] fields = usernames[x].Split(',');
                if (fields[0].Equals(username))
                {
                    alreadyUsed = true;
                }
            }

                if (username.Length >= 4 && password.Equals(repeatPassword) && password.Length >= 4 && password.Any(char.IsDigit) && password.Any(char.IsLetter) && !alreadyUsed)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"users.txt", true))
                    {
                        file.WriteLine(username + "," + password);
                    }
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                catch (FileNotFoundException ex)
                {
                    throw new ApplicationException("Oopsies!");
                }
            }

            else
            {
                if (alreadyUsed)
                    MessageBox.Show("Username is aleady in use");
                else
                {
                    if (username.Length < 4 || password.Length < 4)
                        MessageBox.Show("Username or password is too short");
                    if (!password.Equals(repeatPassword))
                        MessageBox.Show("Passwords aren't matching");
                    if (!password.Any(char.IsDigit))
                        MessageBox.Show("Password must include a number");
                    if (!password.Any(char.IsLetter))
                        MessageBox.Show("Password must include a letter");
                }
            }
        }

        private void Switch_Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
