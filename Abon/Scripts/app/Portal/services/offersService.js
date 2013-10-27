serviceModule
.service('offersService', ['$http','$q','spinner', function ($http,$q,spinner) {

    return {
        getOffers: function (params) {
            spinner.start();
            var deferred = $q.defer();

            $http.get('/UserOffers/Get', {
                params: params
            })
                .success(function (obj) {
                    spinner.stop();
                    deferred.resolve(obj);
                })
                .error(function (reason) {
                    spinner.stop();
                    deferred.reject(reason);
                });
            return deferred.promise;
        }
    };
} ]);