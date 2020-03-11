(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('vendorServicePacketService', vendorServicePacketService);
    //#endregion

    //#region Dependencies
    vendorServicePacketService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function vendorServicePacketService
        (
            $resource,
            appSettings
        )
    {
        var service = {
            resource: resource
        };

        return service;

        function resource() {
            return $resource(appSettings.apiUrlV1() + 'vendor/vendorServicePacket',
                {
                    query: { method: 'GET', IsArray: false },
                    update: { method: 'PUT' }
                });
        }
    }
    //#endregion
})();