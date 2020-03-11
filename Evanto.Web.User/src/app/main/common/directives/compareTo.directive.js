(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.directives')
        .directive('compareTo', compareToDirective);
    //#endregion

    //#region Dependencies
    compareToDirective.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function compareToDirective($) {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    }
    //#endregion 
})();



