(function () {
    'use strict';

    //#region Module
    angular
         .module('evantoApp.services')
         .factory('eventCountService', eventCountService);
    //#endregion

    //#region Dependencies
    eventCountService.$inject =
        [
            // Angular components

            // 3rd Party Components

            //Custom Components
        ];
    //#endregion

    //#region Function
    function eventCountService
        (
        ) {
        var data = {
            count: 0,
            valueType: ''
        }

        var service = {
            set: set,
            get: get,
            setValueType: setValueType
        };

        return service;

        function set(count) {
            data.count = count;
        }

        function get() {
            return data;
        }

        function setValueType(quantityValueType) {
            data.valueType = quantityValueType;
        }

    }
    //#endregion
})();