WFSControllers.controller('NoteEditController',
    ['$scope', '$routeParams', 'NoteService',
        function ($scope, $routeParams, noteService) {
            $scope.noteEdit = _noteEdit;
            $scope.note;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

        	init();

        	function init() {
        	    if ($routeParams.Id != null) {
        	        noteService.noteRetrieve($routeParams.Id).then(function (data) {
        	            $scope.note = data;
        	        });
        	    }

        	    $scope.allowValidation = false;
        	}

        	function _validatePage(flag)
        	{
        	    if (!flag) {
        	        toastr.error("Please fill in the required fields");
        	        $scope.allowValidation = true;
        	    }
        	    
        	    return true;
        	}

        	function _noteEdit() {
        	    
        	    var currentNote = {
        			Note: $scope.note
        	    };

        	    noteService.noteEdit(currentNote.Note).then(function (data) {
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