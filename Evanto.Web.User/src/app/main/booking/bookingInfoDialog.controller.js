(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('BookingInfoDialogController', bookingInfoDialogController);
    //#endregion

    //#region Dependencies
    bookingInfoDialogController.$inject =
        [
            // Angular components

            // 3rd Party Components
            '$mdDialog',
            '$state',

            // Custom components
            'bookingInfo',
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function bookingInfoDialogController
        (
        $mdDialog,
        $state,
        bookingInfo,
        encodingHelper
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.cancel = cancelDialog;
        vm.goToEventPage = goToEventPage;
        vm.goToVendorServicesPage = goToVendorServicesPage;

        vm.bookingInfo = bookingInfo;

        activate();


        function activate() {

        }

        function cancelDialog() {
            $mdDialog.cancel();
        };

        function goToEventPage(id) {
            cancelDialog();
            
            $state.go('app.event', {
                'id': encodingHelper.encode(id)
            });
        }

        function goToVendorServicesPage(id) {
            cancelDialog();

            $state.go('app.vendorServices', {
                'id': encodingHelper.encode(id)
            });
        }

    }
    //#endregion 
})();


