using EmployeeService.EmployeeController;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Tests
{
    class EmployeeRepositoryTest
    {
        private Employee Employee1 = new Employee()
        {
            Employee_Id = "emp4",
            FirstName = "Fname4",
            LastName = "Lname4",
            PhoneNo = "123456778",
            Email_Id = "emp4@gmail.com",
            Age = 46,
            Status = "Active"
        };
        [Test]
        public void AddEmployeeToDataBase_ShouldReturnOne_OnSuccess()
        {
            EmployeeRepository emp = new EmployeeRepository();
            Assert.AreEqual(1, emp.InsertEmployee(Employee1));
        }
        //[Test]
        //public void RetreiveEmployeeById_ShouldReturnOne_OnSuccess()
        //{
        //    EmployeeRepository emp = new EmployeeRepository();
        //    Employee Employee2 = new Employee();
        //    Employee2 = emp.GetEmployeeById("emp4");
        //    Assert.AreEqual(Employee1,Employee2 );
        //}
        [Test]
        public void Retr()
        {
            EmployeeRepository emp = new EmployeeRepository();
            List<Employee> Employee2 = new List<Employee>();
            Employee2 = emp.GetEmployees();
            Assert.AreEqual(Employee1, Employee2);
        }
        [Test]
        public void Edit()
        {
            EmployeeRepository emp = new EmployeeRepository();
            Assert.AreEqual(1, emp.UpdateEmployee(Employee1));
        }
        [Test]
        public void Delete()
        {
            EmployeeRepository emp = new EmployeeRepository();
            Assert.AreEqual(1, emp.DeleteById("emp4"));
        }
    }
}
