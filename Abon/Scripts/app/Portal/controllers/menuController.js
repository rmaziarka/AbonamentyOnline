angular.module('Abon.Portal.controllers', ['ui.bootstrap','Abon.helpers'])
    .controller('menuController', ['$scope','$timeout','windowDataHelper', function ($scope,$timeout,windowHelper) {

        windowHelper.addInitDataToScope($scope, 'MenuData');
        var openedCategory = null;
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
        var openElement = null,
            closeMenu = angular.noop;
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
                                    '<li ng-repeat="subcat in openedCategory.children">{{subcat.name}}</li>'+
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