namespace Employees.Model
{
    /// <summary>
    /// Factory to create an employee entity for displaying to the user
    /// </summary>
    public static class EmployeeDTOFactory
    {
        private const string MONTHLY_SALARY_TYPE = "MonthlySalaryEmployee";
        private const string HOURLY_SALARY_TYPE = "HourlySalaryEmployee";

        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static EmployeeDTO Get(Employee emp)
        {
            if (emp == null)
            {
                return null;
            }

            switch (emp.ContractTypeName)
            {
                case HOURLY_SALARY_TYPE:
                    return new HourlySalaryEmployeeDTO(emp);
                case MONTHLY_SALARY_TYPE:
                    return new MonthlySalaryEmployeeDTO(emp);
                default:
                    return new HourlySalaryEmployeeDTO(emp);
            }
        }
    }
}
