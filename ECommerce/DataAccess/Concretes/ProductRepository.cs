using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private EECommerceDataContext _context;
        public ProductRepository()
        {
            _context = new EECommerceDataContext();
        }
        public void AddData(Product data)
        {
            _context.Products.InsertOnSubmit(data);
            _context.SubmitChanges();
        }

        public void DeleteData(Product data)
        {
            _context.Products.DeleteOnSubmit(data);
            _context.SubmitChanges();
        }

        public ObservableCollection<Product> GetAll()
        {
            var products = from p in _context.Products
                           orderby p.Name
                           select p;
            return new ObservableCollection<Product>(products);
        }

        public Product GetData(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateData(Product data)
        {
            var item = _context.Products.SingleOrDefault(x => x.Id == data.Id);
            item = new Product
            {
                Name=data.Name,
                Price=data.Price,
                Description=data.Description,
                Quantity=data.Quantity,
                Discount=data.Discount
            };
            _context.SubmitChanges();
        }
    }
}
