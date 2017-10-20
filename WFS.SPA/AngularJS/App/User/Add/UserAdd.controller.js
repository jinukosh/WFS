﻿WFSControllers.controller('UserAddController',
    ['$scope', '$routeParams', 'UserService',
        function ($scope, $routeParams, userService) {
            $scope.userAdd = _userAdd;
            $scope.user;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

            $scope.commonusertype = {};
            $scope.commonusertypes = [
                { Id: 1, Name: 'Admin' },
                { Id: 2, Name: 'User' },
                { Id: 3, Name: 'Client' },
            ];

            init();

            function init() {

                $scope.user = {
                    Name: "",
                    Email: "",
                    UserType: 0,
                    Password:"",
                    IsDeleted: false
                }
                $scope.allowValidation = false;
            }

            function _validatePage(flag) {
                if (!flag) {
                    toastr.error("Please fill in the required fields");
                    $scope.allowValidation = true;
                }

                return true;
            }

            function _userAdd() {

                $scope.user.UserType = $scope.commonusertype.selected.Id;
                
                var currentUser = {
                    User: $scope.user
                };

                userService.userAdd(currentUser.User).then(function (data) {
                    if (data.State == 0) {
                        toastr.success(data.Message);
                        $scope.user = null;
                       $scope.commonusertype.selected = null;
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });

                $scope.allowValidation = false;
            }
        }]);