validatorModule
  .directive('number', function () {
      var numberRegex = /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/;

      var checkNumber = function (value) {
          if (angular.isEmpty(value))
              return true;

          return numberRegex.test(value);
      };

      return {
          restrict: 'A',

          require: 'ngModel',
          link: function (scope, ele, attrs, ctrl) {
              ctrl.$parsers.unshift(function (value) {

                  var valid = checkNumber(value);
                  ctrl.$setValidity('number', valid);
                  return value;
              });

              ctrl.$formatters.unshift(function (value) {

                  var valid = checkNumber(value);
                  ctrl.$setValidity('number', valid);
                  return value;
              });
          }
      };
  })