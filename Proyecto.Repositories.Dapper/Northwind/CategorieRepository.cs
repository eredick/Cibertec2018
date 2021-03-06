﻿using Dapper.Contrib.Extensions;
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
    public class CategorieRepository : Repository<Category>, ICategorieRepository
    {
        public CategorieRepository(string connectionString) : base(connectionString)
        {
        }

        public Category GetCategorieById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var categories = connection.Get<Category>(Id);
                return categories;
            }
        }

        public int InsertCategorie(Category entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool UpdateCategorie(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
