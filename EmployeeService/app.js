var app = angular.module("index-app", []);


app.controller('EmployeesCtrl', function ($scope, $http) {
    $scope.GetEmployee = function () {
        var url = "http://localhost:4404/EmployeeDetails";
        $scope.emplooyeesList = {};
        $http
            .get(url)
                .then(function OnSuccess(response) {
                    $scope.emplooyeesList = response.data;
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })
    }

    $scope.GetEmployee();

    $scope.PostEmployee = function () {
        console.log("asf");
        var url = "http://localhost:4404/EmployeeDetails";
        var employee = {};
        if ($scope.Employee_Id) {
            employee.Employee_Id = $scope.Employee_Id;
            if ($scope.FName) {
                employee.FirstName = $scope.FName;
                if ($scope.LName) {
                    employee.LastName = $scope.LName;
                    if ($scope.PhoneNo) {
                        employee.PhoneNo = $scope.PhoneNo;
                        if ($scope.Email_Id) {
                            employee.Email_Id = $scope.Email_Id;
                            if ($scope.Age) {
                                employee.Age = $scope.Age;
                                if ($scope.Status) {
                                    employee.Status = $scope.Status;
                                }
                            }
                        }
                    }
                }
            }
        }
        else {
            alert("Fill All Fields");
            return;
        }
        console.log(employee);
        $http
            .post(url, employee)
                .then(function OnSuccess(response) {
                    console.log(response);
                }, function OnFailure(response) {
                    console.log(response);
                })
    }
    $scope.PutEmployee = function (id) {
        var url = "http://localhost:4404/EmployeeDetails" + id;
        $scope.emplooyee = {};
        $http
            .get(url)
                .then(function OnSuccess(response) {
                    $scope.emplooyee = response.data;
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })
        $scope.Employee_Id=employee.Employee_Id ;
        $scope.FName=employee.FirstName ;
        $scope.LName=employee.LastName  ;
        $scope.PhoneNo=employee.PhoneNo ;
        $scope.Email_Id=employee.Email_Id ;
        $scope.Age=employee.Age  ;
        $scope.Status = employee.Status;
        if ($scope.Employee_Id) {
            employee.Employee_Id = $scope.Employee_Id;
            if ($scope.FName) {
                employee.FirstName = $scope.FName;
                if ($scope.LName) {
                    employee.LastName = $scope.LName;
                    if ($scope.PhoneNo) {
                        employee.PhoneNo = $scope.PhoneNo;
                        if ($scope.Email_Id) {
                            employee.Email_Id = $scope.Email_Id;
                            if ($scope.Age) {
                                employee.Age = $scope.Age;
                                if ($scope.Status) {
                                    employee.Status = $scope.Status;
                                }
                            }
                        }
                    }
                }
            }
        }
        else {
            alert("Fill All Fields");
            return;
        }
        console.log(employee);
        $http
            .put(url, employee)
                .then(function OnSuccess(response) {
                    console.log(response);
                }, function OnFailure(response) {
                    console.log(response);
                })
    }
    $scope.DeleteEmployee = function (emp) {
        var url = "http://localhost:4404/EmployeeDetails";
        $http
            .delete(url,emp)
                .then(function OnSuccess(response) {
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })

    }
}
    
);
