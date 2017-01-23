using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeService.EmployeeModel;
using EmployeeService.EmployeeController;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeService.EmployeeController
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        public int InsertEmployee(Employee employee)
        {
            try
            {
                using (IDbConnection db = new SqlConnection())
                {
                    db.ConnectionString = @"Server=.;Database=EmployeeDb;user id=sa;password=Install02;";
                    string processQuery = "INSERT INTO Employees VALUES(@Employee_Id,@FirstName,@LastName,@Email_Id,@PhoneNo,@Age,@Status)";
                    return db.Execute(processQuery, employee);
                }
            }
            catch
            {
                return 0;
            }
        }

        public Employee GetEmployeeById(string id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection())
                {
                    db.ConnectionString = @"Server=.;Database=EmployeeDb;user id=sa;password=Install02;";
                    return db.Query<Employee>("Select * From Employees " + "WHERE Employee_Id = @Employee_Id", new { Employee_Id=id }).SingleOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                using (IDbConnection db = new SqlConnection())
                {
                    db.ConnectionString = @"Server=.;Database=EmployeeDb;user id=sa;password=Install02;";
                    return db.Query<Employee>("Select * From Employees").ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (IDbConnection db = new SqlConnection())
                {
                    db.ConnectionString = @"Server=.;Database=EmployeeDb;user id=sa;password=Install02;";
                    string sqlQuery = "UPDATE Employees SET FirstName = @FirstName, " + " LastName = @LastName, " +"Email_Id=@Email_id,"+"PhoneNo=@PhoneNo,"+"Age=@Age,"+"Status=@Status "+ "WHERE Employee_Id = @Employee_Id";
                    int rowsAffected = db.Execute(sqlQuery, employee);
                    return rowsAffected;
                }
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteById(string id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection())
                {
                    db.ConnectionString = @"Server=.;Database=EmployeeDb;user id=sa;password=Install02;";
                    string sqlQuery = "DELETE FROM Employees " + "WHERE Employee_Id = @Employee_Id";
                    int rowsAffected = db.Execute(sqlQuery, new { Employee_Id=id});
                    return rowsAffected;
                }
            }
            catch
            {
                return 0;
            }
        } 
    }
}