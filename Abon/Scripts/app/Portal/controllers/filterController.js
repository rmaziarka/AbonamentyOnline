controllerModule
    .controller('filterController', ['$scope', 'scopeHelper', function($scope, helper) {

        helper.addDataToScope($scope, 'userOffersData');

        $scope.categoryHeaderVisible = $scope.selectedCategory.parentId === null;

        $scope.template = 'three.html';

        $scope.$on('offers-categoryClicked', function(event, categoryId) {
            var params = {
                categoryId: categoryId,
                name: $scope.name
            };
            getOffers(params);
        });

        $scope.changeView = function (view) {
            $scope.template = view;
        }


        function getOffers(params) {
            service.getOffers(params).then(function(obj) {
                $scope.offers = obj.data.offers;
                $scope.selectedCategory = obj.data.selectedCategory;
                $scope.offers = obj.data.offers;

                $scope.$broadcast('offers-offersReceived', obj.data);

            });
        }


    }]);