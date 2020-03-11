(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('serviceEventService', serviceEventService);
    //#endregion

    //#region Dependencies
    serviceEventService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function serviceEventService
        (
        ) {

        var serviceEvent;

        var service = {
            get: getServiceEvent,
            set: setServiceEvent
        };

        return service;
        
        function getServiceEvent() {
            return serviceEvent;
        }

        function setServiceEvent(event) {
            serviceEvent = event;
        }

    }
    //#endregion
})();