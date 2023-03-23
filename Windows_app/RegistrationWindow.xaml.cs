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
using Bakery_app.Windows_app;
using Bakery_app.DB;

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

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Пустой логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbEmail.Text))
            {
                MessageBox.Show("Пустой email");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show("Пустой пароль");
                return;
            }
            UserAccount user = new UserAccount()
            {
                LoginName = TbLogin.Text.Trim(),
                Email = TbEmail.Text.Trim(),
                Password = TbPassword.Text.Trim(),
                IdRole = 1
            };
            ContextDB.UserAccount.Add(user);
            ContextDB.SaveChanges();
            TbLogin.Text = "";
            TbEmail.Text = "";
            TbPassword.Text = "";
            MessageBox.Show("Регистрация успешно выполнена! Вернитесь к окну авторизации и выполните вход.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}