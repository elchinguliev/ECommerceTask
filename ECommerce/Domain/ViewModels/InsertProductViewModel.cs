using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Concretes;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ECommerce.Domain.ViewModels
{
    public class InsertProductViewModel:BaseViewModel
    {

        public RelayCommand InsertCommand { get; set; }
        public IRepository<Product> _productRepo { get; set; }


        public InsertProductViewModel(IRepository<Product> customers)
        {
            InsertProduct ip = new InsertProduct();
            _productRepo=new ProductRepository();
            _productRepo=customers;
            InsertCommand=new RelayCommand((obj) =>
            {
                var window = obj as Window;
                Product product = new Product
                {
                    Name=ProductName,
                    Description=ProductDescription,
                    Price=ProductPrice,
                    Discount=ProductDiscount,
                    Quantity=ProductQuantity,

                };
                _productRepo.AddData(product);
                MessageBox.Show("Produc has been added successfully");
                ip.Close();
            });



        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private decimal productPrice;

        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }

        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; OnPropertyChanged(); }
        }

        private int productDiscount;

        public int ProductDiscount
        {
            get { return productDiscount; }
            set { productDiscount = value; OnPropertyChanged(); }
        }


    }
}
