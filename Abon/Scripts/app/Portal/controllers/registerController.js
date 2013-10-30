controllerModule
    .controller('registerController', ['$scope', 'scopeHelper', function ($scope, helper) {

        helper.addDataToScope($scope, 'registerData');

    }]);