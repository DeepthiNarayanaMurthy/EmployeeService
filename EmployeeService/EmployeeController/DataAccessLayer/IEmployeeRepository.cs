using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.EmployeeModel
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(string id);
        int InsertEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteById(string id);   
    }
}
