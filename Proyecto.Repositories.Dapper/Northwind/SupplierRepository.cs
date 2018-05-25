using Dapper;
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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public bool DeleteSupllier(int Id)
        {
            var sql = "UPDATE Suppliers SET Available = 0 WHERE SupplierID = @SupplierID";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int i = connection.Execute(sql, new { SupplierId = Id });

                if (i > 0)
                    return true;
                else
                    return false;
            }
        }

        public Supplier GetSupplierById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Supplier>(Id);
            }
        }

        public int InsertSupplier(Supplier entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool UpdateSupplier(Supplier entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }
    }
}
