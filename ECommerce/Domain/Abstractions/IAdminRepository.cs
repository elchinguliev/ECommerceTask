
using ECommerce.DataAccess.Concretes;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Abstractions
{
    public interface IAdminRepository : IRepository<Admin>
    {
        void CheckAdmin(string text, string password, ref int? result);
    }
}
