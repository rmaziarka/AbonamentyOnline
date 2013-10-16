
/// <reference path="/Scripts/angularjs/angular.js"/>
/// <reference path="/Scripts/angularjs/angular-mocks.js"/>
/// <reference path="/Scripts/app/helpers/scopeHelper.js"/>

beforeEach(function() {
    module('Abon.helpers');
});

describe('Window data helper test', function() {


    var helper;


    beforeEach(inject(function(scopeHelper) {
        helper = scopeHelper;
    }));


    var simple = 12;
    var complex = { "asd": "asd", "cc": "cc" };

    window.controllerData = { simple: simple, complex: complex };

    it('addDataFromProperty should add data to scope only from property', function() {
        var scope = {};

        helper.addDataFromProperty(scope, 'controllerData', 'complex');
        expect(scope.simple).not.toBe(12);
        expect(scope.complex.asd).toBe('asd');

    });

    it('addDataToScope should add data to scope', function() {

        var scope = {};

        helper.addDataToScope(scope, "controllerData");
        expect(scope.simple).toBe(12);
        expect(scope.complex.asd).toBe('asd');

    });


    it('getInitScopeFromWindow should return data from window', function() {

        var data = helper.getInitScopeFromWindow("controllerData");

        expect(data).toBe(window.controllerData);
    });


});

describe('ValidatorCommon testing', function() {

    beforeEach(function() {
        module('PhoneApp.common');
    });

    describe('isValidNumber testing', function() {
        var common;

        beforeEach(inject(function(ValidationCommon) {
            common = ValidationCommon;
        }));

        it('return false when ""', function() {
            var value = '';
            var isValid = common.isValidNumber(value);

            expect(isValid).toBe(false);
        });

        it('return false when "2a"', function() {
            var value = '2a';
            var isValid = common.isValidNumber(value);

            expect(isValid).toBe(false);
        });

        it('return false when undefined', function() {
            var value = undefined;
            var isValid = common.isValidNumber(value);

            expect(isValid).toBe(false);
        });


        it('return true when "2"', function() {
            var value = '2';
            var isValid = common.isValidNumber(value);

            expect(isValid).toBe(true);
        });

        it('return true when 2', function() {
            var value = 2;
            var isValid = common.isValidNumber(value);

            expect(isValid).toBe(true);
        });
    });
});