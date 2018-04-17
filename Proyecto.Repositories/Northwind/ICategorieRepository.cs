using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface ICategorieRepository : IRepository<Categorie>
    {
        int InsertCategorie(Categorie entity);
        Categorie GetCategorieById(int Id);
        bool UpdateCategorie(Categorie entity);
    }
}
