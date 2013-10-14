controllerModule
    .controller('offersController', ['$scope', 'scopeHelper', 'offersService', function($scope, helper, service) {

        helper.addDataToScope($scope, 'userOffersData');

        $scope.categoryHeaderVisible = $scope.selectedCategory.id !== '00000000-0000-0000-0000-000000000000';

        $scope.template = 'gallery.html';

        $scope.$on('offers-categoryClicked', function(event, categoryId) {
            var params = {
                categoryId: categoryId,
                name: $scope.name
            };
            getOffers(params);
        });


        function getOffers(params) {
            service.getOffers(params).then(function(obj) {
                $scope.offers = obj.data.offers;
                $scope.selectedCategory = obj.data.selectedCategory;
                $scope.offers = obj.data.offers;

                $scope.$broadcast('offers-offersReceived', obj.data);

            });
        }


    }]);