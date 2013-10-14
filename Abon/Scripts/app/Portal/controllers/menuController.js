controllerModule
    .controller('menuController', ['$scope','$timeout','scopeHelper', function ($scope,$timeout,windowHelper) {

        windowHelper.addDataToScope($scope, 'menuData');
        var closeMenuFunc = angular.noop;

        $scope.openedCategory = null;

        $scope.openMenu = function (cat) {
            $timeout.cancel(closeMenuFunc);
            
            if (angular.isDefined(cat)) {
                $scope.openedCategory = cat;
                $scope.$apply();
            }
        };


        $scope.closeMenu = function () {
            closeMenuFunc = $timeout(function () {
                $scope.openedCategory = null;
                $scope.$apply();
            }, 10);
        };

    }])
    .directive('horMenu', function () {
        return {            
            restrict: 'E',
            replace: true,
            scope:true,
            controller: 'menuController',
            template: '<div class="nav-collapse collapse" >' +
                           ' <ul class="nav" id="categories">' +
                                '<hor-menu-item ng-repeat="cat in categories" class="dropdown"> </hor-menu-item>' +
                            '</ul>'+
                            '<div ng-mouseenter="openMenu()" ng-mouseleave="closeMenu()" ng-show="openedCategory != null" class="subcategoryDiv">' +
                                '<ul>'+
                                    '<li ng-repeat="subcat in openedCategory.children"><a ng-href="/UserOffers?categoryId={{subcat.id}}">{{subcat.name}}</a></li>' +
                                '</ul>'+
                            '</div>'
        };
    })
    .directive('horMenuItem', function () {
        return {
            restrict: 'E',
            scope:true,
            replace: true,
            template:   '<li >' +
                            '<a>{{cat.name}}</a>' +
                        '</li>',
            link: function (scope, element, attrs, cat) {
                element.bind('mouseenter', function(event) {
                    scope.openMenu(scope.$parent.cat);
                });
                element.bind('mouseleave', function (event) {
                    scope.closeMenu();
                });
            }
        };
    })