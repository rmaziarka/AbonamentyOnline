controllerModule
    .controller('externalRegisterController', ['$scope', 'scopeHelper', function ($scope, helper) {

        helper.addDataToScope($scope, 'externalLoginData');

    }]);