﻿WFSControllers.controller('UserEditController',
    ['$scope', '$routeParams', 'UserService',
        function ($scope, $routeParams, userService) {
            $scope.userEdit = _userEdit;
            $scope.user;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

            //$scope.note = {};
            //$scope.companies = [];
            $scope.commonusertype = {};
            $scope.commonusertypes = [
                { Id: 1, Name: 'Admin' },
                { Id: 2, Name: 'User' },
                { Id: 3, Name: 'Client' },
            ];

            init();

            function init() {

                //noteService.noteList().then(function (data) {
                //    if (data.State == 0) {
                //        $scope.companies = data.Result;
                //    }
                //});

                if ($routeParams.Id != null) {
                    userService.userRetrieve($routeParams.Id).then(function (data) {
                        $scope.user = data;
                        console.log($scope.user);
                        //$scope.note.selected = $scope.user.Note;
                        $scope.commonusertype.selected = $scope.user.CommonUserType;
                    });
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

            function _userEdit() {
                
                //$scope.user.NoteId = $scope.note.selected.Id;
                $scope.user.UserType = $scope.commonusertype.selected.Id;

                var currentUser = {
                    User: $scope.user
                };

                userService.userEdit(currentUser.User).then(function (data) {
                    if (data.State == 0) {
                        toastr.success(data.Message);
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });

                $scope.allowValidation = false;
            }
        }]);