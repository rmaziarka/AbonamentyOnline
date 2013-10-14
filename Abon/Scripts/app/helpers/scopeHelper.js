angular.module('Abon.helpers', [])
    .service('scopeHelper', ['$window', function ($window) {

        function getInitScopeFromWindow(name) {
            var data = $window[name];
            return data;
        }

        function addDataToScopeFromProperty($scope, name, property) {

            var data = getInitScopeFromWindow(name);
            
            for (var prop in data) {
                if (data.hasOwnProperty(prop) && prop === property) {
                    $scope[prop] = data[prop];
                }
            }
        }

        function addDataToScope($scope, name) {

            var data = getInitScopeFromWindow(name);
            for (var prop in data) {
                if (data.hasOwnProperty(prop)) {
                    $scope[prop] = data[prop];
                }
            }

        }

        return {
            addDataToScope: addDataToScope,
            getInitScopeFromWindow: getInitScopeFromWindow,
            addDataFromProperty: addDataToScopeFromProperty
        };


    }])