WFSControllers.controller('NoteListController',
    ['$scope', '$routeParams', '$modal', 'NoteService',
        function ($scope, $routeParams, $modal, noteService) {
            $scope.note = [];
            $scope.noteDelete = _noteDelete;
            $scope.colors = [{
                "id": "Blue",
                "name": "blue",
                "checked": true
            }, {
                "id": "Yellow",
                "name": "warning",
                "checked": true
            }, {
                "id": "Red",
                "name": "error",
                "checked": true
            }];
            $scope.filterChanged = _filterChanged;

            init();

            function init() {

                noteList();
            }

            function _filterChanged(choice) {
                var details = [];
                angular.forEach(choice, function (value, key) {
                    if (choice[key].checked) {
                        details.push(choice[key].id);
                    }
                });
                if (details.length > 0) {
                    noteService.noteList(details.toString()).then(function (data) {
                        if (data.State == 0) {
                            $scope.note = data.Result;
                        }
                        else {
                            toastr.error(data.Message, "Error");
                        }
                    });
                }
                else {
                    $scope.note = [];
                    toastr.error("Please select atleast one option");
                }
            };


            function noteList() {
                noteService.noteList().then(function (data) {

                    if (data.State == 0) {
                        $scope.note = data.Result;
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });
            }

            function _noteDelete(Id) {
                noteService.noteDelete(Id).then(function (data) {
                    if (data.State == 0) {
                        toastr.success(data.Message);
                        noteList();
                    }
                    else {
                        toastr.error(data.Message, "Error");
                    }
                });
            }
        }]);
