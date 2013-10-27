controllerModule
    .controller('offersController', ['$scope', 'scopeHelper', 'offersService', function($scope, helper, service) {

        helper.addDataToScope($scope, 'userOffersData');
            
        $scope.categoryHeaderHidden = function () {
            return $scope.selectedCategory.parentId == null;
        }


        $scope.categoryId = $scope.selectedCategory.id;
        $scope.template = 'three.html';

        $scope.$on('offers-categoryClicked', function (event, categoryId) {
            $scope.categoryId = categoryId;

            getOffers();
        });

        $scope.$on('offers-pageClicked', function (event, page) {
            $scope.page = page;

            getOffers();
        });

        $scope.$on('offers-filterClicked', function (event, data) {
            $scope.priceFrom = data.priceFrom;
            $scope.priceTo = data.priceTo;
            $scope.cityId = data.cityId;

            getOffers();
        });

        $scope.changeView = function (view) {
            $scope.template = view;
        }


        function prepareSearchParams() {
            var params = {
                categoryId: $scope.categoryId,
                name: $scope.name,
                priceTo: $scope.priceTo,
                priceFrom: $scope.priceFrom,
                cityId: $scope.cityId,
                page:$scope.page
            };
            return params;
        }

        function getOffers() {
            var params = prepareSearchParams();
            service.getOffers(params).then(function(obj) {
                $scope.offers = obj.data.offers;
                $scope.selectedCategory = obj.data.selectedCategory;
                $scope.offers = obj.data.offers;

                $scope.$broadcast('offers-offersReceived', obj.data);
            });
        }


    }]);