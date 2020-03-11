(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.filters')
        .filter('pascalcase', pascalCaseTextCreatorFilter);
    //#endregion

    //#region Dependencies
    pascalCaseTextCreatorFilter.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components

        ];
    //#endregion

    //#region Function
    function pascalCaseTextCreatorFilter() {

        return function (text) {
            var capitalized = text.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });

            return capitalized.replace(/ /g,'')
        }
    }
    //#endregion 
})();



