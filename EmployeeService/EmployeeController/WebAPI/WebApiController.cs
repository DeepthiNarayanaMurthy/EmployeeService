﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeService.EmployeeController;
using EmployeeService;

namespace EmployeeService.EmployeeController.WebAPI
{
    [EnableCors(origins: "http://localhost:4404/", headers: "*", methods: "*")]
    public class WebApiController : ApiController
    {
        EmployeeRepository emprepository;
        EmployeeControl control;
        public WebApiController()
        {
            emprepository = new EmployeeRepository();
            control = new EmployeeControl(emprepository);
        }
        
        [Route("EmployeeDetails")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            var employees = control.RetreiveEmployees();
            response = ResponseMessageMethod(employees);
            return response;
        }

        private HttpResponseMessage ResponseMessageMethod(List<Employee> employees)
        {
            HttpResponseMessage response;
            if (employees == null)
                response = Request.CreateResponse(HttpStatusCode.NotFound,"Not Connecting to DB");
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("EmployeeDetails/{Employee_Id}")]
        public HttpResponseMessage Get(string Employee_Id)
        {
            HttpResponseMessage response;
            var employees = control.RetreiveEmployeeDetails(Employee_Id);
            response = ResponseMessageMethod(employees);
            return response;
        }

        private HttpResponseMessage ResponseMessageMethod(Employee employees)
        {
            HttpResponseMessage response;
            if (employees == null)
                response = Request.CreateResponse(HttpStatusCode.NotFound, employees);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("EmployeeDetails")]
        public HttpResponseMessage Post(Employee employee)
        {
            HttpResponseMessage response;
            
            if (employee==null)
            {
                response= Request.CreateResponse(HttpStatusCode.BadRequest,"Bad Request");
                return response;
            }
            var employees = control.CreateNewEmployee(employee);
            response = Request.CreateResponse(HttpStatusCode.OK,"Success");
            return response;
        }
        [Route("EmployeeDetails/{Employee_Id}")]
        public HttpResponseMessage Put(Employee employee)
        {
            HttpResponseMessage response;
            if (employee==null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
                return response;
            }
            var employees = control.EditEmployeeDetails(employee);
            response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            return response;
        }
        [Route("EmployeeDetails/{employeeId}")]
        public HttpResponseMessage Delete(string employeeId)
        {
            HttpResponseMessage response;
            //if (employee.Count == 1)
            //{
            
                var employees = control.DeleteEmployee(employeeId);
                if (employees == 0)
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
                else
                    response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                return response;
            //}
            //else
            //{ 
            //    var employees = control.DeleteMultipleEmployees(employee);
            //    if (employees == 0)
            //        response = Request.CreateResponse(HttpStatusCode.NotFound, employees);
            //    else
            //        response = Request.CreateResponse(HttpStatusCode.OK, employees);
            //    return response;

            //}
        }

    }
}
