controllerModule
    .controller('pagerController', ['$scope', 'scopeHelper', function ($scope, helper) {

        helper.addDataToScope($scope, 'userOffersData');
        $scope.pageChanged = function (page) {
            $scope.$emit('offers-pageClicked', page);
        }

        $scope.$on('offers-offersReceived', function (event, data) {
            $scope.page = data.page;
            $scope.take = data.take;
            $scope.offers.total = data.offers.total;
        });

    }]);