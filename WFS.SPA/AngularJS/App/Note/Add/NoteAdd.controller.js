WFSControllers.controller('NoteAddController',
    ['$scope', '$routeParams', 'NoteService',
        function ($scope, $routeParams, noteService) {
            $scope.noteAdd = _noteAdd;            
            $scope.note;
            $scope.validatePage = _validatePage;
            $scope.allowValidation;

            $scope.clickBack = function () {
                window.history.back();
            };

        	init();

        	function init() {
        	    $scope.note = {
        	        Name: "",
                    Details:"",
        	        Color:"blue",
        	        IsDeleted: false                   
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

        	function _noteAdd() {
        	    
        	    var currentNote = {
        			Note: $scope.note
        	    };

        	    noteService.noteAdd(currentNote.Note).then(function (data) {
        	        if (data.State == 0) {
        	            toastr.success(data.Message);
        	            $scope.note = null;
        	        }
        	        else {
        	            toastr.error(data.Message, "Error");
        	        }
        	    });

        	    $scope.allowValidation = false;
        	}
        }]);