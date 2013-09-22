angular.module('Abon.validators',[])
    .directive('email', function () {
        var emailRegex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        var checkEmail = function (value) {
            if (_.isEmpty(value))
                return true;

            return emailRegex.test(value);
        };

        return {
            restrict: 'A',

            require: 'ngModel',
            link: function (scope, ele, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {

                    var valid = checkEmail(value);
                    ctrl.$setValidity('email', valid);
                    return value;
                });

                ctrl.$formatters.unshift(function (value) {

                    var valid = checkEmail(value);
                    ctrl.$setValidity('email', valid);
                    return value;
                });
            }
        };
    })