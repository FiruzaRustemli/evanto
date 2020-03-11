(function () {
    'use strict';

    //#region Module
    angular
        .module('app.vendor')
        .controller('RateVendorServiceController', rateVendorServiceController);
    //#endregion

    //#region Dependencies
    rateVendorServiceController.$inject =
        [
            // Angular components
            '$scope',
            '$filter',

            // 3rd Party Components
            '$mdDialog',

            // Custom components
            'ratingResourceService',
            'messageService'
        ];
    //#endregion

    //#region Function
    function rateVendorServiceController
        (
        $scope,
        $filter,
        $mdDialog,
        ratingResourceService,
        messageService
        ) {
        /* jshint validthis:true */
        var vm = this;

        vm.vendorServiceInfo = {};
        vm.ratingInfo = {};

        vm.cancel = cancelDialog;
        vm.rate = rate;
        vm.countStars = countStars;
        vm.clearRating = clearRating;

        activate();

        function activate() {
            vm.vendorServiceInfo = $scope.$parent.vendorServiceInfo;
        }

        function cancelDialog() {
            $mdDialog.cancel();
        };

        function countStars() {
            var stars = angular.element(document).find('.star-on');
        }

        function clearRating() {
            vm.ratingInfo.rating = undefined
        }

        function rate() {
            if (vm.ratingInfo.rating === undefined) {
                messageService.warn($filter('translate')('Marketplace.Success.PleaseAtLeastGiveRating'));

                return;
            }

            vm.ratingInfo.vendorServiceId = vm.vendorServiceInfo.id;
            ratingResourceService.resource().save(vm.ratingInfo, function () {
                messageService.success($filter('translate')('Marketplace.Success.ServiceRated'));
                $mdDialog.cancel();
                $scope.$emit('vendorServiceRated', vm.ratingInfo);
            });
        }
    }
    //#endregion 
})();


