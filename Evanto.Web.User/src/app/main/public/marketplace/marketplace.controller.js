(function () {
    'use strict';

    //#region Module
    angular
        .module('app.public.marketplace')
        .controller('AllVendorServicesController', allVendorServicesController);
    //#endregion

    //#region Dependencies
    allVendorServicesController.$inject =
        [
            // Angular components
            '$scope',
            '$window',
            '$filter',

            // 3rd Party Components
            '$mdDialog',
            '$mdMedia',
            '$translate',

            // Custom components
            'allServices',
            'allEventTypes',
            'allVendorServicesService',
            'encodingHelper',
            'authService',
            'appSettings'
        ];
    //#endregion

    //#region Function
    function allVendorServicesController
        (
        $scope,
        $window,
        $filter,
        $mdDialog,
        $mdMedia,
        $translate,
        allServices,
        allEventTypes,
        allVendorServicesService,
        encodingHelper,
        authService,
        appSettings
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.isMenuOpen = false;
        vm.$mdMedia = $mdMedia;
        vm.screenWidth = $window.innerWidth - 40;
        vm.locale = $translate;

        vm.serviceIds = [];
        vm.checkableServices;
        vm.eventTypeIds = [];
        vm.checkableEventTypes;
        vm.eventTypes = allEventTypes.data.output.eventTypes;
        vm.services = allServices.data.output.services;
        vm.isAllServicesSelected = true;
        vm.isAllEventTypesSelected = true;
        vm.isVendorServicesLoaded = false;
        vm.clearButtonEnabled = false;

        vm.isAuthenticated = authService.isAuthenticated();
        vm.serviceHovered = serviceHovered;
        vm.serviceUnHovered = serviceUnHovered;
        vm.applyFilters = applyFilters;
        vm.onPageChanged = onPageChanged;
        vm.editServiceId = editServiceId;
        vm.editEventTypeId = editEventTypeId;
        vm.gotoVendorServicePage = gotoVendorServicePage;
        vm.clearFilters = clearFilters;
        vm.loadMoreClicked = loadMoreClicked;
        vm.addEvent = addEvent;
        vm.toggleMenu = toggleMenu;

        vm.serviceActionMode = {
            selected: 'full',
            hovered: 'alt',
            unselected: 'bw'
        }

        vm.filterValues = {
            pageSize: 10,
            pageNumber: 1,
            searchText: "",
            orderBy: "",
            orderByDirection: "",
            bookingDate: new Date()
        };

        vm.pageSizes = [10, 30, 50, 100]

        vm.paging = {
            totalPages: 1,
            currentPage: 1
        };

        vm.priceRange = {
            options: {
                floor: 0,
                ceil: 5000,
                translate: function (value) {
                    return value + ' AZN';
                },
                onEnd: priceChangeSliderChanged
            },
            min: 10,
            max: 3000
        };

        // My watch begins

        $scope.$watch(function () { return vm.isAllServicesSelected; }, function (newVal, oldVal) {
            if (newVal !== oldVal && newVal === true) {
                vm.serviceIds = [];
                vm.checkableServices = [];
            }
        });

        $scope.$watch(function () { return vm.filterValues }, function (newVal, oldVal) {
            if (newVal !== oldVal) {
                getVendorServices();
            }
        }, true);

        $scope.$watch(function () { return vm.isAllEventTypesSelected; }, function (newVal, oldVal) {
            if (newVal !== oldVal && newVal === true) {
                vm.eventTypeIds = [];
                vm.checkableEventTypes = [];
            }
        });

        $scope.$watch(function () { return vm.serviceIds; }, function (newVal, oldVal) {
            if (newVal !== oldVal) {
                if (newVal.length === 0) {
                    vm.isAllServicesSelected = true;

                    vm.clearButtonEnabled = false;
                }
                else {
                    vm.isAllServicesSelected = false;

                    vm.clearButtonEnabled = true;
                }
            }
        }, true);

        $scope.$watch(function () { return vm.eventTypeIds; }, function (newVal, oldVal) {
            if (newVal !== oldVal) {
                if (newVal.length === 0) {
                    vm.isAllEventTypesSelected = true;
                }
                else {
                    vm.isAllEventTypesSelected = false;
                }
            }
        }, true);

        activate();


        function activate() {
            getVendorServices();

            setInitialActionModeForServices();
        }
        function loadMoreClicked() {
            if (vm.paging.totalPages > vm.paging.currentPage) {
                vm.paging.currentPage = vm.paging.currentPage + 1;

                onPageChanged();
            }
        }

        function toggleMenu() {
            vm.isMenuOpen = !vm.isMenuOpen;
        }

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

        function setInitialActionModeForServices() {
            angular.forEach(vm.services, function (value, key) {
                value.actionMode = vm.serviceActionMode.unselected;
            });
        }

        function getVendorServices() {
            vm.isVendorServicesLoaded = false;
            allVendorServicesService.getData(
                {
                    'eventTypeIds': vm.eventTypeIds,
                    'serviceIds': vm.serviceIds,
                    'filter.pageSize': vm.filterValues.pageSize,
                    'filter.pageNumber': vm.filterValues.pageNumber,
                    'filter.searchText': vm.filterValues.searchText,
                    'filter.orderBy': vm.filterValues.orderBy,
                    'filter.orderByDirection': vm.filterValues.orderByDirection,
                    'minPrice': vm.priceRange.minPrice,
                    'maxPrice': vm.priceRange.maxPrice,
                    'date': vm.filterValues.bookingDate
                }).then(
                function (response) {
                    vm.vendorServices = response.data.output.vendorServices.data;

                    angular.forEach(vm.vendorServices, function (value, index) {
                        value.photo = value.photo != null ? appSettings.base64Prefix + value.photo : '/assets/images/etc/no_vendor_service_image.png';
                    });

                    vm.paging.totalPages = response.data.output.vendorServices.totalPages;
                    vm.paging.currentPage = response.data.output.vendorServices.currentPage;

                    enablePagingButtons();

                    vm.isVendorServicesLoaded = true;
                });
        }

        function onPageChanged() {
            if (angular.isDefined(vm.paging.currentPage) &&
                vm.paging.currentPage !== null
            ) {
                disablePagingButtons();

                getVendorServices();

                vm.filterValues.pageNumber = vm.paging.currentPage;
            }
        }

        function disablePagingButtons() {
            var pagingButtons = angular.element('cl-paging button');

            pagingButtons.attr('disabled', true);
        }

        function enablePagingButtons() {
            var pagingButtons = angular.element('cl-paging button');

            pagingButtons.attr('disabled', false);
        }

        function editServiceId(service) {
            if (vm.checkableServices[service.id]) {
                service.actionMode = vm.serviceActionMode.selected;
                vm.serviceIds.push(service.id);
            }
            else {
                service.actionMode = vm.serviceActionMode.unselected;
                vm.serviceIds.splice(vm.serviceIds.indexOf(service.id), 1)
            }

            applyFilters();
        }

        function serviceHovered(service) {
            if (service.actionMode === vm.serviceActionMode.unselected) {
                service.actionMode = vm.serviceActionMode.hovered;
            }
        }

        function serviceUnHovered(service) {
            if (service.actionMode === vm.serviceActionMode.hovered) {
                service.actionMode = vm.serviceActionMode.unselected;
            }
        }

        function editEventTypeId(eventTypeId) {
            if (vm.checkableEventTypes[eventTypeId]) {
                vm.eventTypeIds.push(eventTypeId);
            }
            else {
                vm.eventTypeIds.splice(vm.eventTypeIds.indexOf(eventTypeId), 1)
            }
        }

        function applyFilters() {
            vm.isVendorServicesFirstLoading = false;
            getVendorServices();
        }

        function gotoVendorServicePage(vendorService) {
            $window.open('/' + vm.locale.use() +'/marketplace/' + vendorService.name + '-' + encodingHelper.encode(vendorService.id), '_blank');
        }

        function clearFilters() {
            vm.serviceIds = [];
            vm.eventTypeIds = [];

            vm.priceRange = {
                min: 10,
                max: 3000,
                options: {
                    floor: 0,
                    ceil: 5000,
                    translate: function (value) {
                        return value + ' AZN';
                    },
                    onEnd: priceChangeSliderChanged
                }
            };

            vm.clearButtonEnabled = false;
            setInitialActionModeForServices();
            applyFilters();
        }

        function priceChangeSliderChanged(sliderId, modelValue, highValue, pointerType) {
            vm.priceRange.minPrice = modelValue;
            vm.priceRange.maxPrice = highValue;

            vm.clearButtonEnabled = true;
            applyFilters();
        }

    }
    //#endregion 
})();


