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

    $scope.Put1Employee = function () {
        var url = "http://localhost:4404/EmployeeDetails/" + $scope.Employee_Id1;
        //var url = "http://localhost:4404/EmployeeDetails/acds";
        var employee = {};
        $http
            .get(url)
                .then(function OnSuccess(response) {
                    
                    employee = response.data;
                    $scope.Employee_Id = employee.Employee_Id;
                    $scope.FName = employee.FirstName;
                    $scope.LName = employee.LastName;
                    $scope.PhoneNo = employee.PhoneNo;
                    $scope.Email_Id = employee.Email_Id;
                    $scope.Age = employee.Age;
                    $scope.Status = employee.Status;
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })
        
    }
    $scope.PutEmployee = function () {
        var url = "http://localhost:4404/EmployeeDetails/" + $scope.Employee_Id;
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
            .put(url, employee)
                .then(function OnSuccess(response) {
                    console.log(response);
                }, function OnFailure(response) {
                    console.log(response);
                })
    }
    $scope.Delete1Employee = function () {
        var url = "http://localhost:4404/EmployeeDetails/" + $scope.Employee_Id1;
        //var url = "http://localhost:4404/EmployeeDetails/acds";
        var employee = {};
        $http
            .get(url)
                .then(function OnSuccess(response) {
                    employee = response.data;
                    $scope.Employee_Id = employee.Employee_Id;
                    $scope.FName = employee.FirstName;
                    $scope.LName = employee.LastName;
                    $scope.PhoneNo = employee.PhoneNo;
                    $scope.Email_Id = employee.Email_Id;
                    $scope.Age = employee.Age;
                    $scope.Status = employee.Status;
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })

    }
    $scope.DeleteEmployee = function () {
        var url = "http://localhost:4404/EmployeeDetails/"+ $scope.Employee_Id;
        $http
            .delete(url, $scope.Employee_Id)
                .then(function OnSuccess(response) {
                    console.log(response.data);
                }, function OnFailure(response) {
                    console.log(response);
                })

    }
}
    
);
