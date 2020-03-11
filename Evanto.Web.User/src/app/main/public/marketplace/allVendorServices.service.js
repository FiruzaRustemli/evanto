(function () {
    'use strict';

    //#region Module
    angular
        .module('app.public.marketplace')
        .factory('allVendorServicesService', allVendorServicesService);
    //#endregion

    //#region Dependencies
    allVendorServicesService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function allVendorServicesService
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
                url: appSettings.apiUrlV1() + 'public/vendorServices',
                method: "GET",
                params: parameters
            });

        }

    }
    //#endregion
})();