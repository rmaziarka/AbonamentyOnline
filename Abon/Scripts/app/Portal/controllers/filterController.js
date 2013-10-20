controllerModule
    .controller('filterController', ['$scope', 'scopeHelper', function($scope, helper) {

        helper.addDataFromProperty($scope, 'userOffersData', 'cities');

        $scope.filter = function () {
            var data = {
                cityId: this.cityId,
                priceFrom: this.priceFrom,
                priceTo: this.priceTo,
            }

            $scope.$emit('offers-filterClicked', data);
        };



    }]);