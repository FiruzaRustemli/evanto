(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('serviceService', serviceService);
    //#endregion

    //#region Dependencies
    serviceService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function serviceService
        (
            $http,
            appSettings
        ) {
        var service = {
            getData: getData
        };

        return service;
        function getData() {
            /// <summary>
            /// <para> Gets event types from the server. </para>
            ///</summary>
            /// <returns type="Evanto Booking Resource"></returns>

            return $http.get(appSettings.apiUrlV1() + 'services/user');

        }

    }
    //#endregion
})();