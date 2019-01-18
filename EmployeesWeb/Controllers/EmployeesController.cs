using Employees.BLL;
using Employees.DAL;
using Employees.Model;
using EmployeesWeb.Decorators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace EmployeesWeb.Controllers
{
    /// <summary>
    /// WEB API Controller for the employees API
    /// </summary>
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of Employees</returns>
        [HttpGet]
        [ExceptionHandling]
        [Route("api/employees")]
        [ResponseType(typeof(IEnumerable<EmployeeDTO>))]
        public async Task<IHttpActionResult> Get()
        {
            IRepository repo = new EmployeesRepository();
            EmployeeService svc = new EmployeeService(repo);
            var employees = await svc.GetAll();

            if (employees == null || !employees.Any())
                return NotFound();

            return Ok(employees);
        }

        /// <summary>
        /// Get an employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ExceptionHandling]
        [Route("api/employees/{id}")]
        [ResponseType(typeof(EmployeeDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            IRepository repo = new EmployeesRepository();
            EmployeeService svc = new EmployeeService(repo);
            var employee = await svc.GetById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
    }
}
