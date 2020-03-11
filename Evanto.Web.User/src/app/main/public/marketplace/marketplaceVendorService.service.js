(function () {
    'use strict';

    //#region Module
    angular
        .module('app.public.marketplace')
        .factory('marketplaceVendorServiceService', marketplaceVendorServiceService);
    //#endregion

    //#region Dependencies
    marketplaceVendorServiceService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function marketplaceVendorServiceService
        (
        $http,
        appSettings
        ) {
        var service = {
            getData: getData
        };

        return service;
        function getData(parameters) {
            /// <summary>
            /// <para> Gets event types from the server. </para>
            ///</summary>
            /// <returns type="Evanto Booking Resource"></returns>

            return $http({
                url: appSettings.apiUrlV1() + 'public/vendorService',
                method: "GET",
                params: parameters
            });

        }

    }
    //#endregion
})();