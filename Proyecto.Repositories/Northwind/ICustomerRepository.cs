using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        int InsertCustomer(Customer entity);
        Customer GetCustomerById(int Id);
        bool UpdateCustomer(Customer entity);
    }
}
