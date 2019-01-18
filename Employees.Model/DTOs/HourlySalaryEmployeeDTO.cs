namespace Employees.Model
{
    /// <summary>
    /// Specialization of an employee with an hourly salary
    /// </summary>
    public class HourlySalaryEmployeeDTO : EmployeeDTO
    {
        public HourlySalaryEmployeeDTO(Employee emp) : base(emp) { }

        public override float AnualSalary
        {
            get { return 120 * HourlySalary * 12; }
        }
    }
}
