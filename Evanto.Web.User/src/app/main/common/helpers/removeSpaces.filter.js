(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.filters')
        .filter('removeSpaces', removeSpacesFilter);
    //#endregion

    //#region Dependencies
    removeSpacesFilter.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function removeSpacesFilter() {

        return function (text) {
            if (!angular.isString(text)) {
                return text;
            }

            return text.replace(/[\s]/g, '');
        }
    }
    //#endregion 
})();



