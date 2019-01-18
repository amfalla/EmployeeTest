using Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL
{
    /// <summary>
    /// Interface with the repository methods needed
    /// </summary>
    public interface IRepository
    {
        Task<List<Employee>> GetAll();
    }
}
