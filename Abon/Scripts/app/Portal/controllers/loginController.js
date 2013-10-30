controllerModule
    .controller('loginController', ['$scope', 'scopeHelper', function ($scope, helper) {

        helper.addDataToScope($scope, 'loginData');

    }]);