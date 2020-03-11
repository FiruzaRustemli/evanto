(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('vendorServicesService', vendorServicesService);
    //#endregion

    //#region Dependencies
    vendorServicesService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function vendorServicesService
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
            return $resource(appSettings.apiUrlV1() + 'vendorService', { id: '@_id' },
                {
                    query: { method: 'GET', IsArray: false },
                    update: { method: 'PUT' }
                });
        }
    }
    //#endregion
})();