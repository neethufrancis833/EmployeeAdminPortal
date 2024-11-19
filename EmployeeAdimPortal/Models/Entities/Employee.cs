namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public   Guid Id { get; set; }
        public    String? Name { get; set; }

        public  String? Email { get; set; }
        public  String? Phone { get; set; }
        public  decimal? Salary { get; set; }
    }
}
