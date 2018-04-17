using Dapper.Contrib.Extensions;
using Proyecto.Models;
using Proyecto.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Dapper.Northwind
{
    public class CustomerRespository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRespository(string connectionString) : base(connectionString)
        {
        }

        public Customer GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public int InsertCustomer(Customer entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool UpdateCustomer(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
