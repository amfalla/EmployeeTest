using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Employees.Model;
using Employees.BLL;

namespace Employees.DAL
{
    /// <summary>
    /// Implementation of repository for employees
    /// </summary>
    public class EmployeesRepository : IRepository
    {
        private const string RequestUri = "api/Employees";
        HttpClient client;

        public EmployeesRepository()
        {
            client = RestClient.Instance;
        }

        /// <summary>
        /// Gets a list of employees from the backend service
        /// </summary>
        /// <returns>List of employees</returns>
        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employee = null;
            HttpResponseMessage response = await client.GetAsync(RequestUri);
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<List<Employee>>();
            }
            return employee;
        }
    }
}
