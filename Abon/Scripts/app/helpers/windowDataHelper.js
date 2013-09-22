angular.module('Abon.helpers', [])
    .service('windowDataHelper', ['$window', function ($window) {

        function getInitScopeFromWindow(name) {
            var data = $window[name];
            return data;
        }

        function addInitDataToScope($scope, name) {
            var data = getInitScopeFromWindow(name);

            for (var prop in data) {
                if (data.hasOwnProperty(prop)) {
                    $scope[prop] = data[prop];
                }
            }

        }

        return {
            addInitDataToScope: addInitDataToScope,
            getInitScopeFromWindow: getInitScopeFromWindow
        };


    }])