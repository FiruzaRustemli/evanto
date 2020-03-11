(function () {
    'use strict';

    //#region Module
    angular
        .module('app.booking')
        .controller('BookingController', bookingController);
    //#endregion

    //#region Dependencies
    bookingController.$inject =
        [
            // Angular components
            '$timeout',
            '$location',
            '$scope',
            '$rootScope',
            'filterFilter',

            // 3rd Party Components
            '$mdSidenav',
            '$state',
            '$mdMedia',

            // Custom components
            'bookingResourceService',
            'navbarHelper',
            'translationService',
            'eventResourceService',
            'serviceService',
            'vendorService',
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function bookingController
        (
        $timeout,
        $location,
        $scope,
        $rootScope,
        filterFilter,
        $mdSidenav,
        $state,
        $mdMedia,
        bookingResourceService,
        navbarHelper,
        translationService,
        eventResourceService,
        serviceService,
        vendorService,
        encodingHelper
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.$mdMedia = $mdMedia;

        vm.filteredBookings = [];
        vm.ifEmptyResult = false;
        vm.allEvents = [];
        vm.allServices = [];
        vm.usedVendors = [];

        vm.filter = {
            userId: null,
            service: null,
            event: null,
            vendor: null,
            statusId: null,
            searchText: null
        };

        vm.selectedWaitingBookingTab = 0;
        vm.selectedConfirmedBookingTab = 0;
        vm.selectedRejectedBookingTab = 0;
        vm.selectedFilteredBookingTab = 0;
        vm.isAscending = true;
        vm.isFilteringActive = false;
        vm.isFilteredBookingsLoading = false;
        vm.isWaitingBookingsLoading = true;
        vm.isConfirmedBookingsLoading = true;
        vm.isRejectedBookingsLoading = true;

        vm.getUsedVendors = getUsedVendors;
        vm.getBookingType = getBookingType;
        vm.getWaitingBookings = getWaitingBookings;
        vm.getConfirmedBookings = getConfirmedBookings;
        vm.getRejectedBookings = getRejectedBookings;
        vm.getAllEvents = getAllEvents;
        vm.getAllServices = getAllServices;
        vm.showBookingInfo = showBookingInfo;
        vm.getBackToBookingList = getBackToBookingList;
        vm.clearFilters = clearFilters;

        vm.toggleSidenav = toggleSidenav;

        activate();

        $scope.$watch(function () { return vm.filter.searchText }, function (newVal, oldVal) {
            if (oldVal !== newVal && newVal !== null) {
                setFilteringActive();
                getBookingsFiltered();
            }
        });
        $scope.$watch(function () { return vm.filter.vendor }, function (newVal, oldVal) {
            if (oldVal !== newVal && newVal !== null) {
                setFilteringActive();
                getBookingsFiltered();
            }
        });

        $scope.$watch(function () { return vm.filter.service }, function (newVal, oldVal) {
            if (oldVal !== newVal && newVal !== null) {
                setFilteringActive();
                getBookingsFiltered();
            }
        });

        $scope.$watch(function () { return vm.filter.event }, function (newVal, oldVal) {
            if (oldVal !== newVal && newVal !== null) {
                setFilteringActive();
                getBookingsFiltered();
            }
        });

        $scope.$watch(function () { return vm.filter.statusId }, function (newVal, oldVal) {
            if (oldVal !== newVal && newVal !== null) {
                setFilteringActive();
                getBookingsFiltered();
            }
        });

        $scope.$on('bookingSearchRequested', function (event, data) {
            vm.filter.searchText = data.searchText;
        });


        function activate() {
            setNavbarItem('Bookings');
            getBookingDataIfAvailable();
        }

        function toggleSidenav(sidenavId) {
            $mdSidenav(sidenavId).toggle();
        }

        function setFilteringActive() {
            vm.isFilteringActive = true;
        }

        function getBookingDataIfAvailable() {
            var urlParameters = $location.search();
            if (urlParameters.id !== undefined) {
                var bookingId = encodingHelper.decode(urlParameters.id);

                bookingResourceService.resource().get({ 'id': bookingId }, function (response) {
                    var bookingInfo = response.output.bookings[0];

                    showBookingInfo('filtered', bookingInfo);
                });
            }
        }

        function getBookingType(statusId) {
            if (statusId === 1) {
                return 'waiting'
            }
            else if (statusId === 2) {
                return "confirmed"
            }

            else if (statusId == 3) {
                return "rejected";
            }
        }

        function showBookingInfo(bookingType, bookingInfo) {
            if (bookingType === 'waiting') {
                vm.selectedWaitingBookingTab = 1;
            }
            else if (bookingType === 'confirmed') {
                vm.selectedConfirmedBookingTab = 1;
            }
            else if (bookingType === 'rejected') {
                vm.selectedRejectedBookingTab = 1;
            }
            else if (bookingType === 'filtered') {
                vm.selectedFilteredBookingTab = 1;
            }

            vm.selectedBookingInfo = bookingInfo;
        }

        function getBackToBookingList(bookingType) {
            if (bookingType === 'waiting') {
                vm.selectedWaitingBookingTab = 0;
            }
            else if (bookingType === 'confirmed') {
                vm.selectedConfirmedBookingTab = 0;
            }
            else if (bookingType === 'rejected') {
                vm.selectedRejectedBookingTab = 0;
            }
            else if (bookingType === 'filtered') {
                vm.selectedFilteredBookingTab = 0;
            }
        }

        // Set navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function setCounts(bookings) {
            vm.allBookingsCount = bookings.length;
            checkResultLength(vm.allBookingsCount);
            vm.waitingBookingsCount = filterFilter(bookings, { statusId: 1 }).length;
            vm.confirmedBookingsCount = filterFilter(bookings, { statusId: 2 }).length;
            vm.rejectedBookingsCount = filterFilter(bookings, { statusId: 3 }).length;
        }

        function getWaitingBookings() {
            if (!vm.isFilteringActive) {
                vm.isWaitingBookingsLoading = true;
                bookingResourceService.resource().get({ 'statusId': 1 }, function (response) {
                    vm.waitingBookings = response.output.bookings;
                    vm.isWaitingBookingsLoading = false;
                    setCounts(vm.waitingBookings);
                });
            }
        }

        function clearFilters() {
            vm.filter = {
                userId: null,
                service: null,
                event: null,
                vendor: null,
                statusId: null,
                searchText: null
            };

            vm.isFilteringActive = false;

            vm.filteredBookings = [];
        }

        function getConfirmedBookings() {
            if (!vm.isFilteringActive) {
                vm.isConfirmedBookingsLoading = true;
                bookingResourceService.resource().get({ 'statusId': 2 }, function (response) {
                    vm.confirmedBookings = response.output.bookings;
                    vm.isConfirmedBookingsLoading = false;
                    setCounts(vm.confirmedBookings);
                });
            }
        }

        function getRejectedBookings() {
            if (!vm.isFilteringActive) {
                vm.isRejectedBookingsLoading = true;
                bookingResourceService.resource().get({ 'statusId': 3 }, function (response) {
                    vm.rejectedBookings = response.output.bookings;
                    vm.isRejectedBookingsLoading = false;
                    setCounts(vm.rejectedBookings);
                });
            }
        }

        function getBookingsFiltered() {
            if (vm.isFilteringActive) {
                vm.isFilteredBookingsLoading = true;
                bookingResourceService.resource()
                    .get({
                        'statusId': vm.filter.statusId,
                        'vendorId': vm.filter.vendor === null ? null : vm.filter.vendor.userId,
                        'serviceId': vm.filter.service === null ? null : vm.filter.service.id,
                        'eventId': vm.filter.event === null ? null : vm.filter.event.id,
                        'searchText': vm.filter.searchText
                    }, function (response) {
                        vm.filteredBookings = response.output.bookings;
                        vm.isFilteredBookingsLoading = false;
                        setCounts(vm.filteredBookings);
                    });
            }
        }

        function getAllEvents() {
            return $timeout(function () {
                eventResourceService.resource().get().$promise.then(function (response) {
                    vm.allEvents = response.output.userEvents;
                });
            }, 500);
        }

        function setOrder(value) {
            vm.isAscending = value;
        }

        function checkResultLength(result) {
            if (result.length === 0) {
                vm.ifEmptyResult = true;
            }
        }

        function getAllServices() {
            return $timeout(function () {
                serviceService.getData().then(function (response) {
                    vm.allServices = response.data.output.services;
                });
            }, 500);
        }

        function getUsedVendors() {
            return $timeout(function () {
                vendorService.getUsedVendors().then(function (response) {
                    vm.usedVendors = response.data.output.vendors;
                });
            }, 500);
        }
    }
    //#endregion 
})();


