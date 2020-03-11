(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('EditServiceController', serviceController);
    //#endregion

    //#region Dependencies
    serviceController.$inject =
        [
            // Angular components
            '$log',
            '$window',
            '$scope',
            '$timeout',
            '$location',
            '$anchorScroll',

            // 3rd Party Components
            '$mdDialog',
            '$stateParams',
            '$state',

            // Custom components
            'userServiceResourceService',
            'vendorServiceResourceService',
            'messageService',
            'vendorService',
            'translationService',
            'navbarHelper',
            'serviceEventService',
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function serviceController
        (
        $log,
        $window,
        $scope,
        $timeout,
        $location,
        $anchorScroll,
        $mdDialog,
        $stateParams,
        $state,
        userServiceResourceService,
        vendorServiceResourceService,
        messageService,
        vendorService,
        translationService,
        navbarHelper,
        serviceEventService,
        encodingHelper
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.userServices = [];
        vm.serviceIds = [];
        vm.mdSelectedTab = 0;
        vm.isSelectedVendorServicesLoading = true;
        vm.isSelectedVendorServicesFirstLoading = false;
        vm.topVendorServicesLoading = true;
        vm.selectedUserService = {};

        vm.filterValues = {
            pageSize: 10,
            pageNumber: 1,
            searchText: "",
            orderBy: "",
            orderByDirection: ""
        };
        vm.paging = {
            totalPages: 1,
            currentPage: 1
        };

        vm.showVendorInfo = showVendorInfo;
        vm.showBookingDialog = showBookingDialog;
        vm.showAllServices = showAllServices;
        vm.goBackTopServices = goBackTopServices;
        vm.onPageChanged = onPageChanged;
        vm.showInMarketplace = showInMarketplace;

        // We use $scope to pass data to dialog.
        $scope.bookingInfo = {};
        $scope.vendorInfo = {};
        $scope.eventInfo = {};

        //$scope.$watch(function () { return userServiceModel.get() }, function (newVal, oldVal) {
        //    if (oldVal !== newVal && angular.isDefined(oldVal)) {
        //        vm.userServices = newVal;
        //        getTopServices();
        //    }
        //});

        $scope.$watch(function () { return vm.filterValues.searchText }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isDefined(oldVal)) {
                getVendorServices(vm.selectedUserService.service.id);
            }
        });

        $scope.$watch(function () { return vm.filterValues.pageSize }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isDefined(oldVal)) {
                getVendorServices(vm.selectedUserService.service.id);
            }
        });

        $scope.$on('userServicesEdited', function (event, args) {
            if (angular.isDefined(args)) {
                if (!args.isRemovingOperation) {

                    vm.userServices.unshift(args.addingService);

                    getTopVendorServicesByServiceId(args.addingService.serviceId);
                }
                else {
                    vm.userServices.splice(getIndexOf(vm.userServices, args.removingServiceId), 1);
                }
            }
        });

        activate();


        function activate() {
            getEventInfo();
            setNavbarItem('Events');
            setSelectedVendorServicesFirstLoading();
        }

        // Sets navbar item.
        function setNavbarItem(navbarItem) {
            navbarHelper.setCurrentNavItem(navbarItem);
        }

        function getEventInfo() {
            $scope.eventInfo = serviceEventService.get();
            if ($scope.eventInfo !== undefined)
            { getTopServicesFirst($stateParams.userServices); }
        }

        function showBookingDialog(userService, vendorServiceInfo) {
            vendorService.getData(vendorServiceInfo.vendorServicePacket.vendorId).then(function (response) {
                $scope.bookingInfo.vendorInfo = response.data.output.vendor;
                $scope.bookingInfo.vendorInfo.id = vendorServiceInfo.vendorServicePacket.vendorId;
                $scope.bookingInfo.vendorServiceInfo = vendorServiceInfo;
            });

            $scope.bookingInfo.userService = userService;
            $scope.bookingInfo.vendorInfo = $scope.vendorInfo;
            $scope.bookingInfo.eventInfo = $scope.eventInfo;
            $scope.bookingInfo.eventNonStringDate = new Date($scope.eventInfo.eventDate);

            $mdDialog
                .show({
                    scope: $scope,
                    preserveScope: true,
                    templateUrl: 'app/main/booking/new.html',
                    parent: angular.element(document.body)
                });
        };

        function showInMarketplace(vendorService) {
            $window.open('/marketplace/' + vendorService.name + '-' + encodingHelper.encode(vendorService.id), '_blank');
        }

        function showVendorInfo(vendorId) {
            /*   vendorService.getData(vendorId).then(function (response) {
                   $scope.vendorInfo = response.data.output.vendor;
                   $scope.vendorInfo.id = vendorId;
   
                   $mdDialog
                       .show({
                           scope: $scope,
                           preserveScope: true,
                           templateUrl: 'app/main/vendor/vendorInfo.html',
                           parent: angular.element(document.body)
                       });
               });*/
            $state.go('app.vendorServices', {
                'id': encodingHelper.encode(vendorId)
            });

        }

        // Prevents initial invoking of OnPageChanged metod
        function setSelectedVendorServicesFirstLoading() {
            vm.isSelectedVendorServicesFirstLoading = true;
        }

        function onPageChanged() {
            if (angular.isDefined(vm.paging.currentPage) &&
                vm.paging.currentPage !== null &&
                !vm.isSelectedVendorServicesFirstLoading
            ) {

                disablePagingButtons();

                vm.filterValues.pageNumber = vm.paging.currentPage;
                getVendorServices(vm.selectedUserService.service.id);
            }
        }

        function getTopServicesFirst(userServices) {
            vm.userServices = userServices;
            angular.forEach(userServices, setServiceIds);
            getTopVendorServicesByServiceIds(vm.serviceIds);
        }

        function disablePagingButtons() {
            var pagingButtons = angular.element('cl-paging button');

            pagingButtons.attr('disabled', true);
        }

        function enablePagingButtons(elements) {
            var pagingButtons = angular.element('cl-paging button');

            pagingButtons.attr('disabled', false);
        }

        //function getTopServices() {
        //   angular.forEach(vm.userServices, setServiceIds);
        //   getTopVendorServicesByServiceIds(vm.serviceIds);
        //}

        function setServiceIds(item) {
            vm.serviceIds.push(item.serviceId);
        }

        function getTopVendorServicesByServiceId(id) {
            vm.topVendorServicesLoading = true;

            vendorServiceResourceService.resource().topServices({ 'serviceId': [id], 'eventTypeId': $scope.eventInfo.eventType.id }, function (response) {

                var requestedVendorServices = vm.vendorServices.filter(function (vendorService) {
                    return vendorService.servicePeriodPrice.service.id !== id;
                });

                vm.vendorServices = requestedVendorServices;
                angular.forEach(response.output.vendorServices, function (value, key) {
                    vm.vendorServices.push(value);
                });
                vm.topVendorServicesLoading = false;
            });
        }

        function getTopVendorServicesByServiceIds(ids) {
            vm.topVendorServicesLoading = true;
            vendorServiceResourceService.resource().topServices({ 'serviceIds[]': ids, 'eventTypeId': $scope.eventInfo.eventType.id }, function (response) {
                vm.vendorServices = response.output.vendorServices;
                vm.topVendorServicesLoading = false;
            });
        }

        function getVendorServices(selectedServiceId) {
            if (vm.isSelectedVendorServicesFirstLoading) {
                vm.isSelectedVendorServicesFirstLoading = false;
            }

            vm.isSelectedVendorServicesLoading = true;
            vendorServiceResourceService.resource().get(
                {
                    'serviceId': selectedServiceId,
                    'eventTypeId': $scope.eventInfo.eventType.id,
                    'filter.pageSize': vm.filterValues.pageSize,
                    'filter.pageNumber': vm.filterValues.pageNumber,
                    'filter.searchText': vm.filterValues.searchText,
                    'filter.orderBy': vm.filterValues.orderBy,
                    'filter.orderByDirection': vm.filterValues.orderByDirection
                },
                function (response) {
                    vm.selectedVendorServices = response.output.vendorServices.data;
                    vm.paging.totalPages = response.output.vendorServices.totalPages;
                    vm.paging.currentPage = response.output.vendorServices.currentPage;
                    vm.isSelectedVendorServicesLoading = false;

                    enablePagingButtons();

                    scrollToAllServicesTab();
                });
        }

        function showAllServices(selectedUserService) {
            vm.mdSelectedTab = 1;
            vm.selectedUserService = selectedUserService;
            getVendorServices(vm.selectedUserService.service.id);
        }

        function scrollToAllServicesTab() {
            if ($location.hash() !== 'allVendorServicesTab') {
                $location.hash('allVendorServicesTab');
            }
            else {
                $anchorScroll();
            }
        }

        function goBackTopServices() {
            vm.mdSelectedTab = 0;
        }

        function getIndexOf(list, serviceId) {
            for (var i = 0; i < list.length; i++) {
                if (list[i].service.id === serviceId) {
                    return i;
                }
            }
        }

    }
    //#endregion 
})();


