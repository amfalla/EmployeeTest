namespace Employees.Model
{
    /// <summary>
    /// Specialization of an employee with a monthly salary
    /// </summary>
    public class MonthlySalaryEmployeeDTO : EmployeeDTO
    {

        public MonthlySalaryEmployeeDTO(Employee emp) : base(emp) { }

        public override float AnualSalary
        {
            get { return MonthlySalary * 12; }
        }
    }
}
