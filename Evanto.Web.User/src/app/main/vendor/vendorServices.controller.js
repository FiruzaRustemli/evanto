(function () {
    'use strict';

    //#region Module
    angular
        .module('app.vendor')
        .controller('VendorServicesController', vendorServicesController);
    //#endregion

    //#region Dependencies
    vendorServicesController.$inject =
        [
            // Angular components
            '$scope',
            '$window',

            // 3rd Party Components
            '$state',
            '$stateParams',
            '$mdDialog',
            '$mdSidenav',

            // Custom components
            'vendorServiceResourceService',
            'vendorService',
            'userServiceResourceService',
            'selectedEventService',
            'messageService',
            'navbarHelper',
            'userServiceBudgetService',
            'encodingHelper',
            'ratingResourceService'
        ];
    //#endregion

    //#region Function
    function vendorServicesController
        (
        $scope,
         $window,
        $state,
        $stateParams,
        $mdDialog,
        $mdSidenav,
        vendorServiceResourceService,
        vendorService,
        userServiceResourceService,
        selectedEventService,
        messageService,
        navbarHelper,
        userServiceBudgetService,
        encodingHelper,
        ratingResourceService
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.vendorInfo = $stateParams.vendorInfo;
        vm.selectedEvent = {};
        vm.assignedBudget = null;

        // Prevents initial invoking of OnPageChanged metod
        vm.pageChangedCalledCount = 0;

        vm.selectedVendorService = {}
        vm.selectedUserService = {};
        vm.newUserService = {};

        // Will be passed to $mdDialog
        $scope.bookingInfo = {};

        vm.onPageChanged = onPageChanged;
        vm.showSelectEventDialog = showSelectEventDialog;
        vm.toggleSidenav = toggleSidenav;
        vm.showInMarketPlace = showInMarketPlace;

        vm.filterValues = {
            pageSize: 10,
            pageNumber: 1,
            searchText: "",
            orderBy: "",
            orderByDirection: ""
        }
        vm.paging = {
            totalPages: null,
            currentPage: null
        }


        $scope.$watch(function () { return vm.filterValues.searchText }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isDefined(newVal)) {
                getVendorServices(vm.vendorInfo.id);
            }
        });

        $scope.$watch(function () { return vm.filterValues.pageSize }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isDefined(newVal)) {
                getVendorServices(vm.vendorInfo.id);
            }
        });

        $scope.$watch(function () { return selectedEventService.get() }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isObject(newVal) && angular.isDefined(newVal)) {
                vm.selectedEvent = newVal;

                messageService.success('Event ' + newVal.name + ' selected.');

                checkUserHasUserService(newVal.id);
            }
        })
        

// Budget system for vendor services is disabled
        // $scope.$watch(function () { return userServiceBudgetService.get() }, function (newVal, oldVal) {
        //     if (oldVal !== newVal && angular.isDefined(newVal)) {
        //         vm.assignedBudget = newVal;

        //         addUserServiceToEvent();
        //     }
        // });

        activate();


        function activate() {
            getVendorServices(vm.vendorInfo.id);
            setNavbarItem('none');
        }

        // Toggles rating sidenav
        function toggleSidenav(sidenavId) {
            $mdSidenav(sidenavId).toggle();
        }


        // Sets navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function showInMarketPlace(vendorService) {
            $window.open('/marketplace/' + vendorService.name + '-' + encodingHelper.encode(vendorService.id), '_blank');
        };

        function onPageChanged() {
            vm.pageChangedCalledCount++;
            if (
                angular.isDefined(vm.paging.currentPage) &&
                vm.paging.currentPage !== null &&
                vm.pageChangedCalledCount > 2) {

                disablePagingButtons();

                vm.filterValues.pageNumber = vm.paging.currentPage;
                getVendorServices(vm.vendorInfo.id);
            }
        }
        function showSelectEventDialog(vendorService) {
            vm.selectedVendorService = vendorService;

            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/event/selectEvent.html',
                    parent: angular.element(document.body)
                });
        }

        function disablePagingButtons(elements) {
            var pagingButtons = angular.element('cl-paging button');
            pagingButtons.attr('disabled', true);
        }

        function enablePagingButtons(elements) {
            var pagingButtons = angular.element('cl-paging button');
            pagingButtons.attr('disabled', false);
        }

        function checkUserHasUserService(userEventId) {
            userServiceResourceService.resource().get({
                serviceId: vm.selectedVendorService.servicePeriodPrice.serviceId,
                userEventId: userEventId
            }, function (response) {
                var data = response.output;

                if (data.userServices.length === 0 && data.usedUserServices.length === 0) {
    /*                var confirmDialog = $mdDialog.confirm()
                        .title('You want to add this service to your selected event')
                        .textContent('You have not added this service to your event before. You must add the service to create booking')
                        .ok('Add service')
                        .cancel('Dont create booking');

                    $mdDialog.show(confirmDialog).then(function () {*/
                        // $mdDialog
                        //     .show({
                        //         scope: $scope,
                        //         preserveScope: true,
                        //         templateUrl: 'app/main/service/userServiceBudget.html',
                        //         parent: angular.element(document.body)
                        //     });
                        addUserServiceToEvent();
                   /* }, function () {
                        messageService.success('Create booking prevented.');
                    })*/
                }

                else {
                    if (data.userServices.length === 0) {
                        vm.selectedUserService = data.usedUserServices[0];
                    }
                    else if (data.usedUserServices.length === 0) {
                        vm.selectedUserService = data.userServices[0];
                    }

                    showBookingDialog();
                }
            });
        }

        function showBookingDialog() {
            $scope.bookingInfo.eventInfo = vm.selectedEvent;
            $scope.bookingInfo.eventNonStringDate = new Date(vm.selectedEvent.eventDate);
            $scope.bookingInfo.vendorInfo = vm.vendorInfo;
            $scope.bookingInfo.userService = vm.selectedUserService;
            $scope.bookingInfo.vendorServiceInfo = vm.selectedVendorService;

            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/booking/new.html',
                    parent: angular.element(document.body)
                });
        }


        function addUserServiceToEvent() {
            vm.newUserService.serviceId = vm.selectedVendorService.servicePeriodPrice.serviceId;
            vm.newUserService.userEventId = vm.selectedEvent.id;
            // vm.newUserService.budget = vm.assignedBudget;

            userServiceResourceService.resource().save(vm.newUserService, function (response) {

                // messageService.success('Budget for ' + vm.selectedVendorService.servicePeriodPrice.service.name + ' set to ' + vm.assignedBudget + ' AZN.');
                messageService.success(vm.selectedVendorService.name + ' service created for ' + vm.selectedEvent.name + '.');

                vm.selectedUserService = response.output.userService;
                vm.selectedUserService.service = vm.selectedVendorService.servicePeriodPrice.service;

                showBookingDialog();
            });
        }

        function getVendorServices(id) {
            if (angular.isUndefined(id) || !angular.isObject(id)) {
                id = encodingHelper.decode($stateParams.id);

                if (id.length === 0) {
                    messageService.success('No such vendor available.');
                    $state.transitionTo('app.events');
                    return;
                }

                vendorService.getData(id).then(function (response) {
                    vm.vendorInfo = response.data.output.vendor;
                    vm.vendorInfo.ratingRounded = Math.ceil(parseFloat(vm.vendorInfo.rating));
                });
            }

            vendorServiceResourceService.resource().get(
                {
                    'vendorId': id,
                    'filter.pageSize': vm.filterValues.pageSize,
                    'filter.pageNumber': vm.filterValues.pageNumber,
                    'filter.searchText': vm.filterValues.searchText,
                    'filter.orderBy': vm.filterValues.orderBy,
                    'filter.orderByDirection': vm.filterValues.orderByDirection
                },
                function (response) {
                    vm.vendorServices = response.output.vendorServices.data;
                    vm.paging.totalPages = response.output.vendorServices.totalPages;
                    vm.paging.currentPage = response.output.vendorServices.currentPage;

                    enablePagingButtons();
                });
        }

    }
    //#endregion 
})();

