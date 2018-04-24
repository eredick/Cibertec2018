using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
