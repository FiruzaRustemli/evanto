(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('encodingHelper', encodingHelperService);
    //#endregion

    //#region Dependencies
    encodingHelperService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function encodingHelperService
        (
        ) {
        var service = {
            encode: encodeResource,
            decode: decodeResource
        };

        var hashids = new Hashids('Evanto', 100, 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890')

        return service;
        function encodeResource(resource) {
            return hashids.encode(resource);
        }

        function decodeResource(resource) {
            return hashids.decode(resource);
        }
    }
    //#endregion
})();