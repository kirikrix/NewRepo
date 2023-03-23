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
using Bakery_app.ClassHelper;

namespace Bakery_app.Windows_app
{
    /// <summary>
    /// Логика взаимодействия для CartProductWindow.xaml
    /// </summary>
    public partial class CartProduct : Window
    {
        public CartProduct()
        {
            InitializeComponent();

            LvCartProduct.ItemsSource = ClassHelper.CartProductClass.products;
        }



        private void BtnDelToCartProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            if (product != null)
            {
                ClassHelper.CartProductClass.products.Remove(product);

                LvCartProduct.ItemsSource = ClassHelper.CartProductClass.products;

                MessageBox.Show(product.ProdName + " Delete");
            }
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}