using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Bakery_app.ClassHelper.EFClass;
using Bakery_app.Windows_app;
using Bakery_app.DB;


namespace Bakery_app.ClassHelper
{
    internal class CartProductClass
    {
        public static List<Product> products = new List<Product>();
    }
}