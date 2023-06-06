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
    public class OrderService
    {
        private IRepository<Order> _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            _repository.AddData(order);
        }
    }
}
