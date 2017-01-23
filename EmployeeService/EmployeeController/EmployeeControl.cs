using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using EmployeeService.EmployeeModel;

namespace EmployeeService
{
    public class EmployeeControl
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeControl(IEmployeeRepository repository)
        {
            employeeRepository = repository;
        }

        public EmployeeControl()
        {
        }

        public int CreateNewEmployee(Employee employee)
        {
            int status;
            if (ValidateIfFullNameOrLastNameOrEmailIsEmpty(employee)||!ValidateEmail(employee))
            {
                status = 0;
            }
            else
            {
                status = employeeRepository.InsertEmployee(employee);
            }

            return status;
        }

       

      
        public Employee RetreiveEmployeeDetails(Employee employee)
        {
            try
            {
                return employeeRepository.GetEmployeeById(employee.Employee_Id);
            }
            catch
            {
                return null;
            }
            
        }
        public List<Employee> RetreiveEmployees()
        {
            //try
            //{
                List<Employee> emp= employeeRepository.GetEmployees();
            return emp;
            //}
            //catch
            //{
            //    return null;
            //}
            
        }
        public int EditEmployeeDetails(Employee employee)
        {
            int status;
            if (ValidateIfFullNameOrLastNameOrEmailIsEmpty(employee) || !ValidateEmailForEdit(employee))
            {
                status = 0;
            }
            else
            {
                status = employeeRepository.UpdateEmployee(employee);
            }

            return status;
        } 
        public int DeleteEmployee(Employee employee)
        {
            if (string.Compare(employee.Status, "Deactive") == 0)
                return employeeRepository.DeleteById(employee.Employee_Id);
            else
                return 0;
        }
        public int DeleteMultipleEmployees(List<Employee> employees)
        {
            int status=0;
            try
            {
                foreach(Employee employee in employees)
                {
                    if (string.Compare(employee.Status, "Deactive") == 0)
                    {
                        employeeRepository.DeleteById(employee.Employee_Id);
                        status++;
                    }   
                }
                return status;
            }
            catch
            {
                return status;
            }
        }



        private bool ValidateEmail(Employee employee)
        {
            return Regex.IsMatch(employee.Email_Id, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        private static bool ValidateIfFullNameOrLastNameOrEmailIsEmpty(Employee employee)
        {
            return string.IsNullOrEmpty(employee.FirstName) || (string.IsNullOrEmpty(employee.LastName) || string.IsNullOrEmpty(employee.Email_Id));
        }
        private bool ValidateEmailForEdit(Employee employee)
        {
            try
            {
                Employee emp = new Employee();
                emp = employeeRepository.GetEmployeeById(employee.Employee_Id);
                if (string.Compare(emp.Email_Id, employee.Email_Id) == 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}