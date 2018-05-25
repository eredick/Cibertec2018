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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }

        public bool DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Product>(Id);
            }
        }

        public int InsertProduct(Product entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool UpdateProduct(Product entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }
    }
}
