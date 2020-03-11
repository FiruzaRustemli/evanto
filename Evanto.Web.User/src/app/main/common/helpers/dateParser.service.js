(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('dateParser', dateParserService);
    //#endregion

    //#region Dependencies
    dateParserService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function dateParserService
        (

        ) {

        var service = {
            parse: parse
        };

        return service;

        // Parses to valid string date
        function parse(dateString) {
            var parts = dateString.split("/");
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }

    }
    //#endregion
})();