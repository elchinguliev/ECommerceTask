using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static ECommerce.DataAccess.Concretes.OrderRepository;

namespace ECommerce.DataAccess.Concretes
{
 
        public class OrderRepository : IOrderRepository
        {
            private readonly EECommerceDataContext _context;
            public OrderRepository()
            {
                _context = new EECommerceDataContext();
            }
            public void AddData(Order data)
            {
                _context.Orders.InsertOnSubmit(data);
                _context.SubmitChanges();
            }

            public void DeleteData(Order data)
            {
                _context.Orders.DeleteOnSubmit(data);
                _context.SubmitChanges();
        }

            public ObservableCollection<Order> GetAll()
            {
            var orders = from o in _context.Orders
                         select o;
            return new ObservableCollection<Order>(orders);
        }

            public Order GetData(int id)
            {
                return _context.Orders.SingleOrDefault(o => o.Id == id);
        }

            public void UpdateData(Order data)
            {
            var item = _context.Orders.SingleOrDefault(o => o.Id == data.Id);

            item = new Order
            {
                Id = data.Id,
                Date = data.Date,
                Amount = data.Amount,
                ProductId = data.ProductId,
                CustomerId = data.CustomerId,
            };
            _context.SubmitChanges();
        }
        }
    }

