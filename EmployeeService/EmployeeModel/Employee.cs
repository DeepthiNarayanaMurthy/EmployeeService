using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class Employee
    {
        public string Employee_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email_Id { get; set; }
        public string PhoneNo { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
    }
}