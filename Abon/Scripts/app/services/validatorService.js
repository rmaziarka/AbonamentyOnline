serviceModule
.service('validatorService', ['$http','$q', 'spinner', function ($http,$q, spinner) {
    return {
        checkUnique: function (value, type) {

            var deferred = $q.defer();
            $http.get('/Account/CheckUnique?value=' + value + '&type='+type)
                .success(function (obj) {
                    deferred.resolve(obj.data);
                })
                .error(function () {
                    deferred.reject();
                });
            return deferred.promise;
        }
    };
}]);