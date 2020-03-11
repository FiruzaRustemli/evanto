(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.directives')
        .directive('windowWidth', windowWidthDirective);
    //#endregion

    //#region Dependencies
    windowWidthDirective.$inject =
        [
            // Angular components
            '$window'

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function windowWidthDirective($window) {
        return {
            link: link,
            restrict: 'E'
        };

        function link(scope, element, attrs) {

            angular.element($window).bind('resize', function () {
                scope.windowWidth = $window.innerWidth;
            });
        };
    }
    //#endregion 
})();



