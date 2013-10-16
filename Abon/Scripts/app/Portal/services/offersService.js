serviceModule
.service('offersService', ['$http','$q', function ($http,$q) {

    return {
        getOffers: function (params) {

            var deferred = $q.defer();

            $http.get('/UserOffers/Get', {
                params: params
            })
                .success(function (obj) {
                    deferred.resolve(obj);
                })
                .error(function(reason) {
                    deferred.reject(reason);
                });
            return deferred.promise;
        }
    };
} ]);