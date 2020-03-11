(function () {
/*    'use strict';

    //#region Module
    angular
        .module('app.home')
        .controller('HomeController', homeController);
    //#endregion

    //#region Dependencies
    homeController.$inject =
        [
            // Angular components
            '$scope',
            '$filter',

            // 3rd Party Components
            '$mdDialog',
            '$state',

            // Custom components
            'localStorage',
            'widgetService',
            'eventCountService',
            'eventResourceService',
            'navbarHelper',
            'eventAndBookingsCountService',
            'bookingResourceService',
            'userInfo',
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function homeController
        (
        $scope,
        $filter,
        $mdDialog,
        $state,
        localStorage,
        widgetService,
        eventCountService,
        eventResourceService,
        navbarHelper,
        eventAndBookingsCountService,
        bookingResourceService,
        userInfo,
        encodingHelper
        ) {
        jshint validthis:true 
        var vm = this;
        vm.translations = {};
        vm.events = [];
        vm.selectedBookingTab = 0;
        vm.userInfo = {};

        vm.lastEventFilter = 'eventDate';
        vm.lastBookingFilter = 'bookDate';
        vm.isLastBookingsLoaded;
        vm.isLastEventsLoaded;

        vm.refreshCounts = getEventAndBookingsCount;
        vm.showEventInfo = showEventInfo;
        vm.addEvent = addEvent;
        vm.showNextBookingTab = showNextBookingTab;
        vm.getBackToBookingList = getBackToBookingList;

        activate();

        function activate() {
            setNavbarItem('Home');
            getUserInfo()
            getLastEvents();
            getLastBookings();
            getEventAndBookingsCount();
        }

        function getUserInfo() {
            vm.userInfo = userInfo.get();
        }

        function showEventInfo(event) {

            // Popup removed here
            //$scope.eventInfo = event;

            //$mdDialog.show({  
             //   scope: $scope,
            //    preserveScope: true,
             //   templateUrl: 'app/main/event/eventInfo.html',
             //   parent: angular.element(document.body)
           // });

            $state.transitionTo('app.event', {
                'id': encodingHelper.encode(event.id)
            });
        }

        // Sets navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function getEventAndBookingsCount() {
            eventAndBookingsCountService.getData().then(function (response) {
                var data = response.data.output;
                vm.allBookingsCount = data.rejectedBookingsCount + data.waitingBookingsCount + data.confirmedBookingsCount;
                vm.allEventsCount = data.eventsCount;
            });
        };

        function getBackToBookingList() {
            vm.selectedBookingTab = 0;
        };

        function showNextBookingTab(booking) {
            vm.selectedBookingTab = 1;
            vm.selectedBooking = booking;
        }

        function getLastEvents() {
             vm.isLastEventsLoaded = false;
            eventResourceService.resource().lastUserEvents().$promise.then(function (response) {
                vm.lastEvents = response.output.userEvents;
                vm.isLastEventsLoaded = true;
            });
        };

        function getLastBookings() {
            vm.isLastBookingsLoaded = false;
            bookingResourceService.resource().lastBookings().$promise.then(function (response) { 
                vm.lastBookings = response.output.bookings;
                vm.isLastBookingsLoaded = true;
            });
        };

        function addEvent() {
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
    //#endregion */
})();


