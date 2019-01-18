using System.Runtime.Serialization;

namespace Employees.Model
{
    /// <summary>
    /// Entity transformed for displaying to the user
    /// </summary>
    [DataContract]
    public abstract class EmployeeDTO
    {
        protected EmployeeDTO(Employee emp)
        {
            Id = emp.Id;
            Name = emp.Name;
            ContractTypeName = emp.ContractTypeName;
            RoleId = emp.RoleId;
            RoleName = emp.RoleName;
            RoleDescription = emp.RoleDescription;
            HourlySalary = emp.HourlySalary;
            MonthlySalary = emp.MonthlySalary;
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "contractTypeName")]
        public string ContractTypeName { get; set; }

        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }

        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }

        [DataMember(Name = "roleDescription")]
        public string RoleDescription { get; set; }

        [DataMember(Name = "hourlySalary")]
        public float HourlySalary { get; set; }

        [DataMember(Name = "monthlySalary")]
        public float MonthlySalary { get; set; }

        [DataMember(Name = "anualSalary")]
        public abstract float AnualSalary { get; }
    }
}
