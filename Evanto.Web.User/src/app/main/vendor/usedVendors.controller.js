(function () {
    'use strict';

    //#region Module
    angular
        .module('evantoApp')
        .controller('UsedVendorController', usedVendorController);
    //#endregion

    //#region Dependencies
    usedVendorController.$inject =
        [
            // Angular components

            // 3rd Party Components

            // Custom components
            'vendorService'

        ];
    //#endregion

    //#region Function
    function usedVendorController
        (
            vendorService
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.vendors = [];


        activate();


        function activate() {
            getUsedVendors();
        }

        function getUsedVendors() {
            vendorService.getUsedVendors().then(function (response) {
                vm.vendors = response.data.output.vendors;
            });
        }

    }
    //#endregion 
})();


