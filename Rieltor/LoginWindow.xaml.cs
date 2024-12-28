using Rieltor.Models;
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

namespace Rieltor
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private RieltorEntities _db;

        public LoginWindow()
        {
            InitializeComponent();
            _db = new RieltorEntities();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            var user = _db.Пользователи.FirstOrDefault(u => u.Логин == login && u.Пароль == password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Логин}!");
                OpenMainWindow(user.Роль);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void OpenMainWindow(string role)
        {
            var mainWindow = new MainWindow(role);
            mainWindow.Show();
            this.Close();
        }
    }
}
