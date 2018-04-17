using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Repositories.Northwind
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        int InsertEmployee(Employee entity);
        Employee GetEmployeeById(int Id);
        bool UpdateEmployee(Employee entity);
    }
}
