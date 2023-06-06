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
    public class UpdateProductViewModel:BaseViewModel
    {
        public IRepository<Product> Repository { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public UpdateProductViewModel(IRepository<Product> _Repository, Product product)
        {
            
        }
    }
}
