using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Concretes;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ECommerce.Domain.ViewModels
{
    public class UpdateProductViewModel:BaseViewModel
    {
        EECommerceDataContext dataContext = new EECommerceDataContext();
        public IRepository<Product> _productRepo { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public UpdateProductViewModel(IRepository<Product> _productRepo, Product product)
        {


            var item = dataContext.Products.SingleOrDefault(x => x.Id == product.Id);
            item = new Product
            {
                Name=product.Name,
                Price=product.Price,
                Description=product.Description,
                Quantity=product.Quantity,
                Discount=product.Discount
            };
            dataContext.SubmitChanges();

        }
    }
}
