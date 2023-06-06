using ECommerce.Commands;
using ECommerce.DataAccess.Concretes;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Concretes;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ECommerce.DataAccess.SqlServer;

namespace ECommerce.Domain.ViewModels
{
    public class LoginViewModel
    {
        private readonly IAdminRepository _adminRepo;
        private readonly ICustomerRepository _customerRepo;

        public RelayCommand SignIn { get; set; }


        public LoginViewModel(bool _IsCustomer)
        {

            _adminRepo = new AdminRepository();
            _customerRepo = new CustomerRepository();



            SignIn = new RelayCommand((obj) =>
            {

                        AdminWindow window = new AdminWindow();

                        AdminViewModel vm = new AdminViewModel();

                        window.DataContext = vm;
                        window.ShowDialog();
     
            });


         


        }
    }
}
