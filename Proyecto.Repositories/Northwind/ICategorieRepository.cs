using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface ICategorieRepository : IRepository<Category>
    {
        int InsertCategorie(Category entity);
        Category GetCategorieById(int Id);
        bool UpdateCategorie(Category entity);
    }
}
