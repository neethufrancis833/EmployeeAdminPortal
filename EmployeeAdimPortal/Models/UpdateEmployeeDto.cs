﻿namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto
    {
        public String? Name { get; set; }

        public String? Email { get; set; }
        public String? Phone { get; set; }
        public decimal? Salary { get; set; }
    }
}
