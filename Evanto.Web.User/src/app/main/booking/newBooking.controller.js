(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('NewBookingController', newBookingController);
    //#endregion

    //#region Dependencies
    newBookingController.$inject =
        [
            // Angular components
            '$scope',
            '$rootScope',
            '$state',
            '$filter',

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'bookingResourceService',
            'messageService',
            'translationService',
            'dateTimeJoinHelper'
        ];
    //#endregion

    //#region Function
    function newBookingController
        (
        $scope,
        $rootScope,
        $state,
        $filter,
        $mdDialog,
        bookingResourceService,
        messageService,
        translationService,
        dateTimeJoinHelper
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.newBooking = $scope.bookingInfo;
        vm.addingBooking = {};
        vm.isCreateBookingButtonEnabled = true;

        vm.now = new Date();

        vm.bookingDateRange = {
            minDate: new Date(
                vm.now.getFullYear(),
                vm.now.getMonth(),
                vm.now.getDate()
            ),
            maxDate: new Date(
                vm.now.getFullYear(),
                vm.now.getMonth() + 3,
                vm.now.getDate()
            )
        }

        vm.deadlineRange = {
            minDate: new Date(
                vm.now.getFullYear(),
                vm.now.getMonth(),
                vm.now.getDate()
            ),
            maxDate: new Date(
                vm.newBooking.eventNonStringDate.getFullYear(),
                vm.newBooking.eventNonStringDate.getMonth() + 3,
                vm.newBooking.eventNonStringDate.getDate()
            )
        }

        vm.add = addBooking;
        vm.cancel = cancelDialog;

        activate();


        function activate() {
        }

        function cancelDialog() {
            $mdDialog.cancel();
        };

        function addBooking() {
            var bookingTime = vm.addingBooking.selectedHour + ':' + vm.addingBooking.selectedMinute;
            vm.addingBooking.bookdate = dateTimeJoinHelper.join($filter('date')(vm.addingBooking.bookdate, 'yyyy-MM-dd'), bookingTime);

            var eventDate = new Date(vm.newBooking.eventNonStringDate);
            var deadline = new Date(vm.addingBooking.deadline);

            vm.isCreateBookingButtonEnabled = false;

            vm.addingBooking.vendorId = vm.newBooking.vendorInfo.userId;
            vm.addingBooking.userServiceId = vm.newBooking.userService.id;
            vm.addingBooking.eventDate = eventDate.toLocaleDateString();
            vm.addingBooking.deadline = deadline.toLocaleDateString();
            vm.addingBooking.vendorServiceId = vm.newBooking.vendorServiceInfo.id;

            bookingResourceService
                .resource()
                .save(vm.addingBooking,
                function (response) {
                    messageService.bookingCreated($filter('translate')('Toast.Success.BookingCreated'), $filter('translate')('Booking.Bookings')).then(function (toastResponse) {
                        if (toastResponse == 'ok') {
                            $state.transitionTo('app.bookings')
                        }
                    });
                    vm.isCreateBookingButtonEnabled = true;
                    $rootScope.$broadcast('userServiceUsed');
                    $mdDialog.cancel();
                }, function () {
                    vm.isCreateBookingButtonEnabled = true;
                });
        };

    }
    //#endregion 
})();


