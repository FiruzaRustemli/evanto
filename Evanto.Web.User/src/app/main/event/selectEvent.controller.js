(function () {
    'use strict';

    //#region Module
    angular
        .module('app.vendor')
        .controller('SelectEventController', selectEventController);
    //#endregion

    //#region Dependencies
    selectEventController.$inject =
        [
            // Angular components
            '$scope',
            '$timeout',

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'eventResourceService',
            'selectedEventService'
        ];
    //#endregion

    //#region Function
    function selectEventController
        (
        $scope,
        $timeout,
        $mdDialog,
        eventResourceService,
        selectedEventService
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.events = [];

        vm.addEvent = addEvent;
        vm.cancel = cancelDialog;
        vm.setSelectedEvent = setSelectedEvent;
        vm.selectedEvent = null;

        activate();

        function activate() {
            getAllEvents();
        }

        function cancelDialog() {
            $mdDialog.cancel();
        };

        function getAllEvents() {
            eventResourceService.resource().query({}, function (response) {
                vm.events = response.output.userEvents;

                if ($scope.automaticEventSelectionInDialog) {
                    vm.selectedEvent = vm.events[0];
                }
            });
        }

        function setSelectedEvent() {
            if (angular.isDefined(vm.selectedEvent) && angular.isObject(vm.selectedEvent)) {
                selectedEventService.set(vm.selectedEvent);

                $mdDialog.cancel();
            }
        }

        function addEvent() {
            $mdDialog.cancel();

            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/event/new.html',
                    parent: angular.element(document.body),
                    openFrom: '#btnAddNewEvent',
                    focusOnOpen: false
                });
        }
    }
    //#endregion 
})();


