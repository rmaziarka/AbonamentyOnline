controllerModule
    .controller('menuController', ['$scope','$timeout','scopeHelper', function ($scope,$timeout,windowHelper) {

        windowHelper.addDataToScope($scope, 'menuData');

        var closeMenuFunc = angular.noop;

        $scope.openedCategoryId = null;

        $scope.openMenu = function (id, openedImageId) {
            $timeout.cancel(closeMenuFunc);
            
            if (angular.isDefined(id)) {
                $scope.openedCategoryId = id;
                $scope.openedImageId = openedImageId;
            }
        };


        $scope.closeMenu = function () {
            closeMenuFunc = $timeout(function () {
                $scope.openedCategoryId = null;
            }, 50);
        };

        $scope.openImage = function (id) {
            $scope.openedImageId = id;
        }

    }]);