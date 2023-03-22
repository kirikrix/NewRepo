using Bakery_app.DB;
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
using static Bakery_app.ClassHelper.EFClass;

namespace Bakery_app.Windows_app
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginBox.Text))
            {
                MessageBox.Show("Пустой логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                MessageBox.Show("Пустой email");
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Пустой пароль");
                return;
            }
            UserAccount user = new UserAccount()
            {
                LoginName = LoginBox.Text.Trim(),
                Email = EmailBox.Text.Trim(),
                Password = PasswordBox.Text.Trim(),
                IdRole = 1
            };
            ContextDB.UserAccount.Add(user);
            ContextDB.SaveChanges();
            LoginBox.Text = "";
            EmailBox.Text = "";
            PasswordBox.Text = "";
            MessageBox.Show("Регистрация успешно выполнена! Вернитесь к окну авторизации и выполните вход.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
