using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Mocks;
using Rhino.Mocks;
using EmployeeService;
using EmployeeService.EmployeeModel;
using EmployeeService.EmployeeController;

namespace EmployeeService.Tests
{
    [TestFixture]
    public class EmployeeConterollerTest
    {
        //private IEmployeeRepository employeeRepositoryMock;
        //private MockRepository employeeRepositoryMock;
        private Employee Employee1 = new Employee()
        {
            Employee_Id = "emp4",
            FirstName = "Fname4",
            LastName = "Lname4",
            PhoneNo = "123456778",
            Email_Id = "emp4@gmail.com",
            Age = 23,
            Status = "Active"
        };
        private Employee Employee2 = new Employee()
        {
            Employee_Id = "emp5",
            FirstName = "Fname5",
            LastName = "Lname5",
            PhoneNo = "123456478",
            Email_Id = "emp5@gmail.com",
            Age = 23,
            Status = "Active"
        };
        private Employee Employee3 = new Employee()
        {
            Employee_Id = "emp",
            FirstName = "",
            LastName = "",
            PhoneNo = "123456478",
            Email_Id = "emp5@gmail.com",
            Age = 23,
            Status = "Active"
        };
        private Employee Employee4 = new Employee()
        {
            Employee_Id = "emp",
            FirstName = "Fname",
            LastName = "Lname",
            PhoneNo = "123456478",
            Email_Id = "",
            Age = 23,
            Status = "Active"
        };

        private Employee Employee5 = new Employee()
        {
            Employee_Id = "emp",
            FirstName = "Fname",
            LastName = "Lname",
            PhoneNo = "123456478",
            Email_Id = "emp",
            Age = 23,
            Status = "Active"
        };
        private Employee Employee6 = new Employee()
        {
            Employee_Id = "emp4",
            FirstName = "Fname4",
            LastName = "Lname4",
            PhoneNo = "123456778",
            Email_Id = "employee@gmail.com",
            Age = 23,
            Status = "Active"
        };
        private Employee Employee7 = new Employee()
        {
            Employee_Id = "emp7",
            FirstName = "Fname4",
            LastName = "Lname4",
            PhoneNo = "123456778",
            Email_Id = "emp@gmail.com",
            Age = 23,
            Status = "Deactive"
        };

        private List<Employee> EmployeeList1;
        private List<Employee> EmployeeList2;
        private List<Employee> EmployeeList3;

        [SetUp]
        public void TestInitialize()
        {
            EmployeeList1 = new List<Employee>();
            EmployeeList1.Add(Employee1);
            EmployeeList2 = new List<Employee>();
            EmployeeList2.Add(Employee7);
            EmployeeList3 = new List<Employee>();
            EmployeeList3.Add(Employee7);
            EmployeeList3.Add(Employee1);
        }

        //Test for Create
        [Test]
        public void GivingValidEmployeeDetails_OnCreate_ShouldReturnOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.InsertEmployee(Employee2)).Return(1);

            EmployeeControl Create = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(1, Create.CreateNewEmployee(Employee2),"Insert is not happening");
        }

        [Test]
        public void GivingEmptyFirstNameAndLastName_OnCreate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.InsertEmployee(Employee3)).Return(1);

            EmployeeControl Create = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Create.CreateNewEmployee(Employee3), "Validation of First and Last name not happening");
        }
        [Test]
        public void GivingEmptyEmailId_OnCreate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.InsertEmployee(Employee4)).Return(1);

            EmployeeControl Create = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Create.CreateNewEmployee(Employee4), "Email id not entered");
        }
        [Test]
        public void GivingNonValidEmailId_OnCreate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.InsertEmployee(Employee5)).Return(1);

            EmployeeControl Create = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Create.CreateNewEmployee(Employee5), "Validation of email id not happening");
        }

        //Tests for Read
        [Test]
        public void GivingValidEmployeeId_OnReadById_ShouldReturnCurrectEmployeeDetalis()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.GetEmployeeById("emp4")).Return(Employee1);

            EmployeeControl Read = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(Employee1, Read.RetreiveEmployeeDetails(Employee1.Employee_Id), "Employee information is not reterieved properly");
        }
        [Test]
        public void GivingInValidEmployeeId_OnReadById_ShouldReturnCurrectEmployeeDetalis()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.GetEmployeeById("2324")).Return(null);

            EmployeeControl Read = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(null, Read.RetreiveEmployeeDetails(Employee1.Employee_Id), "Employee information is not reterieved properly");
        }

        [Test]
        public void OnReteriveEmployees_ShouldReturnAllEmployeesDetails()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.GetEmployees()).Return(EmployeeList1);

            EmployeeControl Read = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(EmployeeList1, Read.RetreiveEmployees(), "All Employees information is not reterieved properly");
        }

        //Test for Update
        [Test]
        public void ChangingEmployeeWithValidDetails_OnUpdate_ShouldReturnOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployee(Employee1)).Return(1);
            employeeRepositoryMock.Expect(x => x.GetEmployeeById("emp4")).Return(Employee1);

            EmployeeControl Update = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(1, Update.EditEmployeeDetails(Employee1), "Editing of employee details not happening");
        }
        [Test]
        public void ChangingEmployeeWithEmptyFirstNameAndLastName_OnUpdate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployee(Employee3)).Return(1);

            EmployeeControl Update = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Update.EditEmployeeDetails(Employee3), "Validation while Editing of employee details not happening");
        }
        [Test]
        public void ChangingEmployeeWithEmptyEmailId_OnUpdate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployee(Employee4)).Return(1);

            EmployeeControl Update = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Update.EditEmployeeDetails(Employee4), "Validation while Editing of employee details not happening");
        }
        [Test]
        public void ChangingEmployeeEmailId_OnUpdate_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployee(Employee6)).Return(1);
            employeeRepositoryMock.Expect(x => x.GetEmployeeById("emp4")).Return(Employee1);

            EmployeeControl Update = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Update.EditEmployeeDetails(Employee6), "Email Cannot Be Changed");
        }

        //Test for Delete
        [Test]
        public void EmployeeWithStatusDeactivate_OnDelete_ShouldReturnOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.DeleteById("emp7")).Return(1);

            EmployeeControl Delete = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(1, Delete.DeleteEmployee(Employee7.Employee_Id), "Deletion not happening properly");
        }
        [Test]
        public void EmployeeWithStatusActive_OnDelete_ShouldReturnZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.DeleteById("emp4")).Return(1);

            EmployeeControl Delete = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(0, Delete.DeleteEmployee(Employee1.Employee_Id), "Deletion not happening properly");
        }

        //Delete Multiple
        [Test]
        public void MultipleEmployeesWithStatusDeactive_OnDelete_ShouldReturnOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.DeleteById("emp4")).Return(1);

            EmployeeControl Delete = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(1, Delete.DeleteMultipleEmployees(EmployeeList2), "Deletion not happening properly");
        }
        [Test]
        public void MultipleEmployeesWithSomeEmployeeWithStatusActive_OnDelete_ShouldReturnOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepository>();
            employeeRepositoryMock.Expect(x => x.DeleteById("emp4")).Return(1);

            EmployeeControl Delete = new EmployeeControl(employeeRepositoryMock);

            Assert.AreEqual(1, Delete.DeleteMultipleEmployees(EmployeeList3), "Deletion not happening properly");
        }
        
    }
}
