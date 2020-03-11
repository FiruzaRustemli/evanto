(function () {
    'use strict';

    //#region Module
    angular
        .module('app.event')
        .controller('NewEventController', newEventController);
    //#endregion

    //#region Dependencies
    newEventController.$inject =
        [
            // Angular components
            '$timeout',
            '$rootScope',
            '$scope',
            '$filter',

            // 3rd Party Components
            '$mdDialog',
            '$state',

            // Custom components
            'eventTypesService',
            'eventResourceService',
            'translationService',
            'messageService',
            'dateTimeJoinHelper',
            'encodingHelper',
            'dateParser'
        ];
    //#endregion

    //#region Function
    function newEventController
        (
        $timeout,
        $rootScope,
        $scope,
        $filter,
        $mdDialog,
        $state,
        eventTypesService,
        eventResourceService,
        translationService,
        messageService,
        dateTimeJoinHelper,
        encodingHelper,
        dateParser
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.eventTypes = null;
        vm.createButtonDisabled = false;
        vm.newEvent = {};
        vm.isBudgetRequested = false;

        vm.getEventTypes = getEventTypes;
        vm.create = createEvent;
        vm.cancel = cancel;

        vm.now = new Date();

        vm.eventDateRange = {
            minDate: new Date(
                vm.now.getFullYear(),
                vm.now.getMonth(),
                vm.now.getDate()
            )
        }

        $scope.$watch(function () { return vm.isBudgetRequested }, function (newVal, oldVal) {
            if (newVal === false) {
                vm.newEvent.budget = null;
            }
        })

        activate();

        function activate() {
        }

        vm.time = {
            twelve: new Date(),
            twentyfour: new Date()
        };

        function createEvent() {
            vm.createButtonDisabled = true;
            var eventTime = vm.newEvent.selectedHour + ':' + vm.newEvent.selectedMinute;
            var eventDate = $filter('date')(vm.newEvent.eventDateAsDate, 'yyyy-MM-dd');

            vm.newEvent.eventDate = dateTimeJoinHelper.join(eventDate, eventTime);
            eventResourceService.resource().save(vm.newEvent, function (response) {
                $mdDialog.cancel();

                $rootScope.$broadcast('newEventCreated', { 'id': response.output.id });

                messageService.eventCreated($filter('translate')('Toast.Success.EventCreated'), $filter('translate')('Event.ShowEvent')).then(function (toastResponse) {
                    if (toastResponse == 'ok') {
                        $state.transitionTo('app.event', {
                            'id': encodingHelper.encode(response.output.id)
                        });
                    }
                });

            }, function () {
                vm.createButtonDisabled = false;
            });
        };

        function cancel() {
            $mdDialog.cancel();

            $rootScope.$broadcast('eventCreationCancelled')
        }

        function getEventTypes() {
            if (vm.eventTypes === null) {
                return $timeout(function () {
                    eventTypesService.getData().then(function (response) {
                        vm.eventTypes = response.data.output.eventTypes;
                    });

                }, 1000);
            }
        }

    }
    //#endregion 
})();


