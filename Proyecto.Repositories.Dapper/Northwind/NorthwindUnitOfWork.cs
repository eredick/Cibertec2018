using Proyecto.Repositories.Northwind;
using Proyecto.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Categories = new CategorieRepository(connectionString);
            Customers = new CustomerRespository(connectionString);
        }
        public ICategorieRepository Categories { get; set; }
        public ICustomerRepository Customers { get; set; }
    }
}
