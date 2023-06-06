using ECommerce.DataAccess.Concretes;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public class CustomerService
    {
        private IRepository<Customer> _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customers = _repository.GetAll();
            var customer = customers.FirstOrDefault(c => c.Username == username);
            return customer;
        }
    }
}
