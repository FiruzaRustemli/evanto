(function () {
    'use strict';

    //#region Module
    angular
        .module('app.vendor')
        .controller('VendorInfoController', vendorInfoController);
    //#endregion

    //#region Dependencies
    vendorInfoController.$inject =
        [
            // Angular components
            '$scope',
            '$state',

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'encodingHelper'
        ];
    //#endregion

    //#region Function
    function vendorInfoController
        (
           $scope,
           $state,
           $mdDialog,
           encodingHelper
        ) {
        /* jshint validthis:true */
        var vm = this;
        vm.vendorInfo = {};

        vm.goToVendorServicesPage = goToVendorServicesPage;

        vm.cancel = function () {
            $mdDialog.cancel();
        };


        activate();


        function activate() {
            vm.vendorInfo = $scope.vendorInfo;
        }

        function goToVendorServicesPage() {
            vm.cancel();
            $state.go('app.vendorServices', {
                'id': encodingHelper.encode(vm.vendorInfo.id),
                'vendorInfo': vm.vendorInfo
            });
        }

    }
    //#endregion 
})();


