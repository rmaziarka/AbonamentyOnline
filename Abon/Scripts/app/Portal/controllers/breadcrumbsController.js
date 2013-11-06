controllerModule
    .controller('breadcrumbsController', ['$scope', 'scopeHelper', function ($scope, helper) {
        
        helper.addDataFromProperty($scope, 'userOffersData', 'selectedCategory');

        function createParentList() {
            $scope.parentCategories = [];

            var category = $scope.selectedCategory;

            while (category.parentId != null) {
                category = category.parent;
                $scope.parentCategories.unshift(category);
            }

        }

        $scope.categoryClicked = function(categoryId) {
            $scope.$emit('offers-categoryClicked', categoryId);
        };

        $scope.$on('offers-offersReceived', function (event, data) {
            $scope.selectedCategory = data.selectedCategory;
            createParentList();
        });

        createParentList();

    }]);