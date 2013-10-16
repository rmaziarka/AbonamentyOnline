
/// <reference path="/Scripts/angularjs/angular.js"/>
/// <reference path="/Scripts/angularjs/angular-mocks.js"/>
/// <reference path="/Scripts/angularjs/ui-bootstrap-tpls-0.6.0.js"/>
/// <reference path="/Scripts/app/helpers/scopeHelper.js"/>
/// <reference path="/Scripts/app/Portal/controllers/offersController.js"/>


beforeEach(function () {
    module('Abon.Portal.controllers');
});

describe('Offer controller test', function () {
    var $scope;
    var ctrl;
  
    var helper = {
        addDataToScope: function (scope, name) {
            scope['selectedCategory'] = {};
            scope.selectedCategory['id'] = '00000000-0000-0000-0000-000000000000';
            scope['template'] = 'gallery.html';
        }
    };

    beforeEach(inject(function ($rootScope, $controller, offersController) {
        $scope = $rootScope.$new();
        ctrl = $controller('offersController', {
            $scope: $scope,
            windowHelper: helper
        });
    }));

    it('should set template to gallery.html', function () {
        expect(ctrl).toBe(1);
        //expect($scope.template).toBe('gallery.html');

    });
});
