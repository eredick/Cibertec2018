using Proyecto.Models;
using Proyecto.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface IProductRepository : IRepository<Product>
    {
        int InsertProduct(Product entity);
        IEnumerable<ProductVM> GetProducstPaged(Product entity, int start, int end);
        int CountProductsPaged();
        Product GetProductById(int Id);
        bool UpdateProduct(Product entity);
        bool DeleteProduct(int Id);
    }
}
