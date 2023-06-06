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
    public class AdminRepository : IAdminRepository

    {
        private readonly EECommerceDataContext _context;

        public AdminRepository()
        {
        }

        public void AddData(Admin data)
        {
            _context.Admins.InsertOnSubmit(data);
        }

        public void CheckAdmin(string text, string password, ref int? result)
        {
           // _context.CheckAdmin(text, password, ref result);
        }

        public void DeleteData(Admin data)
        {
            _context.Admins.DeleteOnSubmit(data);
            _context.SubmitChanges();
        }

        public ObservableCollection<Admin> GetAll()
        {
            var admins = from a in _context.Admins
                         select a;

            return new ObservableCollection<Admin>(admins);
        }

        public Admin GetData(int id)
        {
            return _context.Admins.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateData(Admin data)
        {
            var item = _context.Admins.SingleOrDefault(a => a.Id == data.Id);

            item = new Admin
            {
                Id = data.Id,
                Username = data.Username,
                Password = data.Password,
            };

            _context.SubmitChanges();
        }
    }
}
