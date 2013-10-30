validatorModule
    .directive('unique', ['$timeout', 'validatorService', function ($timeout, service) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, ele, attrs, ctrl) {
                var stopTimeout;
                scope.$watch(attrs.ngModel, function (value) {
                    $timeout.cancel(stopTimeout);
                    ctrl.$setValidity('unique', true);
                    var type = attrs['unique'];

                    if (value === undefined || value === null) {
                        return;
                    }

                    if (ctrl.$invalid && !ctrl.$error.unique) {
                        return;
                    }

                    stopTimeout = $timeout(function () {
                        service.checkUnique(value, type).then(
                            function (data) {
                                ctrl.$setValidity('unique', data.unique);
                            },
                            function () {
                                ctrl.$setValidity('unique', false);
                            }
                        );
                    }, 500);

                    return;
                });
            }
        };
    } ]);