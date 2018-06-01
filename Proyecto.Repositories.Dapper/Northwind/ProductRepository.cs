using Dapper;
using Dapper.Contrib.Extensions;
using Proyecto.Models;
using Proyecto.Models.ViewModels;
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

        public int CountProductsPaged(ProductVM entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@productName", entity.ProductName);
                parameters.Add("@companyName", entity.CompanyName);
                parameters.Add("@categoryName", entity.CategoryName);

                return connection.ExecuteScalar<int>("GetCountAllProducts", parameters, commandType: System.Data.CommandType.StoredProcedure);//lProducts.Count();
            }
        }

        public bool DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductVM> GetProducstPaged(ProductVM entity, int start, int end)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@productName", entity.ProductName);
                parameters.Add("@companyName", entity.CompanyName);
                parameters.Add("@categoryName", entity.CategoryName);
                parameters.Add("start", start);
                parameters.Add("end", end);

                var lProducts = connection.Query<ProductVM>("GetAllProducts", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return lProducts;
            }
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
