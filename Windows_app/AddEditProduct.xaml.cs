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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.IO.Ports;


namespace Bakery_app.Windows_app
{
    public partial class AddEditProduct : Window
    {

        private string pathPhoto = null;

        private bool isEdit = false;

        private Product editProduct;
        

        public AddEditProduct()
        {
            InitializeComponent();
            CMBTypeProduct.ItemsSource = ContextDB.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";

        }

        public AddEditProduct(Product product)
        {
            InitializeComponent();

            CMBTypeProduct.ItemsSource = ContextDB.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";

            TbNameProduct.Text = product.ProdName.ToString();
            TbDisc.Text = product.Description.ToString();
            CMBTypeProduct.SelectedItem = ContextDB.ProductType.Where(i => i.IdProdType == product.IdProdType).FirstOrDefault();

            if (product.Image != null)
            {
                using (MemoryStream stream = new MemoryStream(product.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;

                }
            }


            isEdit = true;

            editProduct = product;

        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            // валидация


            if (isEdit)
            {
                //изменение товара

                editProduct.ProdName = TbNameProduct.Text;
                editProduct.Description = TbDisc.Text;
                editProduct.IdProdType = (CMBTypeProduct.SelectedItem as ProductType).IdProdType;
                if (pathPhoto != null)
                {
                    editProduct.Image = File.ReadAllBytes(pathPhoto);
                }
                ContextDB.SaveChanges();
                MessageBox.Show("OK");
            }
            else
            {
                //добавление товара
                Product product = new Product();
                product.ProdName = TbNameProduct.Text;
                product.Description = TbDisc.Text;
                product.IdProdType = (CMBTypeProduct.SelectedItem as ProductType).IdProdType;
                if (pathPhoto != null)
                {
                    product.Image = File.ReadAllBytes(pathPhoto);
                }

                ContextDB.Product.Add(product);

                ContextDB.SaveChanges();
                MessageBox.Show("OK");
            }

            this.Close();

        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}