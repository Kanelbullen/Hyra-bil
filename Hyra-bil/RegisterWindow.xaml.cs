using Hyra_bil.models;
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

namespace Hyra_bil
{
    public partial class RegisterWindow : Window
    {
        public User RegisteredUser { get; private set; }

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisteredUser = new User(UsernameTextBox.Text, PasswordBox.Password, FullNameTextBox.Text);
            MessageBox.Show($"User {RegisteredUser.Username} registered successfully.");
            DialogResult = true;
            Close();
        }
    }
}
