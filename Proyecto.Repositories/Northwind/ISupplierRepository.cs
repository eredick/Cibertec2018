using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        int InsertSupplier(Supplier entity);
        Supplier GetSupplierById(int Id);
        bool UpdateSupplier(Supplier entity);
        bool DeleteSupllier(int Id);
    }
}
