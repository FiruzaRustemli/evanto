(function () {
    'use strict';

    //#region Module
    angular
        .module('app.user')
        .directive('imageonload', imageonloadDirective);
    //#endregion

    //#region Dependencies
    imageonloadDirective.$inject =
        [
            // Angular components
            '$location',

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function imageonloadDirective($location) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('load', function () {
                    scope.$apply(attrs.imageonload);
                });
            }
        };
    }
    //#endregion 
})();

