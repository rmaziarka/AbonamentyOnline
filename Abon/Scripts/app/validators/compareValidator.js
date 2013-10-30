validatorModule
 	.directive('compare', [function () {

 	    return {
 	        require: 'ngModel',
 	        link: function (scope, elem, attrs, ctrl) {
                
 	            scope.$watch(attrs['compare'], function (value) {
 	                if (ctrl.$pristine)
 	                    return;
 	                var compareValue = ctrl.$viewValue;
 	                var valid = value == compareValue;
 	                ctrl.$setValidity('compare', valid);
 	            });

 	            ctrl.$parsers.unshift(function (value) {
 	                var compareWith = attrs['compare'];
 	                var compareValue = scope[compareWith];

 	                var valid = value == compareValue;
 	                ctrl.$setValidity('compare', valid);
 	                return value;
 	            });

 	            ctrl.$formatters.unshift(function (value) {
 	                var compareWith = attrs['compare'];
 	                var compareValue = scope[compareWith];

 	                var valid = value == compareValue;
 	                ctrl.$setValidity('compare', valid);
 	                return value;
 	            });
 	        }
 	    }
 	}]);