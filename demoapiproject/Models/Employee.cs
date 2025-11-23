using System.ComponentModel.DataAnnotations.Schema;

namespace demoapiproject.Models
{

    [Table("Employee")] // ⭐ FIX: Map to correct SQL table
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? HireDate { get; set; }
        public string? JobTitle { get; set; }
        public int? DepartmentID { get; set; }
        public int? ManagerID { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
