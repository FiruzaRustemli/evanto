(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('eventAndBookingsCountService', eventAndBookingsCountService);
    //#endregion

    //#region Dependencies
    eventAndBookingsCountService.$inject =
        [
            // Angular components
            '$http',

            // 3rd Party Components

            //Custom Components
            'appSettings'
        ];
    //#endregion

    //#region Function
    function eventAndBookingsCountService
        (
            $http,
            appSettings
        ) {
        var service = {
            getData: getData
        };

        return service;
        function getData() {
            return $http.get(appSettings.apiUrlV1() + 'events/user/eventsBookingsCount');
        }

    }
    //#endregion
})();