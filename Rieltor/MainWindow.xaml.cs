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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rieltor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RieltorEntities _db;
        private string _role;

        // Конструктор по умолчанию
        public MainWindow()
        {
            InitializeComponent();
            _db = new RieltorEntities();
            _role = "Гость"; // Значение по умолчанию
            LoadData();
            SetVisibility();
        }

        // Конструктор с параметром
        public MainWindow(string role) : this()
        {
            _role = role;
        }

        private void LoadData()
        {
            ClientsGrid.ItemsSource = _db.Клиенты.ToList();
            ContractsGrid.ItemsSource = _db.Договора.ToList();

            if (_role == "Администратор")
            {
                UsersGrid.ItemsSource = _db.Пользователи.ToList();
            }
        }

        private void SetVisibility()
        {
            if (_role != "Администратор")
            {
                var tabItem = (TabItem)FindName("UsersTab");
                if (tabItem != null)
                {
                    tabItem.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
