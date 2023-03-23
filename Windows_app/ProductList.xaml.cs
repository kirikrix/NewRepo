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
using System.Runtime.Remoting.Contexts;


namespace Bakery_app.Windows_app
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        List<string> listSort = new List<string>()
        {
            "По умолчанию",
            "По имени (по возрастанию)",
            "По имени (по убыванию)"
        };

        public ProductList()
        {
            InitializeComponent();

            CmbSort.ItemsSource = listSort;
            CmbSort.SelectedIndex = 0;

            GetListProduct();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = ContextDB.Product.ToList();

            // поиск, сортировка, фильтрация

            // поиск
            products = products.Where(i => i.ProdName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            // сортировка
            var selectedIndexCmb = CmbSort.SelectedIndex;

            switch (selectedIndexCmb)
            {
                case 0:
                    products = products.OrderBy(i => i.IdProd).ToList();
                    break;

                case 1:
                    products = products.OrderBy(i => i.ProdName.ToLower()).ToList();
                    break;

                case 2:
                    products = products.OrderByDescending(i => i.ProdName.ToLower()).ToList();
                    break;

                default:
                    break;
            }

            // фильтрация


            // вывод итгового списка
            LvProduct.ItemsSource = products;
        }

        // добавление товара
        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProductWindow = new AddEditProduct();
            addEditProductWindow.ShowDialog();
        }

        // редактирование товара
        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            AddEditProduct editProductWindow = new AddEditProduct(product);
            editProductWindow.ShowDialog();

            GetListProduct();

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListProduct();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListProduct();
        }


        // добавление в корзину 
        private void BtnAddToCartProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;
            CartProductClass.products.Add(product);
            MessageBox.Show($"Товар {product.ProdName} успешно добавлен в корзину");
        }

        private void ImgCart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CartProduct cartProductWindow = new CartProduct();
            this.Hide();
            cartProductWindow.ShowDialog();
            this.Show();
        }
    }
}