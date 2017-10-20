publication.factory('NoteService', ['$http', '$q', function ($http, $q) {
    return {
        noteAdd: _noteAdd,
        noteEdit: _noteEdit,
        noteRetrieve: _noteRetrieve,
        noteList: _noteList,
        noteDelete: _noteDelete,
    };

    function _noteRetrieve(Id) {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('Note/Retrieve'), params: { "Id": Id } }).
            success(function (data, status, headers, config) {
                deferred.resolve(data.Result);
            });

        return deferred.promise;
    }

    function _noteList() {
        var deferred = $q.defer();

        $http({ method: 'POST', url: config.generateApiUrl('Note/GetAll') }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _noteList(Id) {
        var deferred = $q.defer();
        $http({ method: 'POST', url: config.generateApiUrl('Note/GetAll'), params: { "Id": Id } }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _noteEdit(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";
        
        $http({ method: httpMethod, url: config.generateApiUrl('Note/Edit'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _noteDelete(Id) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('Note/Delete'), params: { "Id": Id } }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

        return deferred.promise;
    }

    function _noteAdd(obj) {
        var deferred = $q.defer();

        var httpMethod = "POST";

        $http({ method: httpMethod, url: config.generateApiUrl('Note/Add'), data: JSON.stringify(obj) }).
           success(function (data, status, headers, config) {
               deferred.resolve(data);
           });

           return deferred.promise;
    }
}]);