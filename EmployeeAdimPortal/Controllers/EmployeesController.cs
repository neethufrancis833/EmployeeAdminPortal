﻿using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using System.Runtime.InteropServices;
namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;                
        }





        [HttpGet]
        public IActionResult GetAllEmployees()
        {
           var allEmployees =dbContext.Employees.ToList();

            return Ok(allEmployees);
        }



        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeesbyId(Guid id)
        {

           var employee= dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();

            }
                
            return Ok(employee);


        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {  return NotFound();}


            employee.Name= updateEmployeeDto.Name;
            employee.Phone= updateEmployeeDto.Phone;
            employee.Email = updateEmployeeDto.Email;
            employee.Salary= updateEmployeeDto.Salary;
            dbContext.SaveChanges();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }
            return Ok();
        }



    }
}
