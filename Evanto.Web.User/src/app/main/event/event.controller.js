(function () {
    'use strict';

    //#region Module
    angular
        .module('app.event')
        .controller('EventController', eventController);
    //#endregion

    //#region Dependencies
    eventController.$inject =
        [
            // Angular components
            '$scope',
            '$rootScope',

            // 3rd Party Components
            '$mdDialog',
            '$mdMedia',
            '$state',

            // Custom components
            'eventResourceService',
            'translationService',
            'navbarHelper',
            'encodingHelper',
            'events',
            'fuseTheming'
        ];
    //#endregion

    //#region Function
    function eventController
        (
        $scope,
        $rootScope,
        $mdDialog,
        $mdMedia,
        $state,
        eventResourceService,
        translationService,
        navbarHelper,
        encodingHelper,
        events,
        fuseTheming
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.$mdMedia = $mdMedia;

        vm.events = events.output.userEvents;
        vm.searchText = null;
        vm.activeTheme = fuseTheming.themes.active;
        vm.searchText = null;

        vm.eventActionMode = {
            hovered: 'full',
            unhovered: 'alt'
        }

        vm.addEvent = addEvent;
        vm.goToEventPage = goToEventPage;
        vm.eventHovered = eventHovered;
        vm.eventUnHovered = eventUnHovered;

        $scope.$watch(function () { return vm.searchText }, function (newVal, oldVal) {
            if (newVal != oldVal) {
                getEventsFiltered()
            }
        });

         $scope.$watch(function () { return vm.searchText }, function (newVal, oldVal) {
            if (newVal != oldVal && newVal !== null) {
                if (navbarHelper.getCurrentNavItem() === 'Events') {
                    $rootScope.$broadcast('eventSearchRequested', { searchText: vm.searchText })
                }
                else if (navbarHelper.getCurrentNavItem() === 'Bookings') {
                    $rootScope.$broadcast('bookingSearchRequested', { searchText: vm.searchText })
                }
            }
        });

        $scope.$on('newEventCreated', function () {
            getAllEvents();
        });

        $scope.$on('eventSearchRequested', function (event, data) {
            getEventsFiltered(data.searchText);
        });

        activate();


        function activate() {
            setNavbarItem('Events');

            setInitialActionModeForEvents();
        }

        // Sets navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function goToEventPage(id) {
            $state.transitionTo('app.event', {
                'id': encodingHelper.encode(id),
            });
        }

        function getEventsFiltered(searchText) {
            eventResourceService.resource().get({
                searchText: searchText
            }).$promise.then(function (response) {
                vm.events = [];
                vm.events = response.output.userEvents;
                setInitialActionModeForEvents();
            });
        }

        function addEvent() {
            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/event/new.html',
                    parent: angular.element(document.body),
                    openFrom: '.btnAddNewEvent',
                    focusOnOpen: false
                });
        }

        function setInitialActionModeForEvents() {
            angular.forEach(vm.events, function (value, key) {
                value.actionMode = vm.eventActionMode.unhovered;
            });
        }

        function getAllEvents() {
            eventResourceService.resource().get().$promise.then(function (response) {
                vm.events = response.output.userEvents;
            });
        }

        function eventHovered(event) {
            if (event.actionMode === vm.eventActionMode.unhovered) {
                event.actionMode = vm.eventActionMode.hovered;
            }
        }

        function eventUnHovered(event) {
            if (event.actionMode === vm.eventActionMode.hovered) {
                event.actionMode = vm.eventActionMode.unhovered;
            }
        }
    }
    //#endregion 
})();


