using Bakery_app.Windows_app;
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
using static Bakery_app.ClassHelper.EFClass;

namespace Bakery_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            reg.Show();
            this.Close();
            



        }

        private void Avtorization_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Text;

            if (login == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Введите данные!");
                return;
            }

            var accounts = ContextDB.UserAccount.ToList();
            var user = accounts.FirstOrDefault(i => (i.LoginName == login));
            if (user == null)
            {
                MessageBox.Show("Такого пользователя не существует!");
                return;
            }
            if (PasswordBox.Text == user.Password)
            {
               MessageBox.Show("Вход успешно выполнен!", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}

