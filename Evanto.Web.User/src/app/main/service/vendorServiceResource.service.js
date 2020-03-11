(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('vendorServiceResourceService', vendorServiceService);
    //#endregion

    //#region Dependencies
    vendorServiceService.$inject =
        [
            // Angular components
            '$resource',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function vendorServiceService
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
            return $resource(appSettings.apiUrlV1() + 'services/user/vendorServices', { id: '@_id' },
                {
                    query: { method: 'GET',  IsArray: false },
                    get: { method: 'GET',  IsArray: false },
                    topServices : {method: 'GET', url: appSettings.apiUrlV1() + 'services/user/topVendorServices', IsArray: false}
                });
        }
    }
    //#endregion
})();