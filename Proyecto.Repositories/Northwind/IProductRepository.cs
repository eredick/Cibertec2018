using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface IProductRepository:IRepository<Product>
    {
        int InsertProduct(Product entity);
        Product GetProductById(int Id);
        bool UpdateProduct(Product entity);
        bool DeleteProduct(int Id);
    }
}
