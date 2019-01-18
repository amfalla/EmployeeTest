using System;
using System.Threading.Tasks;
using Employees.BLL;
using Employees.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeesWeb.Tests
{
    /// <summary>
    /// Test class for the employee service
    /// </summary>
    [TestClass]
    public class EmployeeServiceTest
    {
        /// <summary>
        /// Tests Get All Employees
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetAllEmployees()
        {
            IRepository repo = new EmployeesRepository();
            EmployeeService svc = new EmployeeService(repo);
            var employees = await svc.GetAll();

            Assert.IsNotNull(employees);
            Assert.AreEqual(employees.Count, 2);
        }

        /// <summary>
        /// Test Get an Employee by Id
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGetEmployeeById()
        {
            IRepository repo = new EmployeesRepository();
            EmployeeService svc = new EmployeeService(repo);
            var employee = await svc.GetById(1);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employee.Id, 1);
        }
    }
}
