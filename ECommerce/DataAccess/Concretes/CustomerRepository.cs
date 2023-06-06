using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.DataAccess.Concretes
{
    public class CustomerRepository : ICustomerRepository
    {   
        private readonly EECommerceDataContext _context;
        public CustomerRepository()
        {
            _context = new EECommerceDataContext();
        }
        public void AddData(Customer data)
        {
            _context.Customers.InsertOnSubmit(data);
            _context.SubmitChanges();
        }

        public void DeleteData(Customer data)
        {
            _context.Customers.DeleteOnSubmit(data);
            _context.SubmitChanges();
        }

        public ObservableCollection<Customer> GetAll()
        {
            var result = from c in _context.Customers
                         orderby c.Username
                         select c;
            return new ObservableCollection<Customer>(result);
        }

        public Customer GetData(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public void UpdateData(Customer data)
        {
            var item = _context.Customers.SingleOrDefault(c => c.Id == data.Id);

            item.Password = data.Password;

            _context.SubmitChanges();
        }
        public void CheckCustomer(string username, string password, ref int? result)
        {
            //_context.CheckCustomer(username, password, ref result);
        }
    }
}
