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
using System.Runtime.Remoting.Contexts;

namespace Bakery_app.Windows_app
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ContextDB.UserAccount.ToList()
                .Where(i => i.LoginName == TbLogin.Text &&
                i.Password == PbPassword.Password)
                .FirstOrDefault();
                
            if (userAuth != null)
            {
                
                ProductList productList = new ProductList();
                productList.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationUserWindow = new RegistrationWindow();
            registrationUserWindow.Show();
            this.Close();

        }
    }
}