﻿using Proyecto.Repositories.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategorieRepository Categories { get; }
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        ISupplierRepository Supplier { get; }
        IProductRepository Product { get; }
    }
}
