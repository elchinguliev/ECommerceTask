using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class ProductInfoViewModel:BaseViewModel
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        public ProductInfoViewModel()
        {
            _productService = new ProductService();
            _customerService = new CustomerService();
            _orderService = new OrderService();

            ProductInfo = new Product();

            OrderCommand = new RelayCommand((obj) =>
            {
                var customer = _customerService.GetCustomerByUsername(Username);
                if (customer == null)
                {
                    MessageBox.Show("User does not exist");
                }
                else
                {
                    if (Amount <= ProductInfo.Quantity)
                    {
                        ProductInfo.Quantity-= Amount;
                        _productService.UpdateProduct(ProductInfo);
                        var order = new Order
                        {
                            Amount = Amount,
                            CustomerId = customer.Id,
                            ProductId = ProductInfo.Id,
                            Date = DateTime.Now
                        };
                        _orderService.AddOrder(order);
                        MessageBox.Show("Your order submitted");
                    }
                    else
                    {
                        MessageBox.Show($"We do not have items with this count {Amount}");
                    }
                }
            });
        }

        public RelayCommand OrderCommand { get; set; }

        private Product productInfo;

        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }
    }
}
