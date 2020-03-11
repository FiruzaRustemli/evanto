(function () {
    'use strict';

    //#region Module
    angular
         .module('app.public.marketplace')
         .factory('allEventTypesService', allEventTypesService);
    //#endregion

    //#region Dependencies
    allEventTypesService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function allEventTypesService
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

            return $http.get(appSettings.apiUrlV1() + 'public/eventTypes');

        }

    }
    //#endregion
})();