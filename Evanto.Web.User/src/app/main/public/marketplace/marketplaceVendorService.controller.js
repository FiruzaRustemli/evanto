(function () {
    'use strict';

    //#region Module
    angular
        .module('app.public.marketplace')
        .controller('MarketplaceVendorService', marketplaceVendorServiceController);
    //#endregion

    //#region Dependencies
    marketplaceVendorServiceController.$inject =
        [
            // Angular components
            '$scope',
            '$location',

            // 3rd Party Components
            '$mdDialog',
            '$state',
            '$mdSidenav',
            '$translate',

            // Custom components
            'encodingHelper',
            'marketplaceVendorServiceService',
            'authService',
            'selectedEventService',
            'messageService',
            'userServiceResourceService',
            'bookingResourceService',
            'localStorage',
            'userInfo',
            'vendorServiceImageService',
            'appSettings'
        ];
    //#endregion

    //#region Function
    function marketplaceVendorServiceController
        (
        $scope,
        $location,
        $mdDialog,
        $state,
        $mdSidenav,
        $translate,
        encodingHelper,
        marketplaceVendorServiceService,
        authService,
        selectedEventService,
        messageService,
        userServiceResourceService,
        bookingResourceService,
        localStorage,
        userInfo,
        vendorServiceImageService,
        appSettings
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.isMenuOpen = false;
        vm.vendor = {};
        vm.vendorService;
        vm.otherVendorServices;
        vm.selectedVendorService = {}
        vm.locale = $translate;

        vm.vendorServiceImages = [];

        vm.newUserService = {};
        vm.isAuthenticated = authService.isAuthenticated();
        vm.vendorServiceBookings = [];
        vm.userRatings = [];
        vm.isBookingsLoaded = false;
        vm.isAddEventOpenedFromToolbar = false;
        vm.selectedBooking = {};

        // Will be passed to $mdDialog
        $scope.bookingInfo = {};
        $scope.vendorServiceInfo = {};
        $scope.automaticEventSelectionInDialog = false;

        vm.showSelectEventDialog = showSelectEventDialog;
        vm.showBookingInfoDialog = showBookingInfoDialog;

        vm.showRatingDialog = showRatingDialog;
        vm.addEvent = addEvent;
        vm.toggleMenu = toggleMenu;

        $scope.$watch(function () { return selectedEventService.get() }, function (newVal, oldVal) {
            if (oldVal !== newVal && angular.isObject(newVal) && angular.isDefined(newVal)) {
                vm.selectedEvent = newVal;

                messageService.success('Event ' + newVal.name + ' selected.');

                checkUserHasUserService(newVal.id);
            }
        });

        $scope.$on('vendorServiceRated', function (event, data) {
            getVendorServiceData();
        });

        $scope.$on('eventCreationCancelled', function () {
            if (vm.isAddEventOpenedFromToolbar === false) {
                showSelectEventDialog();
            }
        });

        $scope.$on('newEventCreated', function () {
            if (vm.isAddEventOpenedFromToolbar === false) {
                $scope.automaticEventSelectionInDialog = true;
                showSelectEventDialog();
            }
        });

        // Slideshow //
        $scope.photos = [
           /* { src: 'http://farm9.staticflickr.com/8042/7918423710_e6dd168d7c_b.jpg', parentSrc: null, desc: 'Image 01', parentId: 1 },
            { src: 'http://farm9.staticflickr.com/8449/7918424278_4835c85e7a_b.jpg', parentSrc: null, desc: 'Image 02', parentId: 1 },
            { src: 'http://farm9.staticflickr.com/8457/7918424412_bb641455c7_b.jpg', parentSrc: null, desc: 'Image 03', parentId: 1 },
            { src: 'http://farm9.staticflickr.com/8179/7918424842_c79f7e345c_b.jpg', parentSrc: null, desc: 'Image 04', parentId: 1 },
            { src: 'http://farm9.staticflickr.com/8315/7918425138_b739f0df53_b.jpg', parentSrc: null, desc: 'Image 05', parentId: 1 },
            { src: 'http://farm9.staticflickr.com/8461/7918425364_fe6753aa75_b.jpg', parentSrc: null, desc: 'Image 06', parentId: 1 }
       */ ];
        // initial image index
        $scope._Index = 0;
        // if a current image is the same as requested image
        $scope.isActive = function (index) {
            return $scope._Index === index;
        };
        // show prev image
        $scope.showPrev = function () {
            var index = ($scope._Index > 0) ? --$scope._Index : $scope.photos.length - 1
            if ($scope.photos[index].parentSrc === null) {
                getVendorServiceImage($scope.photos[index].parentId, index);
            }
            $scope._Index = index;
        };
        // show next image
        $scope.showNext = function () {
            var index = ($scope._Index < $scope.photos.length - 1) ? ++$scope._Index : 0;
            if ($scope.photos[index].parentSrc === null) {
                getVendorServiceImage($scope.photos[index].parentId, index);
            }
            $scope._Index = index;
        };
        // show a certain image
        $scope.showPhoto = function (index) {
            if ($scope.photos[index].parentSrc === null) {
                getVendorServiceImage($scope.photos[index].parentId, index);
            }
            $scope._Index = index;
        };
        ///


        // Adds thumbail image strings to photos array
        $scope.$watch(function () { return vm.vendorServiceImages }, function (newVal, oldVal) {
            if (newVal != oldVal && newVal !== null) {
                angular.forEach(newVal, function (value, key) {
                    $scope.photos.push({
                        src: getInlineImage(value.image),
                        parentSrc: null,
                        parentId: value.parentId,
                        desc: 'Image ' + key
                    })
                });

                // Sets first image
                if (angular.isDefined($scope.photos[0])) {
                    $scope.showPhoto(0);
                }
            }
        }, true);


        activate();

        function activate() {
            getVendorServiceData();
            checkRedirectionPage();
        }

        function checkRedirectionPage() {
            var redirectionPage = localStorage.getRedirectionPage();
            if (redirectionPage !== null || redirectionPage === $location.absUrl()) {
                localStorage.clearRedirectionPage();

                if (vm.isAuthenticated) {
                    showSelectEventDialog();
                }
            }
        }

        function getVendorServiceData() {
            var urlParameters = $location.path().split(/[\s-]+/);
            var vendorServiceId = encodingHelper.decode(urlParameters[urlParameters.length - 1]);

            marketplaceVendorServiceService.getData({ 'id': vendorServiceId }).then(function (response) {
                vm.vendor = response.data.output.vendor;

                vm.vendor.photo = vm.vendor.photo != null ? appSettings.base64Prefix + vm.vendor.photo : '/assets/images/etc/no_vendor_service_image.png';

                vm.vendorService = response.data.output.vendorService;
                // vm.otherVendorServices = response.data.output.otherVendorServices;
                vm.userRatings = response.data.output.userRatings

                getBookingsIfAvailable();

                getVendorServiceThumbnailImages();
            });
        }

        function showRatingDialog() {
            if (vm.isAuthenticated) {
                $scope.vendorServiceInfo = vm.vendorService;

                $mdDialog
                    .show({
                        scope: $scope,
                        preserveScope: true,
                        templateUrl: 'app/main/rating/rateVendorService.html',
                        openFrom: '#rateVendorService',
                        parent: angular.element(document.body)
                    });
            }
            else {
                $state.transitionTo('app.auth_login', {lang: $translate.use()});
            }
        }

        function getBookingsIfAvailable() {
            if (vm.isAuthenticated) {
                vm.isBookingsLoaded = false;

                bookingResourceService.resource().get({ 'vendorServiceId': vm.vendorService.id }, function (response) {
                    vm.vendorServiceBookings = response.output.bookings;
                });

                vm.isBookingsLoaded = true;
            }
        }

        function showSelectEventDialog() {
            if (vm.isAuthenticated) {
                vm.selectedVendorService = vm.vendorService;
                $scope.vendorServiceInfo = vm.selectedVendorService;
                $mdDialog
                    .show({
                        scope: $scope,
                        preserveScope: true,
                        templateUrl: 'app/main/event/selectEvent.html',
                        parent: angular.element(document.body)
                    });
            }
            else {
                localStorage.setRedirectionPage($location.absUrl());
                $state.transitionTo('app.auth_login',{lang: $translate.use()});
            }
        }

        function toggleMenu() {
            vm.isMenuOpen = !vm.isMenuOpen;
        }

        function addEvent() {
            vm.isAddEventOpenedFromToolbar = true;

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

        function checkUserHasUserService(userEventId) {
            vm.selectedVendorService = vm.vendorService;
            userServiceResourceService.resource().get({
                serviceId: vm.selectedVendorService.serviceId,
                userEventId: userEventId
            }, function (response) {
                var data = response.output;

                if (data.userServices.length === 0 && data.usedUserServices.length === 0) {
                    /*   var confirmDialog = $mdDialog.confirm()
                           .title('You want to add this service to your selected event')
                           .textContent('You have not added this service to your event before. You must add the service to create booking')
                           .ok('Add service')
                           .cancel('Dont create booking');*/

                    // $mdDialog.show(confirmDialog).then(function () {
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
            $scope.bookingInfo.vendorInfo = vm.vendor;
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
            vm.newUserService.serviceId = vm.selectedVendorService.serviceId;
            vm.newUserService.userEventId = vm.selectedEvent.id;

            userServiceResourceService.resource().save(vm.newUserService, function (response) {
                messageService.success(vm.selectedVendorService.name + ' service created for ' + vm.selectedEvent.name + '.');

                vm.selectedUserService = response.output.userService;
                vm.selectedUserService.service = {};
                vm.selectedUserService.service.id = vm.selectedVendorService.serviceId;
                vm.selectedUserService.service.name = vm.selectedVendorService.serviceName;

                showBookingDialog();
            });
        }

        function showBookingInfoDialog(booking) {
            $mdDialog
                .show({
                    locals: { bookingInfo: booking },
                    preserveScope: true,
                    templateUrl: 'app/main/booking/infoDialog.html',
                    parent: angular.element(document.body),
                    controller: 'BookingInfoDialogController',
                    controllerAs: 'vm'
                });
        }

        function getVendorServiceThumbnailImages() {
            vendorServiceImageService.getData({
                relationalId: vm.vendorService.id,
                typeId: appSettings.fileType.thumbnail
            }).then(function (response) {
                angular.forEach(response.data.output.vendorServiceImages, function (value, key) {
                    vm.vendorServiceImages.push(value);
                });
            });
        }

        function getVendorServiceImage(parentId, index) {
            vendorServiceImageService.getData({
                relationalId: vm.vendorService.id,
                typeId: appSettings.fileType.image,
                parentId: parentId
            }).then(function (response) {
                var result = response.data.output.vendorServiceImages[0];
                if (angular.isDefined(result)) {
                    $scope.photos[index].parentSrc = getInlineImage(result.image);
                }
            });
        }

        function getInlineImage(string) {
            return appSettings.base64Prefix + string;
        }
    }
    //#endregion 
})();


