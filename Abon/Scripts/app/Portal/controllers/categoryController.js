controllerModule
    .controller('categoryController', ['$scope', 'scopeHelper', function ($scope, helper) {
        
        helper.addDataFromProperty($scope, 'userOffersData', 'selectedCategory');

        $scope.categoryClicked = function(categoryId) {
            $scope.$emit('offers-categoryClicked', categoryId);
        };

        $scope.$on('offers-offersReceived', function (event, data) {
            $scope.selectedCategory = data.selectedCategory;
        });

    }]);