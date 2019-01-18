using Employees.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.BLL
{
    /// <summary>
    /// Business Service to search for employees
    /// </summary>
    public class EmployeeService
    {
        private IRepository repository;

        public EmployeeService(IRepository repo)
        {
            repository = repo;
        }
    
        /// <summary>
        /// Gest a list of all the employees registered
        /// </summary>
        /// <returns>List of employees</returns>
        public async Task<List<EmployeeDTO>> GetAll()
        {
            List<EmployeeDTO> employeesDTOs = new List<EmployeeDTO>();
            var employees = await repository.GetAll();

            foreach (var employee in employees)
            {
                employeesDTOs.Add(EmployeeDTOFactory.Get(employee));
            }

            return employeesDTOs;
        }

        /// <summary>
        /// Gets an employee based on its id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>Employee if found otherwise returns null</returns>
        public async Task<EmployeeDTO> GetById(int id)
        {
            var employees = await repository.GetAll();
            return EmployeeDTOFactory.Get(employees.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
