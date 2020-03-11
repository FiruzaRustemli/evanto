(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp.services')
        .factory('selectedEventService', selectedEventService);
    //#endregion

    //#region Dependencies
    selectedEventService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function selectedEventService
        (

        ) {
        var selectedEvent;

        var service = {
            get: getSelectedEvent,
            set: setSelectedEvent
        };

        return service;
        function getSelectedEvent() {
            return selectedEvent;
        }

        function setSelectedEvent(event) {
            selectedEvent = event;
        }
    }
    //#endregion
})();