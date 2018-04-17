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
    public class CategorieRepository : Repository<Categorie>, ICategorieRepository
    {
        public CategorieRepository(string connectionString) : base(connectionString)
        {
        }

        public Categorie GetCategorieById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var categories = connection.Get<Categorie>(Id);
                return categories;
            }
        }

        public int InsertCategorie(Categorie entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool UpdateCategorie(Categorie entity)
        {
            throw new NotImplementedException();
        }
    }
}
