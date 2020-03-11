(function () {
    'use strict';

    //#region Module
    angular
        .module('app.event')
        .controller('EventCountController', eventCountController);
    //#endregion

    //#region Dependencies
    eventCountController.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components
            'eventCountService'
        ];
    //#endregion

    //#region Function
    function eventCountController
        (
            eventCountService
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'EventCountController';

        function getCount() {
            return eventCountService.get();
        }


        activate();


        function activate() {
            vm.eventCount = getCount();
        }

    }
    //#endregion 
})();


